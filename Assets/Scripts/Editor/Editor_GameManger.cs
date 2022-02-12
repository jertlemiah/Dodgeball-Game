using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GameManager))]

public class Editor_GameManger : Editor
{
    public override void OnInspectorGUI()
	{
		GameManager hud = target as GameManager;
        base.OnInspectorGUI();
        if (GUILayout.Button("Add points red"))
		{
			hud.GiveRedPoints(1);
		}
        if (GUILayout.Button("Add points blue"))
		{
			hud.GiveBluePoints(1);
		}
		// Draw default inspector after button...
		
	}
}
