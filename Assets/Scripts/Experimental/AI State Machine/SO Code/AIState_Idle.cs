using UnityEngine;

[CreateAssetMenu(fileName = "AIState_IdleSO", menuName = "AIState/Idle", order = 1)]
public class AIState_Idle : AIState
{
    public override void Init(AIStateMachine stateMachine)
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
        
    }
}