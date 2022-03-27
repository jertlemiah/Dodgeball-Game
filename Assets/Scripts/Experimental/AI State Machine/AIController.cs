using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(UnitController))]
public class AIController : MonoBehaviour
{
    [Header("           State Machine")][Space(15)]
        [SerializeField] public List<AIState> states;
        [SerializeField] public AIState currentState;
        [SerializeField] public AIStateEnum currentStateEnum;
        [SerializeField] public AIStateEnum defaultState;
        public Dictionary<AIStateEnum, AIState> stateDictionary;
        bool busyChange;
        [SerializeField] public UnitController unitController  => GetComponent<UnitController>();
    
    [Header("           Field of View")][Space(15)]
        [SerializeField] public List<RecentEnemy> recentEnemies = new List<RecentEnemy>();
        [SerializeField] public List<RecentBall> recentBalls = new List<RecentBall>();
        [SerializeField] AIFieldOfView fow;
        [SerializeField] GameObject fowPrefab;
        public float recentMemoryTime = 5f;

    [Header("           Pathfinding")][Space(15)]
        public GameObject targetGO;
        // public Transform targetTransform;
        public Vector3 destination;
    
        [SerializeField] public PredictedPositionController predictionController;
        public NavMeshPath path;
        private float elapsed = 0.0f;
        [SerializeField] float updatePathTime = 0.1f;
        [SerializeField] Input newInput = new Input();
        public int pathSize;
        public GameObject targetCorner;
        [SerializeField] float stoppingDistance = 0.5f;
        public int pathIndex = 1;
        Vector3[] pathCorners;
        public bool moveToTarget = false;
        Vector3 nextPoint = Vector3.zero;
        Vector3 nextNextPoint = Vector3.zero;
        Vector3 nextNextNextPoint = Vector3.zero;

    [Header("           Jump Calculations")][Space(15)]
        public float jumpCheckDistance = 1f;
        public float minLedgeHeight = 1f;
        public bool jumping = false;
        public float wantToJumpAngle = 90;

    void Start()
    {
        StartMachine(states);
        path = new NavMeshPath();
        if(states.Count <= 1){
            Debug.LogWarning(gameObject.name+"'s AIController only has 1 or 0 possible states assigned");
        }
        newInput.moveRelative = false;
        if(!fow){
            if(fowPrefab){
                Debug.LogWarning("gameObject "+gameObject.name+" does not have an AIFieldOfView assigned. Creating a prefab fow object.");
                fow = Instantiate(fowPrefab,this.transform).GetComponent<AIFieldOfView>();
                fow.disableVisuals = true;
            } else {
                Debug.LogError("gameObject "+gameObject.name+" does not have an AIFieldOfView assigned and cannot create a fow prefab either.");
            }
        }
    }

    void Update()
    {  
        elapsed += Time.deltaTime;
        if (elapsed > updatePathTime){
            elapsed -= updatePathTime;
            CalculateNewPath();
        }
        DrawDebugPath();
        
        // if(moveToTarget && path != null && targetGO != null){
            Move();
        // }
        
        if(fow){
            CheckFOW();
        }
        currentState?.UpdateState();
        //Assign the new input to the unitController
        unitController.input = newInput;
    }

    void LateUpdate()
    {
        newInput.jump = false;
    }

    public void SetDestination(Vector3 newDestination)
    {
        destination = newDestination;
    }

    void Move()
    {
        DetermineIfJump();
        if(unitController.Grounded){
            jumping = false;
            if(moveToTarget & path != null & path.status == NavMeshPathStatus.PathComplete & path.corners.Length > 1){
                FollowPath();   
            }     
            else{
                newInput.move = Vector2.zero;
            }
        }
    }

    public void StartMachine(List<AIState> states)
    {
        // if(machineStarted) return;
        stateDictionary = new Dictionary<AIStateEnum, AIState>();

        for (int i = 0; i<states.Count; i++){
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

    public void ChangeState(AIStateEnum newState) //call this function when changing states
    { 
        if (!busyChange){
            StartCoroutine(ChangeStateWait(newState));
        }
    }

    public IEnumerator ChangeStateWait(AIStateEnum newState)
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

    void CheckFOW()
    {
        // Add new visible players
        foreach (Transform enemyT in fow.visiblePlayers) {
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
            if(fow.visiblePlayers.Contains(enemy.enemyController.transform)){
                enemy.timeOfSighting = Time.time;
            }

            if(!((Time.time - enemy.timeOfSighting) > recentMemoryTime)){
                // recentEnemies.Remove(enemy);
                newEnemyList.Add(enemy);
            }
        }
        recentEnemies = newEnemyList;
        
        // Add new visible players
        foreach (Transform ballT in fow.visibleBalls) {
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
            if(fow.visibleBalls.Contains(ball.dodgeballController.transform)){
                ball.timeOfSighting = Time.time;
            }

            if(!((Time.time - ball.timeOfSighting) > recentMemoryTime)){
                // recentEnemies.Remove(enemy);
                newBallList.Add(ball);
            }
        }
        recentBalls = newBallList;
    }
    
    void DetermineIfJump()
    {
        bool edge = false;
        Vector3 testPoint = unitController.transform.position + unitController.transform.forward*jumpCheckDistance;
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(testPoint+Vector3.up*1f, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity, unitController.GroundLayers))
        {
            edge = (hit.distance > minLedgeHeight);
        }

        Vector3 futureLine = (nextNextPoint-nextPoint);
        bool wantToJump = Mathf.Abs(Vector3.Angle(unitController.direction,futureLine))<wantToJumpAngle;

        if(edge & wantToJump){
            newInput.jump = true;
            jumping = true;
        }
    }

    void CalculateNewPath()
    {
        // NavMesh.CalculatePath(transform.position, targetGO.transform.position, NavMesh.AllAreas, path);
        NavMesh.CalculatePath(transform.position, destination, NavMesh.AllAreas, path);
        path.GetCornersNonAlloc(pathCorners);
        pathIndex = 0;  
    }

    void DrawDebugPath()
    {
        for (int i = 0; i < path.corners.Length - 1; i++)
            Debug.DrawLine(path.corners[i], path.corners[i + 1], Color.red);
    }
    public void FollowPath()
    {
        pathSize = path.corners.Length;
        nextPoint = path.corners[pathIndex];

        // If reached final point, then stop
        if(pathSize-1 == pathIndex & Vector3.Distance(nextPoint,this.transform.position) < stoppingDistance){
            moveToTarget = false;
            return;
        }

        // If there are multiple corners too close to each other, find the next that is far enough away
        while(pathIndex < (path.corners.Length - 1) & Vector3.Distance(nextPoint,this.transform.position) < stoppingDistance){
            pathIndex++;
            nextPoint = path.corners[pathIndex];  
        }
        if(pathIndex+1 < path.corners.Length){
            nextNextPoint = path.corners[pathIndex+1];  
        } else {
            nextNextPoint = nextPoint;
        }
        if(pathIndex+2 < path.corners.Length){
            nextNextNextPoint = path.corners[pathIndex+2];  
        } else {
            nextNextNextPoint = nextNextPoint;
        }

        

        Vector3 direction = nextPoint - this.transform.position;
        Vector2 newMove = new Vector2(direction.x, direction.z).normalized;

        newInput.move = newMove;
        if(targetCorner){
            targetCorner.transform.position = nextPoint;
        }
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