using UnityEngine;
/// <summary>
/// Wait state.
/// Its basically waits for X seconds.
/// </summary>
public class State_Wait : BaseState
{
    // Example in StateMachine script - how you can configure state before it will start operating.
    // Minimal waiting time
    public float minWait = 1;
    // Stores how much time left in waiting state.
    private float waitTime;
    public override void PrepareState()
    {
        base.PrepareState();
        // Randomize waiting time.
        waitTime = Random.Range(minWait, 2.5f);
    }
    public override void UpdateState()
    {
        base.UpdateState();
        // After each frame we are subtracting time that passed.
        waitTime -= Time.deltaTime;
        // When wait time is over it's time to change state!
        if (waitTime < 0)
        {
            // Find new place to go!
            owner.ChangeState(new State_Move());
        }
    }
}