using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MainMenuController))]

public class Editor_MainMenuController : Editor
{
    public override void OnInspectorGUI()
	{
		MainMenuController mainMenu = target as MainMenuController;
        base.OnInspectorGUI();
        if (GUILayout.Button("Change Active Screen"))
		{
			// Debug.Log("'Change Active Screen' doesn't do anything right now");
			mainMenu.SwitchToScreen(mainMenu.overrideScreen,true);
		}
	}
}
