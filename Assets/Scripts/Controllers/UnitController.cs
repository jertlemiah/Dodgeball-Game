using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public struct Input
{
    public bool sprint;
    public Vector2 move;
    public Vector2 look;
    public bool aim;
    public bool throw_bool;

	public bool pickup;
    public bool analogMovement;
    public bool jump;
    public bool cursorLocked;
    public bool cursorInputForLook;
}

// [RequireComponent(typeof(Rigidbody))]
// [RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(CharacterController))]
public class UnitController : MonoBehaviour
{
    public bool useMainCamera = false;
    [Header("_________Player__________________")]
    [Header("_________Player__________________")]
        [Tooltip("Sensitivity of player input to character output.")] 
        public float Sensitivity = 1f;

        [Tooltip("Move speed of the character in m/s")] 
        public float MoveSpeed = 2.0f;

        [Tooltip("Sprint speed of the character in m/s")] 
        public float SprintSpeed = 5.335f;

        [Tooltip("How fast the character turns to face movement direction")] 
        [Range(0.0f, 0.3f)] public float RotationSmoothTime = 0.12f;

        [Tooltip("Acceleration and deceleration")]
        public float SpeedChangeRate = 10.0f;


    [Space(10)]
    [Tooltip("The height the player can jump")]
    public float JumpHeight = 1.2f;
    [Tooltip("The character uses its own gravity value. The engine default is -9.81f")]
    public float Gravity = -15.0f;

    [Space(10)]
    [Tooltip("Time required to pass before being able to jump again. Set to 0f to instantly jump again")]
    public float JumpTimeout = 0.50f;
    [Tooltip("Time required to pass before entering the fall state. Useful for walking down stairs")]
    public float FallTimeout = 0.15f;

    [Header("Player Grounded")]
    [Tooltip("If the character is grounded or not. Not part of the CharacterController built in grounded check")]
    public bool Grounded = true;
    [Tooltip("Useful for rough ground")]
    public float GroundedOffset = -0.14f;
    [Tooltip("The radius of the grounded check. Should match the radius of the CharacterController")]
    public float GroundedRadius = 0.28f;
    [Tooltip("What layers the character uses as ground")]
    public bool canMove = true;
    public LayerMask GroundLayers;
    private Animator _animator;
	private CharacterController _controller;
    public int healthCurrent = 2;
    public int healthMax = 2;
    public bool hasBall = false;
    // Need to create a reference to the type of ball
    public GameObject heldBallGO;
    // Start is called before the first frame update
    public Team team = Team.Team1;
    public float DAMAGE_SPEED = 5; //  the minimum speed from which a ball will deal damage. This value needs to be elsewhere

    // player
    private float _speed;
    private float _animationBlend;
    private float _targetRotation = 0.0f;
    private float _rotationVelocity;
    private float _verticalVelocity;
    private float _terminalVelocity = 53.0f;
    private bool _rotateOnMove = true;

    // animation IDs
    private int _animIDSpeed;
    private int _animIDGrounded;
    private int _animIDJump;
    private int _animIDFreeFall;
    private int _animIDMotionSpeed;

    [Header("Cinemachine")]
    [Tooltip("The follow target set in the Cinemachine Virtual Camera that the camera will follow")]
    public GameObject CinemachineCameraTarget;
    [Tooltip("How far in degrees can you move the camera up")]
    public float TopClamp = 70.0f;
    [Tooltip("How far in degrees can you move the camera down")]
    public float BottomClamp = -30.0f;
    [Tooltip("Additional degress to override the camera. Useful for fine tuning camera position when locked")]
    public float CameraAngleOverride = 0.0f;
    [Tooltip("For locking the camera position on all axis")]
    public bool LockCameraPosition = false;
    

    private const float _threshold = 0.01f;

    public Input input;

    void Start()
    {
        healthCurrent = healthMax;
        _controller = GetComponent<CharacterController>();
        _hasAnimator = TryGetComponent(out _animator);
        AssignAnimationIDs();
        
        // reset our timeouts on start
        _jumpTimeoutDelta = JumpTimeout;
        _fallTimeoutDelta = FallTimeout;
    }

    // Update is called once per frame
    void Update()
    {
        JumpAndGravity();
        GroundedCheck();
        Move();
    }
    private void LateUpdate()
    {
        CameraRotation();
    }

    public void TakeDamage(int damage)
    {
        // This will need to be swapped out for the real system at some point
        if(team == Team.Team1)
        {
            // GameManager.Instance.GiveTeam2Points(1);
            EventManagerSO.TriggerEvent_GiveTeamPoints(Team.Team2,1);
        }
        else
        {
            // GameManager.Instance.GiveTeam1Points(1);
            EventManagerSO.TriggerEvent_GiveTeamPoints(Team.Team1,1);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ball") && collision.rigidbody.velocity.magnitude > DAMAGE_SPEED)
        {
            TakeDamage(1);
        }
    }

    private void AssignAnimationIDs()
    {
        _animIDSpeed = Animator.StringToHash("Speed");
        _animIDGrounded = Animator.StringToHash("Grounded");
        _animIDJump = Animator.StringToHash("Jump");
        _animIDFreeFall = Animator.StringToHash("FreeFall");
        _animIDMotionSpeed = Animator.StringToHash("MotionSpeed");
    }

    private void CameraRotation()
    {
        // if there is an input and camera position is not fixed
        if (input.look.sqrMagnitude >= _threshold && !LockCameraPosition)
        {
            _cinemachineTargetYaw += input.look.x * Time.deltaTime * Sensitivity;
            _cinemachineTargetPitch += input.look.y * Time.deltaTime * Sensitivity;
        }

        // clamp our rotations so our values are limited 360 degrees
        _cinemachineTargetYaw = ClampAngle(_cinemachineTargetYaw, float.MinValue, float.MaxValue);
        _cinemachineTargetPitch = ClampAngle(_cinemachineTargetPitch, BottomClamp, TopClamp);

        // Cinemachine will follow this target
        CinemachineCameraTarget.transform.rotation = Quaternion.Euler(_cinemachineTargetPitch + CameraAngleOverride, _cinemachineTargetYaw, 0.0f);
    }

    private void GroundedCheck()
    {
        // set sphere position, with offset
        Vector3 spherePosition = new Vector3(transform.position.x, transform.position.y - GroundedOffset, transform.position.z);
        Grounded = Physics.CheckSphere(spherePosition, GroundedRadius, GroundLayers, QueryTriggerInteraction.Ignore);

        // update animator if using character
        _animator.SetBool(_animIDGrounded, Grounded);
    }

    private static float ClampAngle(float lfAngle, float lfMin, float lfMax)
    {
        if (lfAngle < -360f) lfAngle += 360f;
        if (lfAngle > 360f) lfAngle -= 360f;
        return Mathf.Clamp(lfAngle, lfMin, lfMax);
    }

    // timeout deltatime
    private float _jumpTimeoutDelta;
    private float _fallTimeoutDelta;

    public Camera unitCamera;
    // cinemachine
    private float _cinemachineTargetYaw;
    private float _cinemachineTargetPitch;
    private bool _hasAnimator;


    private void Move()
    {
        // set target speed based on move speed, sprint speed and if sprint is pressed
        float targetSpeed = input.sprint ? SprintSpeed : MoveSpeed;

        // a simplistic acceleration and deceleration designed to be easy to remove, replace, or iterate upon

        // note: Vector2's == operator uses approximation so is not floating point error prone, and is cheaper than magnitude
        // if there is no input, set the target speed to 0
        if (input.move == Vector2.zero) targetSpeed = 0.0f;

        // a reference to the players current horizontal velocity
        float currentHorizontalSpeed = new Vector3(_controller.velocity.x, 0.0f, _controller.velocity.z).magnitude;

        float speedOffset = 0.1f;
        float inputMagnitude = input.analogMovement ? input.move.magnitude : 1f;

        // accelerate or decelerate to target speed
        if (currentHorizontalSpeed < targetSpeed - speedOffset || currentHorizontalSpeed > targetSpeed + speedOffset)
        {
            // creates curved result rather than a linear one giving a more organic speed change
            // note T in Lerp is clamped, so we don't need to clamp our speed
            _speed = Mathf.Lerp(currentHorizontalSpeed, targetSpeed * inputMagnitude, Time.deltaTime * SpeedChangeRate);

            // round speed to 3 decimal places
            _speed = Mathf.Round(_speed * 1000f) / 1000f;
        }
        else
        {
            _speed = targetSpeed;
        }
        _animationBlend = Mathf.Lerp(_animationBlend, targetSpeed, Time.deltaTime * SpeedChangeRate);

        // normalise input direction
        Vector3 inputDirection = new Vector3(input.move.x, 0.0f, input.move.y).normalized;

        // note: Vector2's != operator uses approximation so is not floating point error prone, and is cheaper than magnitude
        // if there is a move input rotate player when the player is moving
        if (input.move != Vector2.zero)
        {
            if(useMainCamera)
                _targetRotation = Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
            else
                _targetRotation = Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg + unitCamera.transform.eulerAngles.y;
            float rotation = Mathf.SmoothDampAngle(transform.eulerAngles.y, _targetRotation, ref _rotationVelocity, RotationSmoothTime);

            // rotate to face input direction relative to camera position
            if (_rotateOnMove)
            {
                transform.rotation = Quaternion.Euler(0.0f, rotation, 0.0f);
            }
        }


        Vector3 targetDirection = Quaternion.Euler(0.0f, _targetRotation, 0.0f) * Vector3.forward;

        // move the player
        if(canMove)
        {
            _controller.Move(targetDirection.normalized * (_speed * Time.deltaTime) + new Vector3(0.0f, _verticalVelocity, 0.0f) * Time.deltaTime);
        }

        // update animator if using character
        if (_hasAnimator)
        {
            _animator.SetFloat(_animIDSpeed, _animationBlend);
            _animator.SetFloat(_animIDMotionSpeed, inputMagnitude);
        }
    }
    private void JumpAndGravity()
    {
        if (Grounded)
        {
            // reset the fall timeout timer
            _fallTimeoutDelta = FallTimeout;

            // update animator if using character
            if (_hasAnimator)
            {
                _animator.SetBool(_animIDJump, false);
                _animator.SetBool(_animIDFreeFall, false);
            }

            // stop our velocity dropping infinitely when grounded
            if (_verticalVelocity < 0.0f)
            {
                _verticalVelocity = -2f;
            }

            // Jump
            if (input.jump && _jumpTimeoutDelta <= 0.0f)
            {
                // the square root of H * -2 * G = how much velocity needed to reach desired height
                _verticalVelocity = Mathf.Sqrt(JumpHeight * -2f * Gravity);

                // update animator if using character
                if (_hasAnimator)
                {
                    _animator.SetBool(_animIDJump, true);
                }
            }

            // jump timeout
            if (_jumpTimeoutDelta >= 0.0f)
            {
                _jumpTimeoutDelta -= Time.deltaTime;
            }
        }
        else
        {
            // reset the jump timeout timer
            _jumpTimeoutDelta = JumpTimeout;

            // fall timeout
            if (_fallTimeoutDelta >= 0.0f)
            {
                _fallTimeoutDelta -= Time.deltaTime;
            }
            else
            {
                // update animator if using character
                if (_hasAnimator)
                {
                    _animator.SetBool(_animIDFreeFall, true);
                }
            }

            // if we are not grounded, do not jump
            input.jump = false;
        }

        // apply gravity over time if under terminal (multiply by delta time twice to linearly speed up over time)
        if (_verticalVelocity < _terminalVelocity)
        {
            _verticalVelocity += Gravity * Time.deltaTime;
        }
    }

//     public void Move(Vector2 moveDir, bool sprint, Vector3 facingAngleEuler)
//     {
//         // set target speed based on move speed, sprint speed and if sprint is pressed
//         float targetSpeed = sprint ? SprintSpeed : MoveSpeed;

//         // a simplistic acceleration and deceleration designed to be easy to remove, replace, or iterate upon

//         // note: Vector2's == operator uses approximation so is not floating point error prone, and is cheaper than magnitude
//         // if there is no input, set the target speed to 0
//         if (moveDir == Vector2.zero) targetSpeed = 0.0f;

//         // a reference to the players current horizontal velocity
//         float currentHorizontalSpeed = new Vector3(_controller.velocity.x, 0.0f, _controller.velocity.z).magnitude;

//         float speedOffset = 0.1f;
//         // float inputMagnitude = _input.analogMovement ? _input.move.magnitude : 1f;
//         float inputMagnitude = 1f;

//         // accelerate or decelerate to target speed
//         if (currentHorizontalSpeed < targetSpeed - speedOffset || currentHorizontalSpeed > targetSpeed + speedOffset)
//         {
//             // creates curved result rather than a linear one giving a more organic speed change
//             // note T in Lerp is clamped, so we don't need to clamp our speed
//             _speed = Mathf.Lerp(currentHorizontalSpeed, targetSpeed * inputMagnitude, Time.deltaTime * SpeedChangeRate);

//             // round speed to 3 decimal places
//             _speed = Mathf.Round(_speed * 1000f) / 1000f;
//         }
//         else
//         {
//             _speed = targetSpeed;
//         }
//         _animationBlend = Mathf.Lerp(_animationBlend, targetSpeed, Time.deltaTime * SpeedChangeRate);

//         // normalise input direction
//         Vector3 inputDirection = new Vector3(moveDir.x, 0.0f, moveDir.y).normalized;

//         // note: Vector2's != operator uses approximation so is not floating point error prone, and is cheaper than magnitude
//         // if there is a move input rotate player when the player is moving
//         if (moveDir != Vector2.zero)
//         {
//             _targetRotation = Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg + facingAngleEuler.y;
//             float rotation = Mathf.SmoothDampAngle(transform.eulerAngles.y, _targetRotation, ref _rotationVelocity, RotationSmoothTime);

//             // rotate to face input direction relative to camera position
//             if (_rotateOnMove)
//             {
//                 transform.rotation = Quaternion.Euler(0.0f, rotation, 0.0f);
//             }
//         }


//         Vector3 targetDirection = Quaternion.Euler(0.0f, _targetRotation, 0.0f) * Vector3.forward;

//         // move the player
//         if(canMove)
//         {
//             _controller.Move(targetDirection.normalized * (_speed * Time.deltaTime) + new Vector3(0.0f, _verticalVelocity, 0.0f) * Time.deltaTime);
//         }

//         // update animator if using character
//         _animator.SetFloat(_animIDSpeed, _animationBlend);
//         _animator.SetFloat(_animIDMotionSpeed, inputMagnitude);

//     }

//     Vector3 m_GroundNormal;
//     float m_TurnAmount;
//     float m_ForwardAmount;
//     bool m_Crouching;
//     Vector3 m_CapsuleCenter;
//     CapsuleCollider m_Capsule;
//     Rigidbody m_Rigidbody;
//     float m_CapsuleHeight;
//     const float k_Half = 0.5f;
//     float m_OrigGroundCheckDistance;
//     [SerializeField] float m_GroundCheckDistance = 0.2f;
//     [SerializeField] float m_RunCycleLegOffset = 0.2f; //specific to the character in sample assets, will need to be modified to work with others
//     [SerializeField] float m_MoveSpeedMultiplier = 1f;
//     [SerializeField] float m_AnimSpeedMultiplier = 1f;
//     [Range(1f, 4f)][SerializeField] float m_GravityMultiplier = 2f;
//     [SerializeField] float m_MovingTurnSpeed = 360;
//     [SerializeField] float m_StationaryTurnSpeed = 180;
//     [SerializeField] float m_JumpPower = 6f;

//     public void Move(Vector3 move, bool crouch, bool jump)
//     {

//         // convert the world relative moveInput vector into a local-relative
//         // turn amount and forward amount required to head in the desired
//         // direction.
//         if (move.magnitude > 1f) move.Normalize();
//         move = transform.InverseTransformDirection(move);
//         CheckGroundStatus();
//         move = Vector3.ProjectOnPlane(move, m_GroundNormal);
//         m_TurnAmount = Mathf.Atan2(move.x, move.z);
//         m_ForwardAmount = move.z;

//         ApplyExtraTurnRotation();

//         // control and velocity handling is different when grounded and airborne:
//         if (Grounded)
//         {
//             HandleGroundedMovement(crouch, jump);
//         }
//         else
//         {
//             HandleAirborneMovement();
//         }

//         ScaleCapsuleForCrouching(crouch);
//         PreventStandingInLowHeadroom();

//         // send input and other state parameters to the animator
//         UpdateAnimator(move);
//     }


//     void ScaleCapsuleForCrouching(bool crouch)
//     {
//         if (Grounded && crouch)
//         {
//             if (m_Crouching) return;
//             m_Capsule.height = m_Capsule.height / 2f;
//             m_Capsule.center = m_Capsule.center / 2f;
//             m_Crouching = true;
//         }
//         else
//         {
//             Ray crouchRay = new Ray(m_Rigidbody.position + Vector3.up * m_Capsule.radius * k_Half, Vector3.up);
//             float crouchRayLength = m_CapsuleHeight - m_Capsule.radius * k_Half;
//             if (Physics.SphereCast(crouchRay, m_Capsule.radius * k_Half, crouchRayLength, Physics.AllLayers, QueryTriggerInteraction.Ignore))
//             {
//                 m_Crouching = true;
//                 return;
//             }
//             m_Capsule.height = m_CapsuleHeight;
//             m_Capsule.center = m_CapsuleCenter;
//             m_Crouching = false;
//         }
//     }

//     void PreventStandingInLowHeadroom()
//     {
//         // prevent standing up in crouch-only zones
//         if (!m_Crouching)
//         {
//             Ray crouchRay = new Ray(m_Rigidbody.position + Vector3.up * m_Capsule.radius * k_Half, Vector3.up);
//             float crouchRayLength = m_CapsuleHeight - m_Capsule.radius * k_Half;
//             if (Physics.SphereCast(crouchRay, m_Capsule.radius * k_Half, crouchRayLength, Physics.AllLayers, QueryTriggerInteraction.Ignore))
//             {
//                 m_Crouching = true;
//             }
//         }
//     }


//     void UpdateAnimator(Vector3 move)
//     {
//         // update the animator parameters
//         _animator.SetFloat("Forward", m_ForwardAmount, 0.1f, Time.deltaTime);
//         _animator.SetFloat("Turn", m_TurnAmount, 0.1f, Time.deltaTime);
//         _animator.SetBool("Crouch", m_Crouching);
//         _animator.SetBool("OnGround", Grounded);
//         if (!Grounded)
//         {
//             _animator.SetFloat("Jump", m_Rigidbody.velocity.y);
//         }

//         // calculate which leg is behind, so as to leave that leg trailing in the jump animation
//         // (This code is reliant on the specific run cycle offset in our animations,
//         // and assumes one leg passes the other at the normalized clip times of 0.0 and 0.5)
//         float runCycle =
//             Mathf.Repeat(
//                 _animator.GetCurrentAnimatorStateInfo(0).normalizedTime + m_RunCycleLegOffset, 1);
//         float jumpLeg = (runCycle < k_Half ? 1 : -1) * m_ForwardAmount;
//         if (Grounded)
//         {
//             _animator.SetFloat("JumpLeg", jumpLeg);
//         }

//         // the anim speed multiplier allows the overall speed of walking/running to be tweaked in the inspector,
//         // which affects the movement speed because of the root motion.
//         if (Grounded && move.magnitude > 0)
//         {
//             _animator.speed = m_AnimSpeedMultiplier;
//         }
//         else
//         {
//             // don't use that while airborne
//             _animator.speed = 1;
//         }
//     }


//     void HandleAirborneMovement()
//     {
//         // apply extra gravity from multiplier:
//         Vector3 extraGravityForce = (Physics.gravity * m_GravityMultiplier) - Physics.gravity;
//         m_Rigidbody.AddForce(extraGravityForce);

//         m_GroundCheckDistance = m_Rigidbody.velocity.y < 0 ? m_OrigGroundCheckDistance : 0.01f;
//     }


//     void HandleGroundedMovement(bool crouch, bool jump)
//     {
//         // check whether conditions are right to allow a jump:
//         if (jump && !crouch && _animator.GetCurrentAnimatorStateInfo(0).IsName("Grounded"))
//         {
//             // jump!
//             m_Rigidbody.velocity = new Vector3(m_Rigidbody.velocity.x, m_JumpPower, m_Rigidbody.velocity.z);
//             Grounded = false;
//             _animator.applyRootMotion = false;
//             m_GroundCheckDistance = 0.1f;
//         }
//     }

//     void ApplyExtraTurnRotation()
//     {
//         // help the character turn faster (this is in addition to root rotation in the animation)
//         float turnSpeed = Mathf.Lerp(m_StationaryTurnSpeed, m_MovingTurnSpeed, m_ForwardAmount);
//         transform.Rotate(0, m_TurnAmount * turnSpeed * Time.deltaTime, 0);
//     }


//     public void OnAnimatorMove()
//     {
//         // we implement this function to override the default root motion.
//         // this allows us to modify the positional speed before it's applied.
//         if (Grounded && Time.deltaTime > 0)
//         {
//             Vector3 v = (_animator.deltaPosition * m_MoveSpeedMultiplier) / Time.deltaTime;

//             // we preserve the existing y part of the current velocity.
//             v.y = m_Rigidbody.velocity.y;
//             m_Rigidbody.velocity = v;
//         }
//     }


//     void CheckGroundStatus()
//     {
//         RaycastHit hitInfo;
// #if UNITY_EDITOR
//         // helper to visualise the ground check ray in the scene view
//         Debug.DrawLine(transform.position + (Vector3.up * 0.1f), transform.position + (Vector3.up * 0.1f) + (Vector3.down * m_GroundCheckDistance));
// #endif
//         // 0.1f is a small offset to start the ray from inside the character
//         // it is also good to note that the transform position in the sample assets is at the base of the character
//         if (Physics.Raycast(transform.position + (Vector3.up * 0.1f), Vector3.down, out hitInfo, m_GroundCheckDistance))
//         {
//             m_GroundNormal = hitInfo.normal;
//             Grounded = true;
//             _animator.applyRootMotion = true;
//         }
//         else
//         {
//             Grounded = false;
//             m_GroundNormal = Vector3.up;
//             _animator.applyRootMotion = false;
//         }
//     }
//     public void Jump()
//     {

//     }
//     public void Throw(Vector3 direction)
//     {

//     }
}
