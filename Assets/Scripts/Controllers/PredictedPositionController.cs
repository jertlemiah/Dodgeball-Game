using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.AI;

public class PredictedPositionController : MonoBehaviour
{
    [SerializeField] float projectionTime = 1;
    [SerializeField] float maxProjectionTime = 3f;
    [SerializeField] float yOffset = 1;
    [SerializeField] float stoppingDistance = 1;
    [SerializeField] float snappingSpeed = 1;
    [SerializeField] GameObject trackingTargetGO;
    [SerializeField] public GameObject predictedPosGO;
    [SerializeField] float gizmoRadius = 0.2f;
    [SerializeField] Color gizmoColor = Color.green;
    Vector3 velPrev;
    Vector3 accelPrev;
    Vector3 posPrev;
    Vector3 velAvg;
    Vector3 accelAvg;
    public bool useRaycast = true;
    void Awake()
    {
        
    }
    NavMeshHit navHit;
    void FixedUpdate()
    {
        if(trackingTargetGO == null)
            return;
        
        Vector3 newPos = GetProjectedPosition(projectionTime);
        
        
        RaycastHit hit;
        if(Mathf.Abs((predictedPosGO.transform.position - newPos).magnitude) < 1000f) // Unity was having a weird issue where it assigned a position at (inf,inf,inf)
        {         
            Vector3 direction = velAvg.normalized;
            // if(velAvg.magnitude <= 0.1f){
            //     return;
            // }
            if (Physics.Raycast(trackingTargetGO.transform.position, direction, out hit, Mathf.Infinity))
            {
                // Below is to prevent predicting a position that would be inside of a wall or floor
                Debug.DrawRay(trackingTargetGO.transform.position+Vector3.up*1, direction * hit.distance, Color.cyan);
                if(useRaycast && hit.distance < (trackingTargetGO.transform.position - newPos).magnitude){
                    newPos = hit.point - direction*stoppingDistance+Vector3.up*yOffset;
                    // newPos = trackingTargetGO.transform.position+((direction*hit.distance- direction*stoppingDistance));
                    // newPos = newPos-(direction*((predictedPosGO.transform.position - newPos).magnitude-hit.distance));
                }              
            }
            // if (Physics.Raycast(trackingTargetGO.transform.position, Vector3.down, out hit, Mathf.Infinity))
            // {
            //     // This is to set the height of the position
            //     Debug.DrawRay(trackingTargetGO.transform.position+Vector3.up*1, direction * hit.distance, Color.cyan);
            //     float y = hit.point.y + yOffset; 
            //     newPos = new Vector3(newPos.x,y,newPos.z);        
            // }
            
            predictedPosGO.transform.DOMove(newPos,snappingSpeed);   
            // predictedPosGO.transform.position = newPos;   
        }
             
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;
        Gizmos.DrawSphere(predictedPosGO.transform.position, gizmoRadius);
    }
    public void SetNewTarget(GameObject newTargetGO)
    {
        trackingTargetGO = newTargetGO;
        predictedPosGO.transform.position = newTargetGO.transform.position;
        posPrev = newTargetGO.transform.position;
    }
    public void SetProjectionTime(float newProjectionTime)
    {
        projectionTime = Mathf.Min(newProjectionTime,maxProjectionTime);
    }
    public Transform GetPredictedTransform(float newInterceptTime)
    {
        projectionTime = newInterceptTime;
        return predictedPosGO.transform;
    }
    public Transform GetPredictedTransform()
    {
        return predictedPosGO.transform;
    }

    private void LateUpdate()
    {
        StartCoroutine(CheskPos());
    }

    IEnumerator CheskPos()
    {
        yield return new WaitForEndOfFrame();

        Vector3 velTrack = (trackingTargetGO.transform.position - posPrev) / Time.deltaTime;
        Vector3 accelTrack = velTrack - velPrev;

        velAvg = velTrack;
        accelAvg = accelTrack;

        GetProjectedPosition(projectionTime);

        posPrev = trackingTargetGO.transform.position;
        velPrev = velTrack;
        accelPrev = accelTrack;
    }

    Vector3 GetProjectedPosition(float projectionTime)
    {
        Vector3 posProj = new Vector3();
        // x0 + v0 * t + 1/2 * a * t^2
        float t = (projectionTime/Time.deltaTime)*Time.deltaTime;
        Vector3 x0 = trackingTargetGO.transform.position;
        Vector3 v0 = velAvg;
        Vector3 a0 = accelAvg;
        posProj = x0 + v0*t + 1/2*a0*t*t;

        return new Vector3(posProj.x, posProj.y + yOffset, posProj.z);
    }
}
