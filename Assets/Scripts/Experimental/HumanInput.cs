using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using UnityEngine.InputSystem;
using Mirror;


[RequireComponent(typeof(UnitController))]
[RequireComponent(typeof(PlayerInput))]
public class HumanInput : NetworkBehaviour
{
    private InputActions _inputActions;
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
        _inputActions = new InputActions();
        // _inputActions.Player.Pause.performed += context => PausePerformed();
        // _input.Player.Move.performed += context => MoveInput(context);
        EventManagerSO.E_PauseGame += EnableMouse;
        EventManagerSO.E_FinishedLoading += FinishedLoading;
        EventManagerSO.E_EndMatch += EndMatchCleanup;
        EventManagerSO.E_UnpauseGame += UnpauseGame;
        DisableMouse();
    }

    void Start()
    {
        unitController = GetComponent<UnitController>();
        unitController.input = newInput;
        newInput.moveRelative = true;
    }

    void Update()
    {
        //if (!hasAuthority) { return; }
        if (isLocalPlayer)
        {
            unitController.input = newInput;
        }
    }
     
    private void OnEnable()
    {
        _inputActions.Enable();
    }
    private void OnDisable()
    {
        EnableMouse();
        // _inputActions.Player.Pause.performed -= context => PausePerformed() ;
        EventManagerSO.E_PauseGame -= EnableMouse;
        EventManagerSO.E_FinishedLoading -= FinishedLoading;
        EventManagerSO.E_EndMatch -= EndMatchCleanup;
        EventManagerSO.E_UnpauseGame -= UnpauseGame;
        _inputActions.Disable();
    }
    private void PausePerformed() {
        Debug.Log("Toggle Pause button clicked");
        GameManager.Instance.TogglePause();
    }

    private void EndMatchCleanup(Team NA)
    {
        EnableMouse();
    }

    void FinishedLoading()
    {
        onFocusFix = false;
        if(GameManager.Instance.currentState == GameState.MainMenu){
           EnableMouse();
        } else {
            DisableMouse();
        }
    }

    void EnableMouse()
    {
        // cursorLocked = false;
        cursorInputForLook = false;
        SetCursorState(cursorInputForLook);
    }
    void UnpauseGame()
    {
        if(GameManager.Instance.currentState != GameState.MainMenu){
           DisableMouse();
        }
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

    public void OnBlock(InputValue value)
    {
        BlockInput(value.isPressed);
    }

    public void OnCrouch(InputValue value)
    {
        CrouchInput(value.isPressed);
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

    public void BlockInput(bool newBlockState)
    {
        newInput.block = newBlockState;
    }

    public void CrouchInput(bool newCrouchState)
    {
        newInput.crouch = newCrouchState;
    }

    bool onFocusFix = true;
    private void OnApplicationFocus(bool hasFocus)
    {
        // Debug.Log("GameManager.Instance.currentState: "+GameManager.Instance.currentState);
        if(onFocusFix || GameManager.Instance.currentState == GameState.MidMatch || GameManager.Instance.currentState == GameState.PreMatch){
            Debug.Log("locking cursor");
            SetCursorState(cursorLocked);
        }
        
    }

    private void SetCursorState(bool newState)
    {
        Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
    }

}
