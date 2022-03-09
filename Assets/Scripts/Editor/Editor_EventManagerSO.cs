using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(EventManagerSO))]
public class Editor_EventManagerSO : Editor
{
    public override void OnInspectorGUI()
	{
		EventManagerSO manager = target as EventManagerSO;
        base.OnInspectorGUI();
        if (GUILayout.Button("Give team 1 a point"))
		{
			EventManagerSO.GiveTeamPoints(Team.Team1,1);
		}
        if (GUILayout.Button("Give team 2 a point"))
		{
			EventManagerSO.GiveTeamPoints(Team.Team2,1);
		}
		// if (GUILayout.Button("Turn off 'Game Over' canvas"))
		// {
		// 	manager.TEMP_TurnOffGameOverCanvas();
		// }
		
        if (GUILayout.Button("End Game: Team 1 wins")){
			EventManagerSO.TriggerEvent_EndGame(Team.Team1);
		}
        if (GUILayout.Button("End Game: Team 2 wins")){
			EventManagerSO.TriggerEvent_EndGame(Team.Team2);
		}
        if (GUILayout.Button("End Game: tie")){
			EventManagerSO.TriggerEvent_EndGame(Team.NoTeam);
		}
        if (GUILayout.Button("Pause Game")){
			EventManagerSO.TriggerEvent_PauseGame();
		}
        if (GUILayout.Button("Unpause Game")){
			EventManagerSO.TriggerEvent_UnpauseGame();
		}
		
	}
}
