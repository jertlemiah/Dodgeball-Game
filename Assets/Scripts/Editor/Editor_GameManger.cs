using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GameManager))]

public class Editor_GameManger : Editor
{
    public override void OnInspectorGUI()
	{
		GameManager manager = target as GameManager;
        base.OnInspectorGUI();
        if (GUILayout.Button("Add points red"))
		{
			manager.UpdateScore("RED", 1);

		}
        if (GUILayout.Button("Add points blue"))
		{
			manager.UpdateScore("BLUE", 1);
		}
		if (GUILayout.Button("Turn off 'Game Over' canvas"))
		{
			manager.TEMP_TurnOffGameOverCanvas();
		}
		if (GUILayout.Button("Toggle Blue Team Flag"))
		{
			Debug.Log(manager.blueTeamHasFlag);
			manager.HandleFlag("BLUE", !manager.blueTeamHasFlag);
		}

		
		// Draw default inspector after button...
		
	}
}
