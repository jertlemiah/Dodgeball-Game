using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EventManagerSO", menuName = "SO Channels/EventManager", order = 1)]
public class EventManagerSO : ScriptableObject
{
    public delegate void SetScoreHandler(int blueScore, int redScore);
    public static event SetScoreHandler E_SetScore;
    public delegate void GiveTeamPointsHandler(Team team, int points);
    public static event GiveTeamPointsHandler E_GiveTeamPoints;
    public delegate void SetTimerHandler(float timeRemaining);
    public static event SetTimerHandler E_SetTimer;
    public delegate void EndGameHandler(Team winningTeam);
    public static event EndGameHandler E_EndGame;
    public delegate void PauseGameHandler();
    public static event PauseGameHandler E_PauseGame;
    public delegate void UnpauseGameHandler();
    public static event UnpauseGameHandler E_UnpauseGame;
    
    public static void GiveTeamPoints(Team team, int points)
    {
        if(E_GiveTeamPoints != null){
            Debug.Log("Triggering Event 'GiveTeamPoints("+team.ToString()+","+points+")'");
            E_GiveTeamPoints(team, points);
        }
    }
    public static void TriggerEvent_SetScore(int team1Score, int team2Score)
    {
        if(E_SetScore != null){
            Debug.Log("Triggering Event 'SetScore("+team1Score+","+team2Score+")'");
            E_SetScore(team1Score, team2Score);
        }        
    }
    public static void TriggerEvent_SetTimer(float timeRemaining)
    {
        if(E_SetTimer != null){
            // Debug.Log("Triggering Event 'SetTimer("+timeRemaining+")'");  // This gets called way too much, lol          
            E_SetTimer(timeRemaining);
        }        
    }
    public static void TriggerEvent_EndGame(Team winningTeam)
    {       
        if(E_EndGame != null){
            Debug.Log("Triggering Event 'EndGame("+winningTeam.ToString()+")'");
            E_EndGame(winningTeam);
        }       
    }
    public static void TriggerEvent_PauseGame()
    {       
        if(E_PauseGame != null){
            Debug.Log("Triggering Event 'PauseGame()'");
            E_PauseGame();
        }
    }
    public static void TriggerEvent_UnpauseGame()
    {       
        if(E_UnpauseGame != null){
            Debug.Log("Triggering Event 'UnpauseGame()'");
            E_UnpauseGame();
        }
    }
}
