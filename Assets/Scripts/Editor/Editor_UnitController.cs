using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(UnitController))]
public class Editor_UnitController : Editor
{
    public override void OnInspectorGUI()
	{
		UnitController controller = target as UnitController;
        base.OnInspectorGUI();
        DrawUILine(Color.gray);
        // EditorGUILayout.PropertyField(serializedObject.pro)
        // if (GUILayout.Button("This button "))
		// {
			
		// }
        if (GUILayout.Button("Set Player Health to 0"))
		{
			// controller.TakeDamage(100);
            controller.KillPlayer();
		}
        if (GUILayout.Button("Take 1 damage"))
		{
			controller.TakeDamage(1);
		}
	}
    public static void DrawUILine(Color color, int thickness = 2, int padding = 10)
    {
        Rect r = EditorGUILayout.GetControlRect(GUILayout.Height(padding+thickness));
        r.height = thickness;
        r.y+=padding/2;
        r.x-=2;
        r.width +=6;
        EditorGUI.DrawRect(r, color);
    }
}
