using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(UnitController))]
public class AIController : MonoBehaviour
{
    [Header("           State Machine")][Space(15)]
        public AIState[] states;
        [SerializeField] public AIState currentState;
        [SerializeField] public AIStateEnum currentStateEnum;
        [SerializeField] public AIStateEnum defaultState;
        public Dictionary<AIStateEnum, AIState> stateDictionary;
        bool busyChange;
        [SerializeField] public UnitController unitController  => GetComponent<UnitController>();

    
    [Header("           Field of View")][Space(15)]
        [SerializeField] public List<RecentEnemy> recentEnemies = new List<RecentEnemy>();
        [SerializeField] public List<RecentBall> recentBalls = new List<RecentBall>();
        [SerializeField] AIFieldOfView fieldOfView;
        [SerializeField] GameObject fowPrefab;
        public float recentMemoryTime = 5f;

    [Header("           Shooter settings")][Space(15)]
        [SerializeField] Transform aimAtThis;


    [Header("           Pathfinding")][Space(15)]
        public GameObject destinationIndicator;
        // public Vector3 
        public GameObject targetGO;
        // public Transform targetTransform;
        public Vector3 destination;
    
        [SerializeField] public PredictedPositionController predictionController;
        public NavMeshPath path;
        private float elapsed = 0.0f;
        [SerializeField] float updatePathTime = 0.1f;
        public bool overrideInput = false;
        [SerializeField] public Input newInput = new Input();
        public int pathSize;
        public GameObject nextPointIndicator;
        public GameObject nextNextPointIndicator;
        public GameObject nextNextNextPointIndicator;
        [SerializeField] public float stoppingDistance = 0.5f;
        public int pathIndex = 1;
        Vector3[] pathCorners;
        public bool moveToTarget = false;
        Vector3 nextPoint = Vector3.zero;
        Vector3 nextNextPoint = Vector3.zero;
        Vector3 nextNextNextPoint = Vector3.zero;
        public bool stuck = false;
        public float minStuckSpeed = 0.2f;

    [Header("           Jump Calculations")][Space(15)]
        public float jumpCheckDistance = 1f;
        public float minLedgeHeight = 1f;
        public bool jumping = false;
        public float wantToJumpAngle = 90;
        public float wantToJumpDistance = 1;

    NavMeshAgent _agent;

    void Start()
    {
        // StartMachine(states);
        StartMachine();
        path = new NavMeshPath();
        if(states.Length <= 1){
            Debug.LogWarning(gameObject.name+"'s AIController only has 1 or 0 possible states assigned");
        }
        newInput.moveRelative = false;
        if(!fieldOfView){
            if(fowPrefab){
                Debug.LogWarning("gameObject "+gameObject.name+" does not have an AIFieldOfView assigned. Creating a prefab fow object.");
                fieldOfView = Instantiate(fowPrefab,this.transform).GetComponent<AIFieldOfView>();
                fieldOfView.disableVisuals = true;
            } else {
                Debug.LogError("gameObject "+gameObject.name+" does not have an AIFieldOfView assigned and cannot create a fow prefab either.");
            }
        }
        if(!aimAtThis){
            GameObject newObj = new GameObject("Aim At This Transform");
            Instantiate(newObj, this.transform);
            aimAtThis = newObj.transform;
        }
        recentBalls.Clear();
        recentEnemies.Clear();
        CheckIfNavmesh();
        // this._agent = this.gameObject.GetComponent<NavMeshAgent>();
        // this._agent.destination = this.transform.position;
    }
    void Update()
    {  
        if(!navMeshAvailable){
            Debug.LogError("gameObject "+gameObject.name+": Game Scene does not have a navmesh baked, and therefore the ai will not work. ");
            return;
        }
        elapsed += Time.deltaTime;
        if (elapsed > updatePathTime){
            elapsed -= updatePathTime;
            CalculateNewPath();
        }
        DrawDebugPath();
        CheckIfStuck();
        

        // If not doing anything & has no targets, then wander

        // If no ball but ball in sight, then go to a ball
        // if(!unitController.hasBall && recentBalls.Count>0){
        //     targetGO = recentBalls[0].dodgeballController.gameObject;
        //     moveToTarget = true;
        // }

        
        // if(unitController.pickUpZoneController.ballNear) {
        //     moveToTarget = false;
        //     newInput.pickup = true;
        // } else {
        //     newInput.pickup = false;
        // }
        
        // if(unitController.hasBall && recentEnemies.Count>0){
        //     targetGO = recentEnemies[0].enemyController.gameObject;
        //     AimAtTarget();
        // } else {
        //     newInput.aim = false;
        // }

        // if(unitController.input.aim && unitController.hasBall ){ //&&within range & line of sight{
        //     newInput.throw_bool = true;
        // } else {
        //     newInput.throw_bool = false;
        // }

        if (overrideInput == false) {
            
            if(!unitController.hasBall) {startAiming = false;}
            if(startAiming){
                AimAtTarget();
            }

            

            // if(moveToTarget && path != null && targetGO != null){
                Move();
            // }
            
            if(fieldOfView){
                CheckFOW();
            }
            currentState?.UpdateState();
            if(stuck & newInput.move.magnitude > 0.2f){
                newInput.jump = true;
                // newInput.move = new Vector2(0,-1);
            }
            //Assign the new input to the unitController
        }

        unitController.input = newInput;
    }

    void LateUpdate()
    {
        if (overrideInput == false) {
            ResetInputs();
        }
        
    }

    void ResetInputs()
    {
        newInput.jump = false;
        newInput.aim = false;
        newInput.throw_bool = false;
    }

    //_______________Public Member Functions_______________

    public void SetTargetObject (GameObject newTargtGO)
    {
        useTargetObject = true;
        targetGO = newTargtGO;
        CalculateNewPath();
    }

    private bool useTargetObject = false;
    public void SetDestination (Vector3 newDestination)
    {
        useTargetObject = false;
        destinationIndicator.transform.position = newDestination + Vector3.up*1f;
        destination = newDestination;
        moveToTarget = true;
        CalculateNewPath();
    }

    public void ChangeState (AIStateEnum newState) //call this function when changing states
    { 
        if (!busyChange){
            StartCoroutine(ChangeStateWait(newState));
        }
    }

    //_______________Private Functions_______________
    bool navMeshAvailable;
    void CheckIfNavmesh()
    {
        NavMeshHit hit;
        if (NavMesh.SamplePosition(Vector3.zero, out hit, 1000.0f, NavMesh.AllAreas)) {
        Vector3 result = hit.position;
            navMeshAvailable = true;
        } else {
            navMeshAvailable = false;
        }
    }

    public float stuckTimer;
    public float minStuckTime = 1f;
    void CheckIfStuck()
    {
        stuckTimer += Time.deltaTime;
        if (GetComponent<CharacterController>().velocity.magnitude > minStuckSpeed) {
            stuckTimer = 0;
        }

        stuck = (stuckTimer > minStuckTime);
    }

    public bool startAiming = false;

    private void AimAtTarget()
    {
        // SetDestination(targetGO.transform.position);
        // unitController.overrideTargetTransform = targetGO.transform;
        if (targetGO.layer == unitController.gameObject.layer) {
            aimAtThis.position = targetGO.transform.position + targetGO.GetComponent<CharacterController>().center;
        } else {
            aimAtThis.position = targetGO.transform.position;
        }
        
        unitController.overrideTargetTransform = aimAtThis;
        newInput.aim = true;
    }

    private Vector3 _desVelocity;
    // private bool 
    private void Move()
    {
        // this._agent.destination = this.transform.position;
        // this._agent.updatePosition = false;
        // this._agent.updateRotation = false;
        // this._agent.velocity = this.GetComponent<CharacterController>().velocity; // This is the most important line
        // _agent.updatePosition
        if(useTargetObject) {
            destinationIndicator.transform.position = targetGO.transform.position;
        } else {
            destinationIndicator.transform.position = destination;
        }

        if (unitController.Grounded) 
        {
            jumping = false;
            if (moveToTarget & path != null & path.status == NavMeshPathStatus.PathComplete & path.corners.Length > 1) {
                DetermineIfJump();
                FollowPath();   
            }     
            else{
                newInput.move = Vector2.zero;
            }
        } 

        
        // if (moveToTarget & path != null & path.status == NavMeshPathStatus.PathComplete & path.corners.Length > 1) {
        //     // this._desVelocity = this._agent.desiredVelocity;
            
        //     // this.unitController.Move(this._desVelocity.normalized);
        //     // newInput.move = _desVelocity.normalized;
        //     // this._agent.SetPath(path);
        //     if(useTargetObject) {
        //         destinationIndicator.transform.position = targetGO.transform.position;
        //     }

        //     DetermineIfJump();
        //     FollowPath();   
        // }     
        // else{
        //     newInput.move = Vector2.zero;
        // }

        // else if ((nextNextPoint - this.transform.position).magnitude < 1f){
        //     FollowPath(); 
        // }
        if((nextPoint - this.transform.position).magnitude > 1f){
            newInput.sprint = true;
        } else {
            newInput.sprint = false;
        }

        if(nextPointIndicator){
            nextPointIndicator.transform.position = nextPoint;
        } else {
            Debug.Log(gameObject.name +": nextPointIndicator is not assigned.");
        }
        if(nextNextPointIndicator){
            nextNextPointIndicator.transform.position = nextNextPoint;
        } else {
            Debug.Log(gameObject.name +": nextNextPointIndicator is not assigned.");
        }
        if(nextNextNextPointIndicator){
            nextNextNextPointIndicator.transform.position = nextNextNextPoint;
        } else {
            Debug.Log(gameObject.name +": nextNextNextPointIndicator is not assigned.");
        }
    }

    // private void StartMachine(List<AIState> states)
    private void StartMachine()
    {
        // if(machineStarted) return;
        stateDictionary = new Dictionary<AIStateEnum, AIState>();
        states = GetComponents<AIState>();

        for (int i = 0; i < states.Length; i++){
            if (states[i] == null){
                continue;
            }
            states[i].Init(this);
            if(!stateDictionary.ContainsKey(states[i].aiStateEnum)){
                stateDictionary.Add(states[i].aiStateEnum, states[i]);
            }    
        }
        currentState = stateDictionary[defaultState];  

        ChangeState(defaultState);
    }

    

    private IEnumerator ChangeStateWait(AIStateEnum newState)
    {
        busyChange = true;
        currentState.ExitState();
        currentState = stateDictionary[newState];
        currentStateEnum = currentState.aiStateEnum;
        Debug.Log(gameObject.name +" changing to state "+newState.ToString());
        currentState.EnterState();
        yield return new WaitForEndOfFrame();
        busyChange = false;
    }

    private void CheckFOW()
    {
        // Add new visible players
        foreach (Transform enemyT in fieldOfView.visiblePlayers) {
            if(enemyT.GetComponent<UnitController>().team == unitController.team){
                continue;
            }
            bool found = false;
            foreach (RecentEnemy enemy in recentEnemies){
                if (enemyT == enemy.enemyController.transform) {
                    found = true;
                }
            }
            if(!found){
                recentEnemies.Add(new RecentEnemy(enemyT.GetComponent<UnitController>(),Time.time));
            }
        }
        
        // Manage the recent memory players
        List<RecentEnemy> newEnemyList = new List<RecentEnemy>();
        for (int i = 0; i < recentEnemies.Count; i++) {
            RecentEnemy enemy = recentEnemies[i];
            if(fieldOfView.visiblePlayers.Contains(enemy.enemyController.transform)){
                enemy.timeOfSighting = Time.time;
            }

            if(!((Time.time - enemy.timeOfSighting) > recentMemoryTime)){
                // recentEnemies.Remove(enemy);
                newEnemyList.Add(enemy);
            }
        }
        recentEnemies = newEnemyList;
        
        // Add new visible players
        foreach (Transform ballT in fieldOfView.visibleBalls) {
            bool found = false;
            foreach (RecentBall ball in recentBalls){
                if (ballT == ball.dodgeballController.transform) {
                    found = true;
                }
            }
            if(!found){
                recentBalls.Add(new RecentBall(ballT.GetComponent<DodgeballController>(),Time.time));
            }
        }
        
        // Manage the recent memory players
        List<RecentBall> newBallList = new List<RecentBall>();
        for (int i = 0; i < recentBalls.Count; i++) {
            RecentBall ball = recentBalls[i];
            if(fieldOfView.visibleBalls.Contains(ball.dodgeballController.transform)){
                ball.timeOfSighting = Time.time;
            }

            if(!((Time.time - ball.timeOfSighting) > recentMemoryTime)){
                // recentEnemies.Remove(enemy);
                newBallList.Add(ball);
            }
        }
        recentBalls = newBallList;
    }

    private void DetermineIfJump()
    {
        // stuck = (GetComponent<CharacterController>().velocity.magnitude < minStuckSpeed);
        // if(stuck){
        //     newInput.jump = true;
        //     jumping = true;
        //     return;
        // }
        bool edge = false;
        Vector3 testPoint = unitController.transform.position + unitController.transform.forward*jumpCheckDistance;
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(testPoint+Vector3.up*1f, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity, unitController.GroundLayers))
        {
            edge = (hit.distance > minLedgeHeight);
        }

        Vector3 futureLine = (nextNextPoint-nextPoint);
        float dist = futureLine.magnitude;
        bool wantToJump = (Mathf.Abs(Vector3.Angle(unitController.direction,futureLine))<wantToJumpAngle) && dist > wantToJumpDistance;

        if(edge & wantToJump){
            newInput.jump = true;
            jumping = true;
        }
    }

    [SerializeField] float pathCornerEstimatedDist = 1f;
    private void CalculateNewPath()
    {
        // NavMesh.CalculatePath(transform.position, targetGO.transform.position, NavMesh.AllAreas, path);
        // destination = targetGO.transform.position;
        Vector3 currentClosestToNavmesh;
        NavMeshHit navmeshHit;
        if(unitController.Grounded){
            NavMesh.SamplePosition(transform.position,out navmeshHit, pathCornerEstimatedDist, NavMesh.AllAreas);
            currentClosestToNavmesh = navmeshHit.position;
        } else {
            destination = destinationIndicator.transform.position;
            Ray ray = new Ray (transform.position, Vector3.down);
            RaycastHit hit;
            
            if(Physics.Raycast(ray, out hit)){
                NavMesh.SamplePosition(hit.transform.position,out navmeshHit, pathCornerEstimatedDist, NavMesh.AllAreas);
                currentClosestToNavmesh = navmeshHit.position;
            } else {
                NavMesh.SamplePosition(transform.position,out navmeshHit, pathCornerEstimatedDist, NavMesh.AllAreas);
                // currentClosestToNavmesh = this.transform.position;
            }
            currentClosestToNavmesh = navmeshHit.position;
        }
       
        
        // NavMesh.SamplePosition(transform.position,out navmeshHit, pathCornerEstimatedDist, NavMesh.AllAreas);
        // Vector3 currentClosestToNavmesh;// = navmeshHit.position;
        if(currentClosestToNavmesh.magnitude > 10000f){
            currentClosestToNavmesh = this.transform.position;
        }

        NavMesh.SamplePosition(destination,out navmeshHit, 20f, NavMesh.AllAreas);
        Vector3 targetClosestToNavmesh = navmeshHit.position;

        NavMesh.CalculatePath(currentClosestToNavmesh, targetClosestToNavmesh, NavMesh.AllAreas, path);
        path.GetCornersNonAlloc(pathCorners);
        pathIndex = 0;  
    }

    private void DrawDebugPath()
    {
        if(path.status != NavMeshPathStatus.PathComplete) {return;}
        for (int i = 0; i < path.corners.Length - 1; i++)
            Debug.DrawLine(path.corners[i]+Vector3.up*navMeshVerticalOffset, path.corners[i + 1]+Vector3.up*navMeshVerticalOffset, Color.red);
    }
    
    public float navMeshVerticalOffset = 0.2f;
    private void FollowPath()
    {
        if(path.status != NavMeshPathStatus.PathComplete) {return;}
        pathSize = path.corners.Length;
        nextPoint = path.corners[pathIndex]+Vector3.up*navMeshVerticalOffset;

        // If reached final point, then stop
        if(pathSize-1 == pathIndex & Vector3.Distance(nextPoint,this.transform.position) < stoppingDistance){
            moveToTarget = false;
            return;
        }

        // If there are multiple corners too close to each other, find the next that is far enough away
        while(pathIndex < (path.corners.Length - 1) & Vector3.Distance(nextPoint,this.transform.position) < stoppingDistance){
            pathIndex++;
            nextPoint = path.corners[pathIndex]+Vector3.up*navMeshVerticalOffset;  
        }
        if(pathIndex+1 < path.corners.Length){
            nextNextPoint = path.corners[pathIndex+1]+Vector3.up*navMeshVerticalOffset;  
        } else {
            nextNextPoint = nextPoint;
        }
        if(pathIndex+2 < path.corners.Length){
            nextNextNextPoint = path.corners[pathIndex+2]+Vector3.up*navMeshVerticalOffset;  
        } else {
            nextNextNextPoint = nextNextPoint;
        }

        Vector3 direction = nextPoint - this.transform.position;
        Vector2 newMove = new Vector2(direction.x, direction.z).normalized;

        newInput.move = newMove;
        // if(nextPointIndicator){
        //     nextPointIndicator.transform.position = nextPoint;
        // } else {
        //     Debug.Log(gameObject.name +": nextPointIndicator is not assigned.");
        // }
        // if(nextNextPointIndicator){
        //     nextNextPointIndicator.transform.position = nextNextPoint;
        // } else {
        //     Debug.Log(gameObject.name +": nextNextPointIndicator is not assigned.");
        // }
        // if(nextNextNextPointIndicator){
        //     nextNextNextPointIndicator.transform.position = nextNextNextPoint;
        // } else {
        //     Debug.Log(gameObject.name +": nextNextNextPointIndicator is not assigned.");
        // }
    }

    public float GetPathLength(NavMeshPath _path)
    {
        float totalLength = 0;

        Vector3 prevPoint = _path.corners[0];
        Vector3 newPoint;
        for(int i = 1; i < _path.corners.Length; i++){
            newPoint = _path.corners[i];
            totalLength += Vector3.Distance(prevPoint,newPoint);
            prevPoint = _path.corners[i];
        }


        return totalLength;
    }
}

[Serializable]
public struct RecentInterest{
    // public enum 
    public UnitController enemyController;
    public float timeOfSighting;

    public RecentInterest(UnitController controller, float currentTime){
        enemyController = controller;
        timeOfSighting = currentTime;
    }
}

[Serializable]
public struct RecentEnemy{
    public UnitController enemyController;
    public float timeOfSighting;

    public RecentEnemy(UnitController controller, float currentTime){
        enemyController = controller;
        timeOfSighting = currentTime;
    }
}

[Serializable]
public struct RecentBall{
    public DodgeballController dodgeballController;
    public float timeOfSighting;

    public RecentBall(DodgeballController controller, float currentTime){
        dodgeballController = controller;
        timeOfSighting = currentTime;
    }
}