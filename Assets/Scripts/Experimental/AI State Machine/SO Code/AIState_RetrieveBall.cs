using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;
/// <summary>
/// Moves the ai to a nearby ball and picks it up
/// </summary>
public class AIState_RetrieveBall : AIState
{
    public DodgeballController targetBall;
    // AIController aiController;
    [SerializeField] float minTimeInState = 3f;
    [SerializeField] float maxPredictionTime = 5f;
    float timeInState;
    float enterTime;
    [SerializeField] float remainingDistance;
    [SerializeField] float stoppingDistance = 5f;
    public override void Init (AIController aiStateMachine)
    {
        aiStateEnum = AIStateEnum.RetrieveBall;
        base.aiController = aiStateMachine;
        // parentAI = aiStateMachine.aiController;
        // targetGO = aiController.targetGO;
    }
    public override void EnterState ()
    {
        base.EnterState ();
        // Picking random position
        enterTime = Time.time;
        // StartCoroutine("FindTargetsWithDelay",0.2f);
        aiController.moveToTarget = true;
    }
    public override void UpdateState ()
    {
        base.UpdateState();
        if(aiController.unitController.hasBall && aiController.recentEnemies.Count > 0) {
            aiController.ChangeState(AIStateEnum.AttackPlayer); // change to attack player
            return;
        } else if (aiController.recentBalls.Count == 0 || aiController.stuck) {
            aiController.ChangeState(AIStateEnum.Wander);
            return;
        } else {
            if(aiController.unitController.pickUpZoneController.ballNear) {
                aiController.newInput.pickup = true;
                if(aiController.recentEnemies.Count > 0){
                    aiController.ChangeState(AIStateEnum.AttackPlayer); // change to attack player
                    return;
                } else {
                    aiController.ChangeState(AIStateEnum.Wander); // change to finding a player to attack
                    return;
                }
                
            } else {
                aiController.newInput.pickup = false;
            }

            targetBall = aiController.recentBalls[0].dodgeballController;
            // aiController.targetGO = targetBall.gameObject;
            aiController.SetTargetObject(targetBall.gameObject);
        }
    }

    public override void ExitState () 
    {
        base.ExitState ();
        aiController.moveToTarget = false;
    }

    void FindClosestBall ()
    { 
        // I'm pretty sure this code will not ever work because it takes more than a single frame to calculate a path
        NavMeshPath path = new NavMeshPath ();
        float shortestCost = -1;
        DodgeballController closestBall = null;
        foreach (RecentBall ball in aiController.recentBalls) {
            NavMesh.CalculatePath (aiController.transform.position, ball.dodgeballController.transform.position, NavMesh.AllAreas, path);
            float newCost = aiController.GetPathLength(path);
            if (shortestCost == -1 || newCost < shortestCost) {
                shortestCost = newCost;
                closestBall = ball.dodgeballController;
            }
        }

        targetBall = closestBall;
    }
 
}