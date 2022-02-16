using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugDrawLine : MonoBehaviour
{
    [SerializeField] Transform lineOrigin;
    [SerializeField] Color gizmoColor = Color.green;
    private void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;
        Debug.DrawLine(lineOrigin.position,lineOrigin.position+lineOrigin.forward*50,gizmoColor);
        // Debug.DrawRay(lineOrigin.position,lineOrigin.forward,gizmoColor,50);
    }
}
