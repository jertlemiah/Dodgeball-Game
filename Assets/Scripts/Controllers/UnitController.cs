using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Cinemachine;

[Serializable]
public struct Input
{
    public bool sprint;
    public Vector2 move;
    public bool moveRelative; //Humans supply input relative to a camera, but bots supply a global direction
    public Vector2 look;
    public bool aim;
    public bool throw_bool;

	public bool pickup;
    public bool analogMovement;
    public bool jump;
    public bool cursorLocked;
    public bool cursorInputForLook;

    public bool block;

    public bool crouch;
}

// [RequireComponent(typeof(Rigidbody))]
// [RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(AimIK))]
[RequireComponent(typeof(CharacterController))]
public class UnitController : MonoBehaviour
{
    public string playerName = "";
    [Header("               Controller Input")]
        [Tooltip("The currently supplied input for the controller")] 
        public Input input;
    
    [Header("               Controller Settings")][Space(15)]
        [Tooltip("Setting this to false will stop the player from moving")] 
        public bool canMove = true;

        [Tooltip("Sensitivity of player input to character output.")] 
        public float Sensitivity = 1f;

        [Tooltip("Current direction vector of the character")] 
        public Vector3 direction;

        [Tooltip("Current move speed of the character in m/s")] 
        public float MoveSpeed = 5.0f;

        [Tooltip("Normal speed of the character in m/s")] 
        public float NormalSpeed = 5.0f;

        [Tooltip("Sprint speed of the character in m/s")] 
        public float SprintSpeed = 8.0f;

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


    [Header("           Player Grounded")][Space(15)]
        [Tooltip("If the character is grounded or not. Not part of the CharacterController built in grounded check")]
        public bool Grounded = true;

        [Tooltip("Useful for rough ground")]
        public float GroundedOffset = -0.14f;

        [Tooltip("The radius of the grounded check. Should match the radius of the CharacterController")]
        public float GroundedRadius = 0.28f;

        [Tooltip("What layers the character uses as ground")]
        public LayerMask GroundLayers;

    [Header("           Cinemachine")][Space(15)]
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

        [Tooltip("Will snap player controls to the mainCamera instead of it's own local camera")]
        public bool useMainCamera = false;

        [Tooltip("The controller's local camera")]
        public Camera unitCamera;


    [Header("           Player Attributes")][Space(15)]
        [Tooltip("The health the player will start with each time he respawns.")]
        public float healthMax = 4.0f;

        [Tooltip("The current health of the player set at runtime")]
        public float healthCurrent = 4.0f;

        public Team team = Team.Team1;        
        public float DAMAGE_SPEED = 5; //  the minimum speed from which a ball will deal damage. This value needs to be elsewhere

    [Header("           Shooter Settings")][Space(15)]
        [SerializeField] string ballHoldSpotName = "BallHoldSpot";
        [SerializeField] private GameObject handSpot;
        [SerializeField] private CinemachineVirtualCamera aimVirtualCamera;
        [SerializeField] private float normalSensitivity = 2;
        [SerializeField] private float aimSensitivity = 0.5f;
        [SerializeField] private LayerMask aimColliderLayerMask;
        public Transform overrideTargetTransform;

        
        [SerializeField] private Transform debugTransform;

        [SerializeField] private float block_cooldown = 3;
        [SerializeField] private float block_time = 2;

        [SerializeField] private float crouch_cooldown = 2;

        public bool hasBall = false;
        public GameObject heldBallGO;
        AimIK aimIK => GetComponent<AimIK>();

        [SerializeField] string flagHoldSpotName = "FlagHoldSpot";
        [SerializeField] public GameObject flagSpot;
        public bool hasFlag = false;

    private float last_block_time;
    private bool canBlock = true;
    private bool isBlocking = false;
    private float block_start_time ;
    private Renderer blocker_renderer;

    private bool canCrouch = true;

    private bool isCrouching = false;

    private float last_crouch_time;  

    private HudController hudController;

    // player
    private float _speed;
    private float _animationBlend;
    private float _targetRotation = 0.0f;
    private float _rotationVelocity;
    private float _verticalVelocity;
    private float _terminalVelocity = 53.0f;
    private bool _rotateOnMove = true;
    private const float _threshold = 0.01f;
    private bool _hasAnimator;
    private Animator _animator;
	private CharacterController _controller;

    private bool isHuman = false; //false out of fear

    // animation IDs
    private int _animIDSpeed;
    private int _animIDGrounded;
    private int _animIDJump;
    private int _animIDFreeFall;
    private int _animIDMotionSpeed;   

    // timeout deltatime
    private float _jumpTimeoutDelta;
    private float _fallTimeoutDelta;

    
    // cinemachine
    private float _cinemachineTargetYaw;
    private float _cinemachineTargetPitch;
    
    public PickUpZoneController pickUpZoneController;
    private Vector3 mouseWorldPosition;

    private GameObject powerup;
    public GameObject player;
    private SpawnManager spawnManager;
    private HudController hc;

    private HealthbarController healthbarController;

    //variables for changing collider when crouching 
    private Vector3 standCenter = new Vector3(0, 0.96f, 0);
    private float standHeight = 1.8f;
    private Vector3 crouchCenter = new Vector3(0, 0.66f, 0);
    private float crouchHeight = 1.2f;

    private bool crouchStarted = false;
    private bool lowerCollider = true;
    private float crouch_start_time;

    void Awake()
    {
        EventManagerSO.E_LoadingProgress += StopMovement;
        EventManagerSO.E_StartMatch += AllowMovement;
    }

    void OnDisable()
    {
        EventManagerSO.E_LoadingProgress -= StopMovement;
        EventManagerSO.E_StartMatch -= AllowMovement;
    }

    void Start()
    {
        // canMove = false;
        isHuman =  GetComponentsInChildren<HumanInput>().Length > 0;
        spawnManager = SpawnManager.Instance;
        hc = HudController.Instance;
        _controller = GetComponent<CharacterController>();
        _hasAnimator = TryGetComponent(out _animator);
        AssignAnimationIDs();
        healthCurrent = healthMax;
        
        // reset our timeouts on start
        _jumpTimeoutDelta = JumpTimeout;
        _fallTimeoutDelta = FallTimeout;

        pickUpZoneController = GetComponentInChildren<PickUpZoneController>();
        // GameObject Blocker = GameObject.Find("Blocker");
        blocker_renderer = GetComponentInChildren<BlockerController>().gameObject.GetComponent<Renderer>();
        blocker_renderer.enabled = false;

        // hudController = GameObject.FindWithTag("HUD").GetComponent<HudController>();
        hudController = HudController.Instance;

        if(handSpot == null) {
            handSpot = transform.Find(ballHoldSpotName).gameObject;
            if(handSpot == null)
                UnityEngine.Debug.LogError(gameObject.name+" does not have its handSpot game object set, and could not find one in children.");
        }
        if(flagSpot == null) {
            flagSpot = transform.Find(flagHoldSpotName).gameObject;
            if(flagSpot == null)
                UnityEngine.Debug.LogError(gameObject.name+" does not have its flagSpot game object set, and could not find one in children.");
        }
        if(aimVirtualCamera == null) {
            UnityEngine.Debug.LogError(gameObject.name+" does not have its virtual Cinemachine aim camera set.");
        }
        if(aimColliderLayerMask != LayerMask.GetMask("Map")){
            UnityEngine.Debug.LogWarning(gameObject.name+" has its aim layermask not set to map only. Be careful changing this mask.");
        }
        if(aimIK.humanBones.Length == 0){
            UnityEngine.Debug.LogWarning(gameObject.name+" does not have its aimIK bones set properly. Set at least one bone with a weight (i.e. Spine to 0.2)");
        }
        if(isHuman) {
            // healthBar = GameObject.Find("Health").GetComponent<SimpleHealthBar>();
            // hudController.SetMaxHealth(healthMax);
            EventManagerSO.TriggerEvent_UpdateHealthbar(healthMax, true);
        } 
        else
        {
            healthbarController = GetComponentInChildren<HealthbarController>();
        }
        if (playerName == "") {
            playerName = gameObject.name;
        }
    }

    void Update()
    {
        handleCharacterDead();
        JumpAndGravity();
        GroundedCheck();
        Move();
        PickupBall();
        AimAndThrow();
        Block();
        Crouch();
        CrouchCollider();
    }
    private void LateUpdate()
    {
        CameraRotation();
    }

    [SerializeField] Transform aimSpot;

    void AimAndThrow()
    {
        // Find the new Mouse World Position to use for aiming
        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = unitCamera.ScreenPointToRay(screenCenterPoint);
        if(!input.moveRelative){
            mouseWorldPosition = overrideTargetTransform.position;      
        } 
        // else if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimColliderLayerMask))
        else
        {
            //debugTransform.position = raycastHit.point;
            // mouseWorldPosition = raycastHit.point;
            float distToPlayer = (unitCamera.transform.position - player.transform.position).magnitude;
            
            mouseWorldPosition = unitCamera.transform.position + ray.direction * distToPlayer*2;
            aimSpot.transform.position = mouseWorldPosition;
            // mouseWorldPosition = aimSpot.position;
        }

        // If holding a ball &
        if(input.aim && hasBall)
        {   
            aimIK.enableIK = true;
            aimIK.overrideTarget = true;
            aimIK.targetOverridePosition = mouseWorldPosition;
            _animator.SetBool("Aim", true);
            aimVirtualCamera.gameObject.SetActive(true);
            Sensitivity = aimSensitivity;
            _rotateOnMove = false;


            Vector3 worldAimTarget =  new Vector3(mouseWorldPosition.x, transform.position.y, mouseWorldPosition.z);
            Vector3 aimDirection = (worldAimTarget - transform.position);
            transform.forward = Vector3.Lerp(transform.forward, aimDirection, Time.deltaTime * 20f);
             
            if(input.throw_bool){
                _animator.SetBool("Throw", true);
                // hasBall = false;  
                //rb.constraints = RigidbodyConstraints.None;
            }
           
        }
        else{
            aimIK.enableIK = false;
            aimIK.overrideTarget = false;
            _animator.SetBool("Aim", false);
            aimVirtualCamera.gameObject.SetActive(false);
            Sensitivity = normalSensitivity;
            _rotateOnMove = true;
        }
    }

    void Block()
    {   
        if(!canBlock)
        {
            float elapsed_time = Time.time - last_block_time;
            if(elapsed_time >= block_cooldown){
                canBlock = true;
                UnityEngine.Debug.Log("can block again");
            }
        }

        // if(canBlock && input.block && pickUpZoneController.hasBall)
        if(canBlock && input.block && hasBall)
        {
            if(isBlocking){
                float elapsed_time = Time.time - block_start_time;
                if(elapsed_time >= block_time){
                    if(isHuman) hudController.BlockCooldown(block_cooldown);
                    _animator.SetBool("Block", false);
                    isBlocking = false;
                    canBlock = false;
                    last_block_time = Time.time;
                    blocker_renderer.enabled = false;
                }
            }
            else{
                _animator.SetBool("Block", true);
                isBlocking = true;
                block_start_time = Time.time;
                blocker_renderer.enabled = true;
            }
        }
        else if(isBlocking){
            if(isHuman) hudController.BlockCooldown(block_cooldown);
            _animator.SetBool("Block", false);
            isBlocking = false;
            canBlock = false;
            last_block_time = Time.time;
            blocker_renderer.enabled = false;
        }
    }

    void Crouch()
    {   
        if(!canCrouch)
        {
            float elapsed_time = Time.time - last_crouch_time;
            if(elapsed_time >= crouch_cooldown){
                canCrouch = true;
                UnityEngine.Debug.Log("Can crouch again");
            }
        }
        if(input.crouch && canCrouch && !isCrouching)
        {   
            crouchStarted = true;
            crouch_start_time = Time.time;
            if(isHuman) hudController.CrouchCooldown(crouch_cooldown);
            if(input.move == Vector2.zero){
                _animator.SetBool("Crouch", true);
                isCrouching = true;
            }
            else{
                _animator.SetTrigger("Slide");
                canCrouch = false;
                last_crouch_time = Time.time;
            }
            
        }
        
    }

    void CrouchCollider()
    {
        if(crouchStarted){
            float elapsed_time = Time.time - crouch_start_time;
            if(elapsed_time > 0.2 && lowerCollider){
                _controller.center = crouchCenter;
                _controller.height = crouchHeight;
                lowerCollider = false;
            }
            else if(elapsed_time > 0.8){
                _controller.center = standCenter;
                _controller.height = standHeight;
                crouchStarted = false;
                lowerCollider = true;
            }
        }
    }

    void PickupBall()
    {
        if(pickUpZoneController.ballNear && input.pickup && Grounded && !hasBall)
        {
            pickUpZoneController.closestDodgeball.hasOwner = true;
            pickUpZoneController.ballNear = false;
            // GameManager.Instance.TEMP_TurnOnBallHUD(); 
            // hasBall = true;  
            // heldBallGO = pickUpZoneController.ball.transform.parent.gameObject;
            heldBallGO = pickUpZoneController.closestDodgeball.gameObject;
            _animator.SetBool("PickUp", true);
            canMove = false;
            if(isHuman){
                EventManagerSO.TriggerEvent_PickUpText(false); 
                
            }
            
        }

        if(_animator.GetBool("PickUp"))
        {
            transform.forward = heldBallGO.transform.position-transform.position;
            // hasBall = true;
        }
    }

    // public void Capture

    void AnimTrigger_Throw()
    {
        heldBallGO.transform.parent = null;
        Rigidbody ballRb = heldBallGO.GetComponent<Rigidbody>();
        ballRb.isKinematic = false;
        ballRb.velocity = Vector3.zero;
        ballRb.angularVelocity = Vector3.zero;

        Vector3 throw_direction = (mouseWorldPosition - heldBallGO.transform.position).normalized;
        float throw_speed = heldBallGO.GetComponent<DodgeballController>().velocity;
        UnityEngine.Debug.Log(heldBallGO.name);
        UnityEngine.Debug.Log("The ball was thrown with a velocity of " + throw_speed);
        ballRb.AddForce(throw_direction*throw_speed*100f);
        hasBall = false;
        _animator.SetBool("Throw", false);

        heldBallGO.GetComponent<DodgeballController>().hasOwner = false;
        heldBallGO.GetComponent<DodgeballController>().isThrown = true; // the ball can now cause damage on collision
        heldBallGO.GetComponent<DodgeballController>().thrownBy = this.gameObject; // to let the dodgeball know not to damage the person who threw it on exit from hand
        heldBallGO = null;
        if(isHuman){
            EventManagerSO.TriggerEvent_BallPickup(DodgeballType.none);
        }
        
    }

    void AnimTrigger_Pickup()
    {
        // heldBallGO = pickUpZoneController.ball.transform.parent.gameObject;
        heldBallGO.transform.parent = handSpot.transform;
        heldBallGO.transform.localPosition = Vector3.zero;
        heldBallGO.transform.localRotation = Quaternion.identity;
        

        Rigidbody ballRb = heldBallGO.GetComponent<Rigidbody>();
        ballRb.isKinematic = true;

        
        // foundBall = false;

        _animator.SetBool("PickUp", false);
        hasBall = true;
        canMove = true;
        if(isHuman){
            EventManagerSO.TriggerEvent_BallPickup(heldBallGO.GetComponent<DodgeballController>().dodgeballType);
        }
    }

    void AnimTrigger_Crouch()
    {
        _animator.SetBool("Crouch", false);
        canCrouch = false;
        isCrouching = false;
        last_crouch_time = Time.time;
    } 

    void OnCollisionEnter(Collision collision)
    {

    }

    private void AssignAnimationIDs()
    {
        _animIDSpeed = Animator.StringToHash("Speed");
        _animIDGrounded = Animator.StringToHash("Grounded");
        _animIDJump = Animator.StringToHash("Jump");
        _animIDFreeFall = Animator.StringToHash("FreeFall");
        _animIDMotionSpeed = Animator.StringToHash("MotionSpeed");
    }

    public void KillPlayer()
    {
        healthCurrent = 0;
    }

    public void TakeDamage(float damage)
    {
        if (healthCurrent - damage < 0) {
            healthCurrent = 0;
            if(isHuman) {
                // hudController.SetHealth(healthCurrent);
                EventManagerSO.TriggerEvent_UpdateHealthbar(healthCurrent, false);
            }
            else
            {
                UnityEngine.Debug.Log("Taking Damage");
                healthbarController.SetHealth(healthCurrent);

            }
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
        } else {
            UnityEngine.Debug.Log("Took Damage");
            healthCurrent -= damage;
            if(isHuman) {
                // hudController.SetHealth(healthCurrent);
                EventManagerSO.TriggerEvent_UpdateHealthbar(healthCurrent, false);
            }
            else
            {
                healthbarController.SetHealth(healthCurrent);
            }
        }
        
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

    private void Move()
    {
        direction = _controller.velocity;
        // set target speed based on move speed, sprint speed and if sprint is pressed
        MoveSpeed = input.sprint ? SprintSpeed : NormalSpeed;
        if(!Grounded) {MoveSpeed = NormalSpeed;}

        // a simplistic acceleration and deceleration designed to be easy to remove, replace, or iterate upon

        // note: Vector2's == operator uses approximation so is not floating point error prone, and is cheaper than magnitude
        // if there is no input, set the target speed to 0
        if (input.move == Vector2.zero) MoveSpeed = 0.0f;

        // a reference to the players current horizontal velocity
        float currentHorizontalSpeed = new Vector3(_controller.velocity.x, 0.0f, _controller.velocity.z).magnitude;

        float speedOffset = 0.1f;
        float inputMagnitude = input.analogMovement ? input.move.magnitude : 1f;

        // accelerate or decelerate to target speed
        if (currentHorizontalSpeed < MoveSpeed - speedOffset || currentHorizontalSpeed > MoveSpeed + speedOffset)
        {
            // creates curved result rather than a linear one giving a more organic speed change
            // note T in Lerp is clamped, so we don't need to clamp our speed
            _speed = Mathf.Lerp(currentHorizontalSpeed, MoveSpeed * inputMagnitude, Time.deltaTime * SpeedChangeRate);

            // round speed to 3 decimal places
            _speed = Mathf.Round(_speed * 1000f) / 1000f;
        }
        else
        {
            _speed = MoveSpeed;
        }
        _animationBlend = Mathf.Lerp(_animationBlend, MoveSpeed, Time.deltaTime * SpeedChangeRate);

        // normalise input direction
        Vector3 inputDirection = new Vector3(input.move.x, 0.0f, input.move.y).normalized;

        // note: Vector2's != operator uses approximation so is not floating point error prone, and is cheaper than magnitude
        // if there is a move input rotate player when the player is moving
        if (input.move != Vector2.zero)
        {
            if(!input.moveRelative){
                _targetRotation = Mathf.Atan2(inputDirection.x, inputDirection.z)* Mathf.Rad2Deg;
            }
            else if(useMainCamera)
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

    public void AddPowerup(GameObject newPowerup)
    {
        powerup = newPowerup;
        if (powerup.name.Contains("Health")) {
            UnityEngine.Debug.Log("Picked up Health");
            healthCurrent += 1.0f;
            if (healthCurrent > healthMax) {
                healthCurrent = healthMax;
            }
            if(isHuman) {
                // hudController.SetHealth(healthCurrent);
                EventManagerSO.TriggerEvent_UpdateHealthbar(healthCurrent, false);
            }
            else
            {
                healthbarController.SetHealth(healthCurrent);
            }
            powerup = null;
        } else if (powerup.name.Contains("Armor")) {
            UnityEngine.Debug.Log("Picked up Armor");
            healthMax += 2.0f;
            healthCurrent += 2.0f;
            if(isHuman) {
                // hudController.SetMaxHealth(healthMax);
                // hudController.SetHealth(healthCurrent);
                EventManagerSO.TriggerEvent_UpdateHealthbar(healthMax, true);
                EventManagerSO.TriggerEvent_UpdateHealthbar(healthCurrent, false);
            }
            else
            {
                healthbarController.SetMaxHealth(healthMax);
                healthbarController.SetHealth(healthCurrent);
            }
            StartCoroutine(CountdownArmor());
        } else if (powerup.name.Contains("Speed")) {
            UnityEngine.Debug.Log("Picked up Speed");
            NormalSpeed = NormalSpeed * 1.5f;
            SprintSpeed = SprintSpeed * 1.5f;
            StartCoroutine(CountdownSpeed());
        }
        UnityEngine.Debug.Log("Player just collected new powerup: " + powerup);
    }

    IEnumerator CountdownArmor()
    {
        yield return new WaitForSeconds(30f);
        healthMax -= 2.0f;
        if (healthCurrent > healthMax) {
            healthCurrent = healthMax;
        }
        if(isHuman) {
            // hudController.SetMaxHealth(healthMax);
            // hudController.SetHealth(healthCurrent);
            EventManagerSO.TriggerEvent_UpdateHealthbar(healthMax, true);
            EventManagerSO.TriggerEvent_UpdateHealthbar(healthCurrent, false);
        }
        else
        {
            healthbarController.SetMaxHealth(healthMax);
            healthbarController.SetHealth(healthCurrent);
        }
        powerup = null;
    }

    IEnumerator CountdownSpeed()
    {
        yield return new WaitForSeconds(15f);
        NormalSpeed = NormalSpeed/1.5f;
        SprintSpeed = SprintSpeed/1.5f;
        powerup = null;
    }
    
    IEnumerator CountdownDeath()
    {
        UnityEngine.Debug.Log("CountdownDeath");
        yield return new WaitForSeconds(5f);
        if (player.GetComponent<CharacterController>() != null)
        {
            _animator.enabled = true;
            player.GetComponent<CharacterController>().enabled = true;
        }
    }

    private void handleCharacterDead() {
        if (healthCurrent <= 0) {
            if (player.GetComponent<CharacterController>() != null)
            {
                player.GetComponent<CharacterController>().enabled = false;
            }
            _animator.enabled = false;
            
            FlagController flagController = GetComponentInChildren<FlagController>();
            UnityEngine.Debug.Log("Found flag? "+flagController!=null);
            if(flagController){
                // flagController.FlagReturned();
                flagController.FlagDropped();
            }
            
            var spawnPoint = spawnManager.GetSpawnLocation(player.transform.position);
            UnityEngine.Debug.Log("spawnPoint" + spawnPoint);
            player.transform.position = spawnPoint;
            healthMax = 4;
            healthCurrent = 4;
            StartCoroutine(CountdownDeath());
            if (isHuman) {
                hc.HandleRespawn(5f);
                // hudController.SetMaxHealth(healthMax);
                // hudController.SetHealth(healthCurrent);
                EventManagerSO.TriggerEvent_UpdateHealthbar(healthMax, true);
                EventManagerSO.TriggerEvent_UpdateHealthbar(healthCurrent, false);
                EventManagerSO.TriggerEvent_DeathNotification(team, "You","an enemy");
            } else {
                healthbarController.SetMaxHealth(healthMax);
                healthbarController.SetHealth(healthCurrent);
                EventManagerSO.TriggerEvent_DeathNotification(team, playerName,"an enemy");
            }
        }
    }

    void AllowMovement()
    {
        canMove = true;
    }

    void StopMovement(float garbage)
    {
        canMove = false;
    }
}
