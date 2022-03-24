using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(UnitController))]
public class AIController : MonoBehaviour
{
    [SerializeField] public List<AIState> states;
    [SerializeField] public UnitController unitController  => GetComponent<UnitController>();
    public GameObject targetPlayerGO;
    public Transform targetTransform;
    [SerializeField] public NavMeshAgent navMeshAgent  => GetComponent<NavMeshAgent>();    
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
    // NavMeshAgent agent;

    void Start()
    {
        path = new NavMeshPath();
        if(states.Count <= 1){
            Debug.LogWarning(gameObject.name+"'s AIController only has 1 or 0 possible states assigned");
        }
        newInput.moveRelative = false;
    }

    void Update()
    {
        elapsed += Time.deltaTime;
        if (elapsed > updatePathTime){
            elapsed -= updatePathTime;
             CalculateNewPath();
        }
        DrawDebugPath();

        if(moveToTarget & path != null & path.status == NavMeshPathStatus.PathComplete & path.corners.Length > 1){
            FollowPath();   
        }     
        else{
            newInput.move = Vector2.zero;
        }

        //Assign the new input to the unitController
        unitController.input = newInput;
    }


    void CalculateNewPath()
    {
        NavMesh.CalculatePath(transform.position, targetTransform.position, NavMesh.AllAreas, path);
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
        Vector3 nextPoint = path.corners[pathIndex];

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

        Vector3 direction = nextPoint - this.transform.position;
        Vector2 newMove = new Vector2(direction.x, direction.z).normalized;

        newInput.move = newMove;
        if(targetCorner){
            targetCorner.transform.position = nextPoint;
        }
    }
}
