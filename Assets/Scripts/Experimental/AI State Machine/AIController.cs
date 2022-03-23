using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class AIController : MonoBehaviour
{
    [SerializeField] public List<AIState> states;
    [SerializeField] public UnitController controller  => GetComponent<UnitController>();
    public GameObject targetPlayerGO;
    public Transform targetTransform;
    [SerializeField] public NavMeshAgent navMeshAgent  => GetComponent<NavMeshAgent>();    
    [SerializeField] public PredictedPositionController predictionController;
    public NavMeshPath path;
    // Start is called before the first frame update
    void Start()
    {
        path = new NavMeshPath();
    }

    private float elapsed = 0.0f;

    // Update is called once per frame
    void Update()
    {
        elapsed += Time.deltaTime;
        if (elapsed > 1.0f)
        {
            elapsed -= 1.0f;
            NavMesh.CalculatePath(transform.position, targetTransform.position, NavMesh.AllAreas, path);
        }
        for (int i = 0; i < path.corners.Length - 1; i++)
            Debug.DrawLine(path.corners[i], path.corners[i + 1], Color.red);
    }
    public void MoveToTarget()
    {
        navMeshAgent.SetPath(path);
    }
}
