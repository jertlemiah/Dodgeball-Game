 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 using UnityEngine.AI;
 
//  [CreateAssetMenu(fileName = "SpawnManagerSO", menuName = "SO Channels/SpawnManager", order = 1)]
 public class SpawnManager : Singleton<SpawnManager>
 {
    private int spawnIndex;
    public Transform[] spawnpoints;
    public float wanderRadius = 25f;
    public float verticalRespawnOffset = 15f;
    public string spawnpointTagName = "Spawn point";
    public GameObject[] spawnpointsGO;
    
    #region Monobehaviour
    new void Awake()
    {
        base.Awake();
        EventManagerSO.E_FinishedLoading += SetupNewSpawnpoints;
    }
    
    void Start(){
        SetupNewSpawnpoints();
    }

    void OnDisable()
    {
        EventManagerSO.E_FinishedLoading -= SetupNewSpawnpoints;
    }
    #endregion Monobehaviour

    void SetupNewSpawnpoints()
    {
        // int count = transform.childCount;
        spawnIndex = 0;

        spawnpointsGO = GameObject.FindGameObjectsWithTag(spawnpointTagName);

        spawnpoints = new Transform[spawnpointsGO.Length];

        // spawnpoints = new Transform[count];
        for(int i = 0; i < spawnpoints.Length; i++){
            // spawnpoints[i] = transform.GetChild(i);
            spawnpoints[i] = spawnpointsGO[i].transform;
        }
        Debug.Log("spawnpoints " + spawnpoints.Length + spawnpoints);
    }
     
    public Vector3 GetSpawnLocation(Vector3 playerLocation) {
        Vector3 outputLocation;
        if (spawnpoints.Length > 0) {
            // var spawn = spawnpoints[spawnIndex];
            spawnIndex++;
            if (spawnIndex >= spawnpoints.Length) {
                spawnIndex = 0;
            }
            outputLocation = spawnpoints[spawnIndex].position;
        }
         else {
            Vector3 origin = new Vector3(0.0f, 0.0f, 0.0f);
            outputLocation = RandomNavSphere(origin, wanderRadius, -1);
            outputLocation.y += 5;
        }
        return outputLocation;
    }

    private Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask) {
        Vector3 randDirection = UnityEngine.Random.insideUnitSphere * dist;
 
        randDirection += origin;
 
        NavMeshHit navHit;
 
        NavMesh.SamplePosition (randDirection, out navHit, dist, layermask);
 
        return navHit.position+Vector3.up*verticalRespawnOffset;
    }
 }
