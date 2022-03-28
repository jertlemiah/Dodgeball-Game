using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIState_ThrowBall : AIState
{
    public GameObject targetGO;
    [SerializeField] PredictedPositionController predictionController;
    NavMeshAgent navMeshAgent;
    // AIController parentAI;
    [SerializeField] float minTimeInState = 3f;
    [SerializeField] float maxPredictionTime = 5f;
    float timeInState;
    float enterTime;
    [SerializeField] float remainingDistance;
    [SerializeField] float stoppingDistance = 0.5f;
    public override void Init(AIController aiStateMachine)
    {
        aiController = aiStateMachine;
        // parentAI = aiStateMachine.aiController;
        // targetGO = parentAI.targetGO;
        // navMeshAgent = parentAI.navMeshAgent;
        // predictionController = parentAI.predictionController;
        // parentAI = aiStateMachine.minionAI;
        // navMeshAgent = parentAI.navMeshAgent;
        // predPosCon = parentAI.predPosCon;
        // movingTarget = parentAI.movingWaypoint.transform;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
