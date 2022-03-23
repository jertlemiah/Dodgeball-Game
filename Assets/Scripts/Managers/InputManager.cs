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
    public bool aim;
    public bool throw_bool;

    public bool pickup;

    [Header("Movement Settings")]
    public bool analogMovement;
    
    [Header("Mouse Cursor Settings")]
    public bool cursorLocked = true;
	public bool cursorInputForLook = true;
    void Awake()
    {
        _input = new InputActions();
        _input.Player.Pause.performed += context => PausePerformed();
        // _input.Player.Move.performed += context => MoveInput(context);
        EventManagerSO.E_PauseGame += EnableMouse;
        EventManagerSO.E_FinishedLoading += DisableMouse;
        EventManagerSO.E_EndMatch += EndMatchCleanup;
        EventManagerSO.E_UnpauseGame += DisableMouse;
        DisableMouse();
    }

    void LateUpdate()
    {
        // move = _input.Player.Move.ReadValue<Vector2>();
        // look = _input.Player.Look.ReadValue<Vector2>();
        // jump = _input.Player.Jump.ReadValue<bool>();
        // sprint = _input.Player.Sprint.ReadValue<bool>();
        // aim = _input.Player.Aim.ReadValue<bool>();
        // throw_bool = _input.Player.Throw.ReadValue<bool>();
        // pickup = _input.Player.PickUp.ReadValue<bool>();
        // jump = false;
        // sprint = false;
        // aim = false;
        // throw_bool = false;
        // pickup = false;
    }
     
    private void OnEnable()
    {
        _input.Enable();
    }
    private void OnDisable()
    {
        _input.Disable();
        _input.Player.Pause.performed -= context => PausePerformed() ;
        EventManagerSO.E_PauseGame -= EnableMouse;
        EventManagerSO.E_FinishedLoading -= DisableMouse;
        EventManagerSO.E_EndMatch -= EndMatchCleanup;
        EventManagerSO.E_UnpauseGame -= DisableMouse;
    }
    private void PausePerformed() {
        Debug.Log("Toggle Pause button clicked");
        GameManager.Instance.TogglePause();
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
        Debug.Log("Disabling mouse!");
        cursorInputForLook = true;
        SetCursorState(cursorInputForLook);
    }


    public void OnJump(InputValue value)
    {
        JumpInput(value.isPressed);
    }

    public void OnSprint(InputValue value)
    {
        SprintInput(value.isPressed);
    }

    public void OnAim(InputValue value)
    {
        AimInput(value.isPressed);
    }

    public void OnThrow(InputValue value)
    {	
        ThrowInput(value.isPressed);
    }

    public void OnPickUp(InputValue value)
    {
        PickUpInput(value.isPressed);
    }
    // public void OnSprint(InputValue value)
    // {
    //     SprintInput(value.isPressed);
    // }
    // public void OnSprint(InputValue value)
    // {
    //     SprintInput(value.isPressed);
    // }
    // public void OnSprint(InputValue value)
    // {
    //     SprintInput(value.isPressed);
    // }
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
    public void AimInput(bool newAimState)
    {
        aim = newAimState;
    }

    public void ThrowInput(bool newThrowState)
    {
        throw_bool = newThrowState;
    }

    public void PickUpInput(bool newPickUpState)
    {
        pickup = newPickUpState;
    }
    private void OnApplicationFocus(bool hasFocus)
    {
        Debug.Log("GameManager.Instance.currentState: "+GameManager.Instance.currentState);
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
