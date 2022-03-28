using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using UnityEngine.InputSystem;
[RequireComponent(typeof(UnitController))]
[RequireComponent(typeof(PlayerInput))]
public class HumanInput : MonoBehaviour
{
    private InputActions _input;
    UnitController unitController;

    [Header("Character Input Values")]
        [SerializeField] Input newInput = new Input();

    [Header("Movement Settings")]
        public bool analogMovement;
    
    [Header("Mouse Cursor Settings")]
        public bool cursorLocked = true;
        public bool cursorInputForLook = true;
    void Awake()
    {
        _input = new InputActions();
        // _input.Player.Pause.performed += context => PausePerformed();
        // _input.Player.Move.performed += context => MoveInput(context);
        EventManagerSO.E_PauseGame += EnableMouse;
        EventManagerSO.E_FinishedLoading += DisableMouse;
        EventManagerSO.E_EndMatch += EndMatchCleanup;
        EventManagerSO.E_UnpauseGame += DisableMouse;
        DisableMouse();
    }

    void Start()
    {
        unitController = GetComponent<UnitController>();
        unitController.input = newInput;
    }

    void Update()
    {
        unitController.input = newInput;
    }
     
    private void OnEnable()
    {
        _input.Enable();
    }
    private void OnDisable()
    {
        _input.Disable();
        // _input.Player.Pause.performed -= context => PausePerformed() ;
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

    public void OnPause(InputValue value)
    {
        PausePerformed();
    }

    public void MoveInput(Vector2 newMoveDirection)
    {
        // move = newMoveDirection;
        newInput.move = newMoveDirection;
    } 

    public void LookInput(Vector2 newLookDirection)
    {
        // look = newLookDirection;
        newInput.look = newLookDirection;
    }

    public void JumpInput(bool newJumpState)
    {
        // jump = newJumpState;
        newInput.jump = newJumpState;
    }

    public void SprintInput(bool newSprintState)
    {
        // sprint = newSprintState;
        newInput.sprint = newSprintState;
    }
    public void AimInput(bool newAimState)
    {
        // aim = newAimState;
        newInput.aim = newAimState;
    }

    public void ThrowInput(bool newThrowState)
    {
        // throw_bool = newThrowState;
        newInput.throw_bool = newThrowState;
    }

    public void PickUpInput(bool newPickUpState)
    {
        // pickup = newPickUpState;
        newInput.pickup = newPickUpState;
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
