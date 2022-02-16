using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PredictedPositionController : MonoBehaviour
{
    [SerializeField] float projectionTime = 1;
    [SerializeField] float yOffset = 1;
    [SerializeField] float snappingSpeed = 1;
    [SerializeField] GameObject trackingTargetGO;
    [SerializeField] GameObject predictedPosGO;
    [SerializeField] float gizmoRadius = 0.2f;
    [SerializeField] Color gizmoColor = Color.green;
    Vector3 velPrev;
    Vector3 accelPrev;
    Vector3 posPrev;
    Vector3 velAvg;
    Vector3 accelAvg;
    void Awake()
    {
        
    }
    void FixedUpdate()
    {
        // transform.position = GetProjectedPosition(projectionTime);
        predictedPosGO.transform.DOMove(GetProjectedPosition(projectionTime),snappingSpeed);        
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;
        Gizmos.DrawSphere(predictedPosGO.transform.position, gizmoRadius);
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
