using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MainMenuController))]

public class Editor_MainMenuController : Editor
{
    public override void OnInspectorGUI()
	{
		GameManager manager = target as GameManager;
        base.OnInspectorGUI();
        if (GUILayout.Button("Change Active Screen"))
		{
			Debug.Log("'Change Active Screen' doesn't do anything right now");
		}
	}
}
