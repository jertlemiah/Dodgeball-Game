using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "AIState_Wander", menuName = "AIState/Wander", order = 1)]
public class AIState_Wander : AIState
{
    public float waypointStoppingDist = 2f;
    public Vector3 currentTarget;
    public float wanderRadius = 5f;
    public float wanderTimer = 3f;
    private float timer;
    public string interestTagName = "Points of Interest";
    public GameObject[] pointsOfInterest;
    public int index = -1;
    public override void Init(AIController _aiController)
    {
        aiController = _aiController;
        pointsOfInterest = GameObject.FindGameObjectsWithTag(interestTagName);
        if(pointsOfInterest.Length == 0){
            Debug.LogWarning(this.name +" could not find any Points of Interest in the scene, resorting to random positions. Please add Points of Interest prefabs to the environment.");
        }
        index = -1;
    }
    public override void EnterState()
    {
        base.EnterState();
        if(pointsOfInterest.Length>0){
            currentTarget = GetNextWaypoint().position;
        }
        // aiController.moveToTarget=true;

        // Debug.Log("Minion in idle!");
    }
    public override void UpdateState()
    {
        base.UpdateState();
        
        if(aiController.recentBalls.Count > 0) {
            // Go retrieve a ball
        }
        
        if(pointsOfInterest.Length>0){
            // Waypoint mode
            // Go to next waypoint
            if((aiController.transform.position - currentTarget).magnitude < waypointStoppingDist){
                currentTarget = GetNextWaypoint().position;
            }    
        } else { 
            // Random position mode
            timer += Time.deltaTime;
            if((aiController.transform.position - currentTarget).magnitude < waypointStoppingDist || aiController.stuck || (timer >= wanderTimer)){
                timer = 0;
                currentTarget = RandomNavSphere(aiController.transform.position, wanderRadius, -1);
            }
        }   
        aiController.SetDestination(currentTarget);
        aiController.moveToTarget=true;
    }

    Transform GetNextWaypoint()
    {
        Transform nextWaypoint;
        index++;
        if(index >= pointsOfInterest.Length){
            index = 0;
        }
        nextWaypoint = pointsOfInterest[index].transform;
        return nextWaypoint;
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask) {
        Vector3 randDirection = UnityEngine.Random.insideUnitSphere * dist;
 
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