using UnityEngine;
using UnityEngine.AI;
/// <summary>
/// Move state.
/// Its picking new position to go to and than go back to wait state.
/// </summary>
[CreateAssetMenu(fileName = "AIState_ChaseTarget", menuName = "AIState/ChaseTarget", order = 1)]
public class AIState_ChaseTarget : AIState
{
    public GameObject targetGO;
    [SerializeField] PredictedPositionController predictionController;
    NavMeshAgent navMeshAgent;
    AIController parentAI;
    [SerializeField] float minTimeInState = 3f;
    [SerializeField] float maxPredictionTime = 5f;
    float timeInState;
    float enterTime;
    [SerializeField] float remainingDistance;
    [SerializeField] float stoppingDistance = 5f;
    public override void Init(AIStateMachine aiStateMachine)
    {
        ownerStateMachine = aiStateMachine;
        parentAI = aiStateMachine.aiController;
        targetGO = parentAI.targetPlayerGO;
        navMeshAgent = parentAI.navMeshAgent;
        predictionController = parentAI.predictionController;
        // parentAI = aiStateMachine.minionAI;
        // navMeshAgent = parentAI.navMeshAgent;
        // predPosCon = parentAI.predPosCon;
        // movingTarget = parentAI.movingWaypoint.transform;
    }
    public override void EnterState()
    {
        base.EnterState();
        // Picking random position
        enterTime = Time.time;
        navMeshAgent.SetDestination(predictionController.GetPredictedTransform().position);
        predictionController.SetNewTarget(targetGO);
        navMeshAgent.stoppingDistance = stoppingDistance;
    }
    public override void UpdateState()
    {
        base.UpdateState();
        // Calculating direction in which UFO has to go to get to the destination
        remainingDistance = navMeshAgent.remainingDistance;
        // predPosCon.
        // navMeshAgent.SetDestination(predPosCon.GetPredictedTransform().position);
        timeInState = Time.time - enterTime;

        // SetNextWaypoint(currWaypoint);
        float aiVel = navMeshAgent.velocity.magnitude;
        float timeToIntercept = Mathf.Clamp(remainingDistance / aiVel,0,maxPredictionTime);
        // navMeshAgent.SetDestination(predPosCon.GetPredictedTransform().position);
        Vector3 newPos = predictionController.GetPredictedTransform(timeToIntercept).position;
        NavMeshHit hit;

        if(NavMesh.SamplePosition(newPos, out hit, Mathf.Infinity,0)){
            navMeshAgent.SetDestination(hit.position);
        }
        else{
            navMeshAgent.SetDestination(newPos);
        }

        if(!navMeshAgent.pathPending && remainingDistance<=stoppingDistance && timeInState > minTimeInState){
            // ownerStateMachine.ChangeState(AIStateEnum.Idle);
            Debug.Log("set to idle");
        }
        else{
            
           
        }
    }
}