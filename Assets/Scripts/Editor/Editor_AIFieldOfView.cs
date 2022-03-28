using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(AIFieldOfView))]
public class Editor_AIFieldOfView : Editor
{
    
    void OnSceneGUI()
    {
        AIFieldOfView fow = (AIFieldOfView)target;
        Handles.color = Color.white;
        Handles.DrawWireArc(fow.transform.position, Vector3.up, Vector3.forward,360,fow.outerViewRadius);
        Handles.color = Color.yellow;
        Handles.DrawWireArc(fow.transform.position, Vector3.up, Vector3.forward,360,fow.innerViewRadius);
         Handles.DrawWireArc(fow.transform.position, Vector3.up, Vector3.forward,360,fow.middleViewRadius);

        Vector3 viewAngleA = fow.DirFromAngle(-fow.outerViewAngle / 2, false);
        Vector3 viewAngleB = fow.DirFromAngle(fow.outerViewAngle / 2, false);

        // Handles.color = Color.white;
        Handles.DrawLine(fow.transform.position, fow.transform.position + viewAngleA * fow.outerViewRadius);
        Handles.DrawLine(fow.transform.position, fow.transform.position + viewAngleB * fow.outerViewRadius);

        Handles.color = Color.magenta;
        foreach (Transform visibleTarget in fow.visiblePlayers) {
            Vector3 targetCenter = visibleTarget.position;
            targetCenter = targetCenter + visibleTarget.GetComponent<CharacterController>().center;
            Handles.DrawLine (fow.transform.position, targetCenter);
        }
        Handles.color = Color.green;
        foreach (Transform visibleTarget in fow.visibleBalls) {
            Handles.DrawLine (fow.transform.position, visibleTarget.position);
        }
    }
}
