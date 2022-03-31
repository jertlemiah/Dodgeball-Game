using UnityEngine;
/// <summary>
/// This is base state script implementation.
/// StateMachine uses these virtual methods to call state when it needs to prepare itself for operating, updating or even being destroyed.
/// </summary>
public enum AIStateEnum {Idle, AttackPlayer, RetrieveBall, Wander}
public abstract class AIState : MonoBehaviour
{
    // Reference to our state machine.
    public AIController aiController;
    public AIStateEnum aiStateEnum;
    public abstract void Init(AIController aiStateMachine);

    /// <summary>
    /// Method called to prepare state to operate - same as Unity's Start()
    /// </summary>
    public virtual void EnterState() { }

    /// <summary>
    /// Method called to update state on every frame - same as Unity's Update()
    /// </summary>
    public virtual void UpdateState() { }

    /// <summary>
    /// Method called to destroy state - same as Unity's OnDestroy() but here it might be important!
    /// </summary>
    public virtual void ExitState() { }
}