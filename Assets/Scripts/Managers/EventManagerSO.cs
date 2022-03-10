using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EventManagerSO", menuName = "SO Channels/EventManager", order = 1)]
public class EventManagerSO : ScriptableObject
{
    public delegate void SetScoreHandler(int team1Score, int team2Score);
    public static event SetScoreHandler E_SetScore;

    public delegate void GiveTeamPointsHandler(Team team, int points);
    public static event GiveTeamPointsHandler E_GiveTeamPoints;

    public delegate void SetTimerHandler(float timeRemaining);
    public static event SetTimerHandler E_SetTimer;

    public delegate void EndMatchHandler(Team winningTeam);
    public static event EndMatchHandler E_EndMatch;
    
    public delegate void PauseGameHandler();
    public static event PauseGameHandler E_PauseGame;

    public delegate void UnpauseGameHandler();
    public static event UnpauseGameHandler E_UnpauseGame;

    public delegate void UpdateFlagStatusHandler(Team team, bool status); // team: the team, status: does team actively have flag
    public static event UpdateFlagStatusHandler E_UpdateFlagStatus;

    public delegate void StartMatchHandler();
    public static event StartMatchHandler E_StartMatch;
    public delegate void StartPrematchHandler();
    public static event StartPrematchHandler E_StartPrematch;

    public delegate void FinishedLoadingHandler();
    public static event FinishedLoadingHandler E_FinishedLoading;
    
    
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
        if(E_EndMatch != null){
            Debug.Log("Triggering Event 'EndGame("+winningTeam.ToString()+")'");
            E_EndMatch(winningTeam);
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

    public static void TriggerEvent_UpdateFlagStatus(Team team, bool status)
    {       
        if(E_UpdateFlagStatus != null){
            Debug.Log("Triggering Event 'UpdateFlagStatus()'");
            E_UpdateFlagStatus(team, status);
        }
    }

    public static void TriggerEvent_StartPrematch()
    {
        if(E_StartPrematch != null){
            Debug.Log("Triggering Event 'E_StartPrematch()'"); 
            E_StartPrematch();
        }        
    }
    public static void TriggerEvent_StartMatch()
    {
        if(E_StartMatch != null){
            Debug.Log("Triggering Event 'E_StartMatch()'"); 
            E_StartMatch();
        }        
    }
    public static void TriggerEvent_FinishedLoading()
    {
        if(E_FinishedLoading != null){
            Debug.Log("Triggering Event 'E_FinishedLoading()'"); 
            E_FinishedLoading();
        }   
    }
}
