using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIState_AttackPlayer : AIState
{
    public float aimDistance = 10f;
    public float throwDistance = 3f;
    public UnitController targetPlayer;

    public override void Init(AIController _aiController)
    {
        aiStateEnum = AIStateEnum.AttackPlayer;
        aiController = _aiController;
    }
    
    public override void EnterState()
    {
        base.EnterState();
        aimTime = 0f;
        targetPlayer = null;
        // Debug.Log("Minion in idle!");
    }

    [SerializeField] float minAimTime = 2f;
    [SerializeField] float aimTime = 0f;

    public override void UpdateState()
    {
        base.UpdateState ();
        if (!aiController.unitController.hasBall){
            aiController.ChangeState(AIStateEnum.Wander);
        }
        if (aiController.recentEnemies.Count == 0){
            aiController.ChangeState(AIStateEnum.Wander);
        }
        aimTime += Time.deltaTime;
        targetPlayer = aiController.recentEnemies[0].enemyController;
        aiController.SetTargetObject(targetPlayer.gameObject);
        if ((this.transform.position - targetPlayer.transform.position).magnitude < aimDistance){
            aiController.startAiming = true;
            if((this.transform.position - targetPlayer.transform.position).magnitude < aimDistance && aimTime > minAimTime /*&& line of sight */){
                aiController.newInput.throw_bool = true;
            } else {
                aiController.newInput.throw_bool = false;
            }
        } else {
            aiController.startAiming = false;
            aimTime = 0f;
        }
        // if(unitController.hasBall && recentEnemies.Count>0){
        //     targetGO = recentEnemies[0].enemyController.gameObject;
        //     AimAtTarget();
        // } else {
        //     newInput.aim = false;
        // }
        // Debug.Log("aicontroller? "+)
        // if(unitController.input.aim && unitController.hasBall ){ //&&within range & line of sight{
        //     newInput.throw_bool = true;
        // } else {
        //     newInput.throw_bool = false;
        // }
        
    }

    public override void ExitState() 
    {
        base.ExitState();
    }

}
