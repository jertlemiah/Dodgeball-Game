using UnityEngine;

public class AIState_Idle : AIState
{
    public override void Init(AIController stateMachine)
    {
        aiStateEnum = AIStateEnum.Idle;
    }
    
    public override void EnterState()
    {
        base.EnterState();
        // Debug.Log("Minion in idle!");
    }

    public override void UpdateState()
    {
        base.UpdateState();
        // Debug.Log("aicontroller? "+)
        
    }

    public override void ExitState() 
    {
        base.ExitState();
    }
}