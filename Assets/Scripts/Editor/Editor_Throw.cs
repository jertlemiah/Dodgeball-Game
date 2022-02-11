using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Throw))]
public class Editor_Throw : Editor
{
    private Throw throwTarget;
    // Start is called before the first frame update
    void OnEnable()
    {
        throwTarget = (Throw) target;
    }

    public override void OnInspectorGUI()
	{
		if (GUILayout.Button("Throw Ball"))
		{
			throwTarget.ThrowBall();
		}

		// Draw default inspector after button...
		base.OnInspectorGUI();
	}
}
