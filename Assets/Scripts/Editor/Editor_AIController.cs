using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(AIController))]
public class Editor_AIController : Editor
{
    public override void OnInspectorGUI()
	{
		AIController controller = target as AIController;
        base.OnInspectorGUI();
        if (GUILayout.Button("Toggle move to target Transform"))
		{
			// EventManagerSO.TriggerEvent_GiveTeamPoints(Team.Team1,1);
            controller.moveToTarget = !controller.moveToTarget;
		}
	}
}
