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
    // NavMeshAgent agent;

    void Start()
    {
        path = new NavMeshPath();
        if(states.Count <= 1){
            Debug.LogWarning(gameObject.name+"'s AIController only has 1 or 0 possible states assigned");
        }
        newInput.moveRelative = false;
        // agent = GetComponent<NavMeshAgent>();
        // agent.updatePosition = false;
        // agent.updateRotation = false;
    }

    void Update()
    {
        elapsed += Time.deltaTime;
        if (elapsed > updatePathTime)
        {
            elapsed -= updatePathTime;
            if(!moveToTarget){
                NavMesh.CalculatePath(transform.position, targetTransform.position, NavMesh.AllAreas, path);
                path.GetCornersNonAlloc(pathCorners);
                pathIndex = 0;
            }
                
        }
        

        if(moveToTarget & path != null & path.status == NavMeshPathStatus.PathComplete & path.corners.Length > 1){
            // agent.SetPath(path);
            FollowPath();
            
        }     
        else
            newInput.move = Vector2.zero;
        
        // for (int i = 0; i < agent.path.corners.Length - 1; i++)
        //     Debug.DrawLine(agent.path.corners[i], agent.path.corners[i + 1], Color.red);

        for (int i = 0; i < path.corners.Length - 1; i++)
            Debug.DrawLine(path.corners[i], path.corners[i + 1], Color.red);

        unitController.input = newInput;
    }
    public int pathIndex = 1;
    Vector3[] pathCorners;
    public void FollowPath()
    {
        

        pathSize = path.corners.Length;
        // int i = 1;
        Vector3 nextPoint = path.corners[pathIndex];

        if(pathSize-1 == pathIndex & Vector3.Distance(nextPoint,this.transform.position) < stoppingDistance){
            moveToTarget = false;
            return;
        }

        while(pathIndex < (path.corners.Length - 1) & Vector3.Distance(nextPoint,this.transform.position) < stoppingDistance){
            pathIndex++;
            nextPoint = path.corners[pathIndex];  
        }

        Vector3 direction = nextPoint - this.transform.position;
        // transform.LookAt(nextPoint);


        Vector2 newMove = Vector2.zero;
        // unitController.MoveSpeed

        newMove = new Vector2(direction.x, direction.z).normalized;

        // direction = agent.nextPosition - this.transform.position;
        // newMove = new Vector2(direction.x, direction.z).normalized;

        newInput.move = newMove;
        if(targetCorner){
            targetCorner.transform.position = nextPoint;
        }
    }

    public bool moveToTarget = false;
    public void MoveToTarget()
    {
        moveToTarget = !moveToTarget;
        // navMeshAgent.SetPath(path);
        // navMeshAgent.Move(navMeshAgent.)
        // controller.input
        
    }
}
