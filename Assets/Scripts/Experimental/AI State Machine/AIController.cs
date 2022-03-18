using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class AIController : MonoBehaviour
{
    [SerializeField] public List<AIState> states;
    [SerializeField] public UnitController controller  => GetComponent<UnitController>();
    public GameObject targetPlayerGO;
    [SerializeField] public NavMeshAgent navMeshAgent;
    [SerializeField] public PredictedPositionController predictionController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
