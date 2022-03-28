using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;
/// <summary>
/// Move state.
/// Its picking new position to go to and than go back to wait state.
/// </summary>
[CreateAssetMenu(fileName = "AIState_FindBall", menuName = "AIState/FindBall", order = 1)]
public class AIState_FindBall : AIState
{
    public DodgeballController targetBall;
    // AIController aiController;
    [SerializeField] float minTimeInState = 3f;
    [SerializeField] float maxPredictionTime = 5f;
    float timeInState;
    float enterTime;
    [SerializeField] float remainingDistance;
    [SerializeField] float stoppingDistance = 5f;
    public override void Init(AIController aiStateMachine)
    {
        base.aiController = aiStateMachine;
        // parentAI = aiStateMachine.aiController;
        // targetGO = aiController.targetGO;
    }
    public override void EnterState()
    {
        base.EnterState();
        // Picking random position
        enterTime = Time.time;
        // StartCoroutine("FindTargetsWithDelay",0.2f);
        aiController.moveToTarget = true;
    }
    public override void UpdateState()
    {
        base.UpdateState();
        if(aiController.recentBalls == null){
            aiController.ChangeState(AIStateEnum.Wander);
            return;
        }
        FindClosestBall();

        aiController.targetGO = targetBall.gameObject;

        // AIController.targetGO



        // // Calculating direction in which UFO has to go to get to the destination
        // remainingDistance = navMeshAgent.remainingDistance;
        // // predPosCon.
        // // navMeshAgent.SetDestination(predPosCon.GetPredictedTransform().position);
        // timeInState = Time.time - enterTime;

        // // SetNextWaypoint(currWaypoint);
        // float aiVel = navMeshAgent.velocity.magnitude;
        // float timeToIntercept = Mathf.Clamp(remainingDistance / aiVel,0,maxPredictionTime);
        // // navMeshAgent.SetDestination(predPosCon.GetPredictedTransform().position);
        // Vector3 newPos = predictionController.GetPredictedTransform(timeToIntercept).position;
        // NavMeshHit hit;

        // if(NavMesh.SamplePosition(newPos, out hit, Mathf.Infinity,0)){
        //     navMeshAgent.SetDestination(hit.position);
        // }
        // else{
        //     navMeshAgent.SetDestination(newPos);
        // }

        // if(!navMeshAgent.pathPending && remainingDistance<=stoppingDistance && timeInState > minTimeInState){
        //     // ownerStateMachine.ChangeState(AIStateEnum.Idle);
        //     Debug.Log("set to idle");
        // }
        // else{
            
           
        // }
    }

    void FindClosestBall()
    {
        
        
        NavMeshPath path = new NavMeshPath();
        float shortestCost = -1;
        DodgeballController closestBall = null;
        foreach(RecentBall ball in aiController.recentBalls){
            NavMesh.CalculatePath(aiController.transform.position, ball.dodgeballController.transform.position, NavMesh.AllAreas, path);
            float newCost = aiController.GetPathLength(path);
            if(shortestCost == -1 || newCost < shortestCost){
                shortestCost = newCost;
                closestBall = ball.dodgeballController;
            }
        }

        targetBall = closestBall;
    }

    public override void ExitState() 
    {
        base.ExitState();
        aiController.moveToTarget = false;
    }
}