 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 
//  [CreateAssetMenu(fileName = "SpawnManagerSO", menuName = "SO Channels/SpawnManager", order = 1)]
 public class SpawnManager : Singleton<SpawnManager>
 {
     private int spawnIndex;
     public Transform[] spawnpoints;
     
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
        var spawn = spawnpoints[spawnIndex];
        spawnIndex++;
        if (spawnIndex >= spawnpoints.Length) {
            spawnIndex = 0;
        }
        return spawn.transform.position;
    }
 }
