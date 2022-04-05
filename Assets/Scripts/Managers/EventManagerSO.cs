using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary> 
///<para> The Event Manager Scriptable Object is responsible for tracking and handling all interactions with system-wide events. </para>
///<para> To subscribe a function to listen for an event, the "+=" operator must be used in Awake() and the "-=" operator must be used in OnDisable().
///       The subscribing function must have the exact same arguments as the event. </para>
///<example> 
///     Example: the "E_SetScore" event requires two inputs (int team1Score, int team2Score). A local function SetScore must also have (int, int) arguments.
///     In Awake(), the following line of code must be included: EventManagerSO.E_SetScore += SetScore; , 
///     and In OnDisable(), the following line of code must be included: EventManagerSO.E_SetScore -= SetScore;
///</example>
///<para> To trigger an event, simply call the corresponding TriggerEvent_ function with the required arguments, for example EventManagerSO.TriggerEvent_SetScore(10,10);</para>
/// </summary>
[CreateAssetMenu(fileName = "EventManagerSO", menuName = "SO Channels/EventManager", order = 1)]
public class EventManagerSO : ScriptableObject
{
    public delegate void SetScoreHandler(int team1Score, int team2Score);
    /// <summary> E_SetScore accepts two arguments (int team1Score, int team2Score) and is used by the GameManager and HUDcontroller to keep up with the current game score.</summary>
    public static event SetScoreHandler E_SetScore;

    public delegate void GiveTeamPointsHandler(Team team, int points);
    /// <summary> E_GiveTeamPoints accepts two arguments (Team team, int points) to specify how many points to give to which team.</summary>
    public static event GiveTeamPointsHandler E_GiveTeamPoints;

    public delegate void SetTimerHandler(float timeRemaining);
    /// <summary> E_SetTimer accepts one argument (float timeRemaining) to specify how much time is left in the match.</summary>
    public static event SetTimerHandler E_SetTimer;

    public delegate void LoadingProgressHandler(float progress);
    /// <summary> E_SetTimer accepts one argument (float timeRemaining) to specify how much time is left in the match.</summary>
    public static event LoadingProgressHandler E_LoadingProgress;

    public delegate void EndMatchHandler(Team winningTeam);
    /// <summary> E_EndMatch accepts one argument (Team winningTeam) to notify which team has won the match.</summary>
    public static event EndMatchHandler E_EndMatch;
    
    public delegate void PauseGameHandler();
    /// <summary> E_PauseGame simply marks when the GameState switches to the Paused state.</summary>
    public static event PauseGameHandler E_PauseGame;

    public delegate void UnpauseGameHandler();
    /// <summary> E_UnpauseGame simply marks when the GameState switches from the Paused state.</summary>
    public static event UnpauseGameHandler E_UnpauseGame;

    public delegate void UpdateFlagStatusHandler(Team team, bool status); // team: the team, status: does team actively have flag
    public static event UpdateFlagStatusHandler E_UpdateFlagStatus;

    public delegate void StartMatchHandler();
    /// <summary> E_StartMatch marks when the GameState switches from the PreMatch state to the MidMatch state.</summary>
    public static event StartMatchHandler E_StartMatch;
    public delegate void StartPrematchHandler();
    /// <summary> E_StartPrematch marks when the GameState switches to the PreMatch state.</summary>
    public static event StartPrematchHandler E_StartPrematch;

    public delegate void FinishedLoadingHandler();
    /// <summary> E_FinishedLoading marks when GameSceneManager has finished loading the new scenes.</summary>
    public static event FinishedLoadingHandler E_FinishedLoading;

    public delegate void HideHUDHandler();
    /// <summary> E_HideHUD is used to hide the HUD, such as at the end of a match.</summary>
    public static event HideHUDHandler E_HideHUD;

    public delegate void UnhideHUDHandler();
    /// <summary> E_UnhideHUD is used to show a hidden HUD.</summary>
    public static event UnhideHUDHandler E_UnhideHUD;

    public delegate void PickUpTextHandler(bool activeStatus);
    /// <summary> E_PauseGame simply marks when the GameState switches to the Paused state.</summary>
    public static event PickUpTextHandler E_PickUpText;

    public delegate void SceneLoadedHandler(SceneIndex sceneIndex);
    /// <summary> E_PauseGame simply marks when the GameState switches to the Paused state.</summary>
    public static event SceneLoadedHandler E_SceneLoaded;

    public delegate void StopMusicHandler();
    /// <summary> E_StopMusic is used to simply stop the currently playing music.</summary>
    public static event StopMusicHandler E_StopMusic;

    
    /// <summary> Triggers the E_GiveTeamPoints(Team team, int points) event. </summary>
    public static void TriggerEvent_GiveTeamPoints(Team team, int points)
    {
        if(E_GiveTeamPoints != null){
            Debug.Log("Triggering Event 'GiveTeamPoints("+team.ToString()+","+points+")'");
            E_GiveTeamPoints(team, points);
        }
    }

    /// <summary> Triggers the E_SetScore(int team1Score, int team2Score) event. </summary>
    public static void TriggerEvent_SetScore(int team1Score, int team2Score)
    {
        if(E_SetScore != null){
            Debug.Log("Triggering Event 'SetScore("+team1Score+","+team2Score+")'");
            E_SetScore(team1Score, team2Score);
        }        
    }

    /// <summary> Triggers the E_SetTimer(float timeRemaining) event. </summary>
    public static void TriggerEvent_SetTimer(float timeRemaining)
    {
        if(E_SetTimer != null){
            // Debug.Log("Triggering Event 'SetTimer("+timeRemaining+")'");  // This gets called way too much, lol          
            E_SetTimer(timeRemaining);
        }        
    }

    /// <summary> Triggers the E_LoadingProgress(float progress) event. </summary>
    public static void TriggerEvent_LoadingProgress(float progress)
    {
        if(E_LoadingProgress != null){
            Debug.Log("Triggering Event 'LoadingProgress("+progress+")'");  // This gets called way too much, lol          
            E_LoadingProgress(progress);
        }        
    }

    /// <summary> Triggers the E_EndMatch(Team winningTeam) event. </summary>
    public static void TriggerEvent_EndGame(Team winningTeam)
    {       
        if(E_EndMatch != null){
            Debug.Log("Triggering Event 'EndGame("+winningTeam.ToString()+")'");
            E_EndMatch(winningTeam);
        }       
    }

    /// <summary> Triggers the E_PauseGame() event. </summary>
    public static void TriggerEvent_PauseGame()
    {       
        if(E_PauseGame != null){
            Debug.Log("Triggering Event 'PauseGame()'");
            E_PauseGame();
        }
    }

    /// <summary> Triggers the E_UnpauseGame() event. </summary>
    public static void TriggerEvent_UnpauseGame()
    {       
        if(E_UnpauseGame != null){
            Debug.Log("Triggering Event 'UnpauseGame()'");
            E_UnpauseGame();
        }
    }

    /// <summary> Triggers the E_UpdateFlagStatus(Team team, bool status) event. </summary>
    public static void TriggerEvent_UpdateFlagStatus(Team team, bool status)
    {       
        if(E_UpdateFlagStatus != null){
            Debug.Log("Triggering Event 'UpdateFlagStatus()'");
            E_UpdateFlagStatus(team, status);
        }
    }

    /// <summary> Triggers the E_StartPrematch() event. </summary>
    public static void TriggerEvent_StartPrematch()
    {
        if(E_StartPrematch != null){
            Debug.Log("Triggering Event 'E_StartPrematch()'"); 
            E_StartPrematch();
        }        
    }

    /// <summary> Triggers the E_StartMatch() event. </summary>
    public static void TriggerEvent_StartMatch()
    {
        if(E_StartMatch != null){
            Debug.Log("Triggering Event 'E_StartMatch()'"); 
            E_StartMatch();
        }        
    }

    /// <summary> Triggers the E_FinishedLoading() event. </summary>
    public static void TriggerEvent_FinishedLoading()
    {
        if(E_FinishedLoading != null){
            Debug.Log("Triggering Event 'E_FinishedLoading()'"); 
            E_FinishedLoading();
        }   
    }

    /// <summary> Triggers the E_UnhideHUD() event. </summary>
    public static void TriggerEvent_UnhideHUD()
    {       
        if(E_UnhideHUD != null){
            Debug.Log("Triggering Event 'E_UnhideHUD()'");
            E_UnhideHUD();
        }
    }

    /// <summary> Triggers the E_HideHUD() event. </summary>
    public static void TriggerEvent_HideHUD()
    {       
        if(E_HideHUD != null){
            Debug.Log("Triggering Event 'E_HideHUD()'");
            E_HideHUD();
        }
    }

    /// <summary> Triggers the E_PickUpText() event. </summary>
    public static void TriggerEvent_PickUpText(bool activeStatus)
    {       
        if(E_PickUpText != null){
            Debug.Log("Triggering Event 'E_PickUpText()'");
            E_PickUpText(activeStatus);
        }
    }

    /// <summary> Triggers the E_SceneLoaded() event. </summary>
    public static void TriggerEvent_SceneLoaded(SceneIndex sceneIndex)
    {       
        if(E_SceneLoaded != null){
            Debug.Log("Triggering Event 'E_SceneLoaded("+sceneIndex.ToString()+")'");
            E_SceneLoaded(sceneIndex);
        } else {
            Debug.Log("Cannot trigger Event 'E_SceneLoaded("+sceneIndex.ToString()+")'");
        }
    }

    /// <summary> Triggers the E_StopMusic() event. </summary>
    public static void TriggerEvent_StopMusic()
    {       
        if(E_StopMusic != null){
            Debug.Log("Triggering Event 'E_StopMusic()'");
            E_StopMusic();
        }
    }

    
}
