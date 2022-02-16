using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugDrawLine : MonoBehaviour
{
    [SerializeField] Transform lineOrigin;
    [SerializeField] Color gizmoColor = Color.green;
    [SerializeField] Vector3 eulerOffset = Vector3.zero;
    private void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;
        Vector3 end = lineOrigin.position+lineOrigin.forward*50;

        Debug.DrawLine(lineOrigin.position,Quaternion.Euler(eulerOffset)*end,gizmoColor);
        // Debug.DrawRay(lineOrigin.position,lineOrigin.forward,gizmoColor,50);
    }
}
