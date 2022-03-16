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
			EventManagerSO.TriggerEvent_GiveTeamPoints(Team.Team1,1);
		}
        if (GUILayout.Button("Give team 2 a point"))
		{
			EventManagerSO.TriggerEvent_GiveTeamPoints(Team.Team2,1);
		}

		if (GUILayout.Button("Team 1 Grabs Flag"))
		{
			EventManagerSO.TriggerEvent_UpdateFlagStatus(Team.Team1, true);
		}
		if (GUILayout.Button("Team 2 Grabs Flag"))
		{
			EventManagerSO.TriggerEvent_UpdateFlagStatus(Team.Team2, true);
		}
		if (GUILayout.Button("Team 1 Drops/Returns Flag"))
		{
			EventManagerSO.TriggerEvent_UpdateFlagStatus(Team.Team1, false);
		}
		if (GUILayout.Button("Team 2 Drops/Returns Flag"))
		{
			EventManagerSO.TriggerEvent_UpdateFlagStatus(Team.Team2, false);
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
		
		if (GUILayout.Button("Finished Loading Scene")){
			EventManagerSO.TriggerEvent_FinishedLoading();	
		}
        if (GUILayout.Button("Start Prematch Preparations")){
			EventManagerSO.TriggerEvent_StartPrematch();
		}
		if (GUILayout.Button("Start Match")){
			EventManagerSO.TriggerEvent_StartMatch();
		}
	}
}
