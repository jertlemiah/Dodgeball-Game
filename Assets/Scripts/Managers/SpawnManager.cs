 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 
//  [CreateAssetMenu(fileName = "SpawnManagerSO", menuName = "SO Channels/SpawnManager", order = 1)]
 public class SpawnManager : Singleton<SpawnManager>
 {
     private int spawnIndex;
     public Transform[] spawnpoints;
     public float wanderRadius = 50f;
     
     void Start(){
         int count = transform.childCount;
         spawnIndex = 0;
         spawnpoints = new Transform[count];
         for(int i = 0; i < spawnpoints.Length; i++){
             spawnpoints[i] = transform.GetChild(i);
         }
         Debug.Log("spawnpoints " + spawnpoints.Length + spawnpoints);
     }
     
    public Vector3 GetSpawnLocation() {
        if (spawnpoints.Length > 0) {
            var spawn = spawnpoints[spawnIndex];
            spawnIndex++;
            if (spawnIndex >= spawnpoints.Length) {
                spawnIndex = 0;
            }
        }
         else {
            currentTarget = RandomNavSphere(aiController.transform.position, wanderRadius, -1);
        }
        return spawn.transform.position;
    }

     private static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask) {
        Vector3 randDirection = UnityEngine.Random.insideUnitSphere * dist;
 
        randDirection += origin;
 
        NavMeshHit navHit;
 
        NavMesh.SamplePosition (randDirection, out navHit, dist, layermask);
 
        return navHit.position;
    }
 }
