using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class InputManager : Singleton<InputManager>
{
    private InputActions _input;
    [Header("Character Input Values")]
    public Vector2 move;
    public Vector2 look;
    public bool jump;
    public bool sprint;
    
    [Header("Mouse Cursor Settings")]
    public bool cursorLocked = true;
	public bool cursorInputForLook = true;
    void Awake()
    {
        _input = new InputActions();
        _input.Player.Pause.performed += context => GameManager.Instance.TogglePause();
        EventManagerSO.E_PauseGame += EnableMouse;
        EventManagerSO.E_StartPrematch += EnableMouse;
        EventManagerSO.E_EndMatch += EndMatchCleanup;
        EventManagerSO.E_UnpauseGame += DisableMouse;
    }
    
    
    private void OnEnable()
    {
        _input.Enable();
    }
    private void OnDisable()
    {
        _input.Disable();
        _input.Player.Pause.performed -= context => GameManager.Instance.TogglePause();
        EventManagerSO.E_PauseGame -= EnableMouse;
        EventManagerSO.E_StartPrematch -= EnableMouse;
        EventManagerSO.E_EndMatch -= EndMatchCleanup;
        EventManagerSO.E_UnpauseGame -= DisableMouse;
    }
    private void EndMatchCleanup(Team NA)
    {
        EnableMouse();
    }

    void EnableMouse()
    {
        // cursorLocked = false;
        cursorInputForLook = false;
        SetCursorState(cursorInputForLook);
    }
    void DisableMouse()
    {
        // cursorLocked = true;
        cursorInputForLook = true;
        SetCursorState(cursorInputForLook);
    }


    public void OnMove(InputValue value)
    {
        MoveInput(value.Get<Vector2>());
    }

    public void OnLook(InputValue value)
    {
        if(cursorInputForLook)
        {
            LookInput(value.Get<Vector2>());
        }
    }

    public void OnJump(InputValue value)
    {
        JumpInput(value.isPressed);
    }

    public void OnSprint(InputValue value)
    {
        SprintInput(value.isPressed);
    }
    public void MoveInput(Vector2 newMoveDirection)
    {
        move = newMoveDirection;
    } 

    public void LookInput(Vector2 newLookDirection)
    {
        look = newLookDirection;
    }

    public void JumpInput(bool newJumpState)
    {
        jump = newJumpState;
    }

    public void SprintInput(bool newSprintState)
    {
        sprint = newSprintState;
    }
    private void OnApplicationFocus(bool hasFocus)
    {
        if(GameManager.Instance.currentState != GameState.Paused){
            Debug.Log("locking cursor");
            SetCursorState(cursorLocked);
        }
        
    }

    private void SetCursorState(bool newState)
    {
        Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
    }
}
