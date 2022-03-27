using UnityEngine;

[CreateAssetMenu(fileName = "AIState_IdleSO", menuName = "AIState/Idle", order = 1)]
public class AIState_Idle : AIState
{
    public override void Init(AIController stateMachine)
    {

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
}