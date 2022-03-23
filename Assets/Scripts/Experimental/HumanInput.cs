using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using UnityEngine.InputSystem;
public class HumanInput : MonoBehaviour
{
    [SerializeField] Input newInput = new Input();
    private InputActions _input;
    UnitController unitController;

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

    void Start()
    {
        unitController = GetComponent<UnitController>();
        unitController.input = newInput;
    }

    void Update()
    {
        // newInput.sprint = sprint;
        // newInput.move = move;
        // newInput.look = look;
        // newInput.aim = aim;
        // newInput.throw_bool = throw_bool;
        // newInput.pickup = pickup;
        // newInput.analogMovement = _input.analogMovement;
        // newInput.jump = _input.jump;
        // newInput.cursorLocked = _input.cursorLocked;
        // newInput.cursorInputForLook = _input.cursorInputForLook; 
        
        // unitController.input = newInput;
        unitController.input = newInput;
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

    public void MoveInput(Vector2 newMoveDirection)
    {
        move = newMoveDirection;
        newInput.move = newMoveDirection;
    } 

    public void LookInput(Vector2 newLookDirection)
    {
        look = newLookDirection;
        newInput.look = newLookDirection;
    }

    public void JumpInput(bool newJumpState)
    {
        jump = newJumpState;
        newInput.jump = newJumpState;
    }

    public void SprintInput(bool newSprintState)
    {
        sprint = newSprintState;
        newInput.sprint = newSprintState;
    }
    public void AimInput(bool newAimState)
    {
        aim = newAimState;
        newInput.aim = newAimState;
    }

    public void ThrowInput(bool newThrowState)
    {
        throw_bool = newThrowState;
        newInput.throw_bool = newThrowState;
    }

    public void PickUpInput(bool newPickUpState)
    {
        pickup = newPickUpState;
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
    
    // UnitController unitController;
    // [SerializeField] InputManager _input;
    // // StarterAssetsInputs _input;
    // [SerializeField] Input newInput = new Input();
    // // Start is called before the first frame update
    // void Start()
    // {
    //     unitController = GetComponent<UnitController>();
    //     // _input = GetComponent<InputManager>();
    //     _input = InputManager.Instance;
    //     // _input = GetComponent<StarterAssetsInputs>();
    // }

    // // Update is called once per frame
    // void Update()
    // {
    //     // Input newInput = new Input();
    //     newInput.sprint = _input.sprint;
    //     newInput.move = _input.move;
    //     newInput.look = _input.look;
    //     newInput.aim = _input.aim;
    //     newInput.throw_bool = _input.throw_bool;
    //     newInput.pickup = _input.pickup;
    //     newInput.analogMovement = _input.analogMovement;
    //     newInput.jump = _input.jump;
    //     newInput.cursorLocked = _input.cursorLocked;
    //     newInput.cursorInputForLook = _input.cursorInputForLook; 
        
    //     unitController.input = newInput;
        
    //     // // set target speed based on move speed, sprint speed and if sprint is pressed
    //     // float targetSpeed = _input.sprint ? SprintSpeed : MoveSpeed;

    //     // // note: Vector2's == operator uses approximation so is not floating point error prone, and is cheaper than magnitude
    //     // // if there is no input, set the target speed to 0
    //     // if (_input.move == Vector2.zero) targetSpeed = 0.0f;

    //     // // a reference to the players current horizontal velocity
    //     // float currentHorizontalSpeed = new Vector3(_controller.velocity.x, 0.0f, _controller.velocity.z).magnitude;

    //     // float speedOffset = 0.1f;
    //     // float inputMagnitude = _input.analogMovement ? _input.move.magnitude : 1f;

    //     // // accelerate or decelerate to target speed
    //     // if (currentHorizontalSpeed < targetSpeed - speedOffset || currentHorizontalSpeed > targetSpeed + speedOffset)
    //     // {
    //     //     // creates curved result rather than a linear one giving a more organic speed change
    //     //     // note T in Lerp is clamped, so we don't need to clamp our speed
    //     //     _speed = Mathf.Lerp(currentHorizontalSpeed, targetSpeed * inputMagnitude, Time.deltaTime * SpeedChangeRate);

    //     //     // round speed to 3 decimal places
    //     //     _speed = Mathf.Round(_speed * 1000f) / 1000f;
    //     // }
    //     // else
    //     // {
    //     //     _speed = targetSpeed;
    //     // }
    //     // _animationBlend = Mathf.Lerp(_animationBlend, targetSpeed, Time.deltaTime * SpeedChangeRate);

    //     // // normalise input direction
    //     // Vector3 inputDirection = new Vector3(_input.move.x, 0.0f, _input.move.y).normalized;

    //     // // note: Vector2's != operator uses approximation so is not floating point error prone, and is cheaper than magnitude
    //     // // if there is a move input rotate player when the player is moving
    //     // if (_input.move != Vector2.zero)
    //     // {
    //     //     _targetRotation = Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg + _mainCamera.transform.eulerAngles.y;
    //     //     float rotation = Mathf.SmoothDampAngle(transform.eulerAngles.y, _targetRotation, ref _rotationVelocity, RotationSmoothTime);

    //     //     // rotate to face input direction relative to camera position
    //     //     if (_rotateOnMove)
    //     //     {
    //     //         transform.rotation = Quaternion.Euler(0.0f, rotation, 0.0f);
    //     //     }
    //     // }


    //     // Vector3 targetDirection = Quaternion.Euler(0.0f, _targetRotation, 0.0f) * Vector3.forward;

    //     // // // move the player
    //     // // if(canMove)
    //     // // {
    //     // //     _controller.Move(targetDirection.normalized * (_speed * Time.deltaTime) + new Vector3(0.0f, _verticalVelocity, 0.0f) * Time.deltaTime);
    //     // // }

    //     // // // update animator if using character
    //     // // if (_hasAnimator)
    //     // // {
    //     // //     _animator.SetFloat(_animIDSpeed, _animationBlend);
    //     // //     _animator.SetFloat(_animIDMotionSpeed, inputMagnitude);
    //     // // }

    //     // unitController.Move()
    // }
}
