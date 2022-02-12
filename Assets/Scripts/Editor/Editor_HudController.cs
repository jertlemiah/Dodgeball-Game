using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(HudController))]

public class Editor_HudController : Editor
{
    public override void OnInspectorGUI()
	{
		HudController hud = target as HudController;
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
