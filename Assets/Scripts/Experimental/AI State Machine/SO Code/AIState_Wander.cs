using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "AIState_Wander", menuName = "AIState/Wander", order = 1)]
public class AIState_Wander : AIState
{
    public float wanderRadius = 5f;
    public float wanderTimer = 3f;
    private float timer;
    public override void Init(AIController _aiController)
    {
        aiController = _aiController;
    }
    public override void EnterState()
    {
        base.EnterState();
        aiController.moveToTarget=true;
        // Debug.Log("Minion in idle!");
    }
    public override void UpdateState()
    {
        base.UpdateState();
        // Debug.Log("aicontroller? "+)
        timer += Time.deltaTime;
 
        if (timer >= wanderTimer) {
            Vector3 newPos = RandomNavSphere(aiController.transform.position, wanderRadius, -1);
            // agent.SetDestination(newPos);
            aiController.SetDestination(newPos);
            aiController.moveToTarget=true;
            timer = 0;
        }
        
    }
    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask) {
        Vector3 randDirection = Random.insideUnitSphere * dist;
 
        randDirection += origin;
 
        NavMeshHit navHit;
 
        NavMesh.SamplePosition (randDirection, out navHit, dist, layermask);
 
        return navHit.position;
    }
    public override void ExitState() 
    {
        base.ExitState();
    }
}