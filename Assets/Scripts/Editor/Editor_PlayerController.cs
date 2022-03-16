using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PlayerController))]

public class Editor_PlayerController : Editor
{
    public override void OnInspectorGUI()
	{
		PlayerController controller = target as PlayerController;
        base.OnInspectorGUI();
        if (GUILayout.Button("Set Player Health to 0"))
		{
			controller.TakeDamage(100);
		}
	}
}
