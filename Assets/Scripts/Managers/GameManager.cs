using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary> This enum simply represents the different teams {Team1, Team2, NoTeam}. Option "NoTeam" is a sort of default in case of ties. </summary>
public enum Team {Team1, Team2, NoTeam}

/// <summary> The current state of the GameManager {PreMatch, MidMatch, PostMatch, Paused}. "PreMatch" is for when the match is being set up. "MidMatch" is literally just while a match is playing.
/// "PostMatch" is after a match is finished while the MatchResults screen is visible. And "Paused" is when the game is paused. </summary>
public enum GameState {PreMatch, MidMatch, PostMatch, Paused, MainMenu}

/// <summary> TeamData is a struct that stores data about a specific team. Used in the GameManager in a dict<Team, TeamData> named teamDict. </summary>
public struct TeamData
{
    public int teamScore;
    public List<UnitController> teamMembers;
}

/// <summary> 
///     GameManager is a singleton responsible for managing various attributes used in a match, such as the game timer or team scores.
/// </summary>
public class GameManager : Singleton<GameManager>
{
    [SerializeField] GameConstantsSO gameConstants;

    [Space(10)][Header("Current Status")]
    public GameState currentState;

    [Space(10)][Header("Game Timer")]
    public float timeRemaining = 60; // seconds
    public bool timerIsRunning = false;

    [Space(10)][Header("Team Scores")]
    public int team1Score;
    public int team2Score;
    public bool useStartingScores = false;

    public Dictionary<Team, TeamData> teamDict;
    public delegate void PickupBallHandler(); // This is temporary
    public static event PickupBallHandler PickupBall;// This is temporary
    public delegate void RemoveBallHandler(); // This is temporary
    public static event RemoveBallHandler RemoveBall;// This is temporary

    void Start()
    {
        // StartTimer(timeRemaining);
        // EventManagerSO.TriggerEvent_SetScore(0,0);
        if(useStartingScores)
            EventManagerSO.TriggerEvent_SetScore(team1Score,team2Score);
        else
            EventManagerSO.TriggerEvent_SetScore(0,0);
    }

    /// Awake triggers before Start.
    new void Awake()
    {
        base.Awake();
        teamDict = new Dictionary<Team, TeamData>();
        foreach(Team team in System.Enum.GetValues(typeof(Team)))
        {
            TeamData teamData = new TeamData();
            teamDict.Add(team,teamData);
        }

        if(!gameConstants)
            Debug.LogError(gameObject.name+" does not have gameConstants property assigned");

        // Event Subscriptions
        EventManagerSO.E_SetScore += SetScore;
        EventManagerSO.E_EndMatch += EndGame;
        EventManagerSO.E_GiveTeamPoints += GiveTeamPoints;
        EventManagerSO.E_PauseGame += PauseGame;
        EventManagerSO.E_UnpauseGame += UnpauseGame;
        EventManagerSO.E_FinishedLoading += StartPrematch;
        EventManagerSO.E_StartMatch += StartMatch;
        // EventManagerSO.E_SetTimer += se
        // EventManagerSO.SetTimer += SetTimerUI;
        // GameManager.PickupBall += DisplayHeldBall;
        // GameManager.RemoveBall += HideHeldBall;
    } 

    void OnDisable()
    {
        // Event Unsubscriptions
        EventManagerSO.E_SetScore -= SetScore;
        EventManagerSO.E_EndMatch -= EndGame;
        EventManagerSO.E_GiveTeamPoints -= GiveTeamPoints;
        EventManagerSO.E_PauseGame -= PauseGame;
        EventManagerSO.E_UnpauseGame -= UnpauseGame;
        EventManagerSO.E_FinishedLoading -= StartPrematch;
        EventManagerSO.E_StartMatch -= StartMatch;
        // GameManager.SetTimer -= SetTimerUI;
        // GameManager.PickupBall -= DisplayHeldBall;
        // GameManager.RemoveBall -= HideHeldBall;
    }

    void Update()
    {
        if (timerIsRunning)
            {RunTimer();}
    }

    /// <summary> Triggered by E_FinishedLoading. Triggers the StartPrematch event once the scene is done loading and changes the gameState to GameState.PreMatch. 
    ///           These two events were separated out in case we wanted the player to click a button or something like that to actually start the match. </summary>
    void StartPrematch()
    {
        // Check to see if the main menu is open
        bool mainMenuOpen = GameSceneManager.Instance.IsSceneOpen(SceneIndex.TITLE_SCREEN);
        
        if(mainMenuOpen){
            EventManagerSO.TriggerEvent_HideHUD();
            currentState = GameState.MainMenu;
        } else {
            EventManagerSO.TriggerEvent_StartPrematch();
            currentState = GameState.PreMatch;
        }
        
    }

    /// <summary> Triggered by E_StartMatch. Starts the game timer and changes the gameState to GameState.MidMatch.</summary>
    void StartMatch()
    {
        StartTimer(timeRemaining);
        currentState = GameState.MidMatch;
    }
    
    /// <summary> Sets the starting time for the timer to (float timerTime), then turns on the timer. </summary>
    public void StartTimer(float timerTime)
    {
        timeRemaining = timerTime;
        EventManagerSO.TriggerEvent_SetTimer(timerTime);
        timerIsRunning = true;
    }
    
    /// <summary> Decrements the timeRemaining and triggers the E_SetTimer(float timeRemaining) event every Update() call. 
    /// <para>    When the timer reaches 0, the GameManager checks to see which team won and triggers the E_EndGame(Team winningTeam) event. </para> </summary>
    private void RunTimer()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            EventManagerSO.TriggerEvent_SetTimer(timeRemaining);
        }
        else 
        {
            Debug.Log("Time has run out! Game Over!");
            EventManagerSO.TriggerEvent_SetTimer(0);
            timerIsRunning = false;

            if(team1Score > team2Score){
                EventManagerSO.TriggerEvent_EndGame(Team.Team1);
            } else if(team1Score < team2Score){
                EventManagerSO.TriggerEvent_EndGame(Team.Team2);
            } else {
                EventManagerSO.TriggerEvent_EndGame(Team.NoTeam);
            }
            
        }
    }

    /// <summary> Triggered by the E_EndGame(Team winningTeam) event. Currently only sets the gameState to GameState.PostMatch. </summary>
    void EndGame(Team winningTeam)
    {
        currentState = GameState.PostMatch;
    }

    /// <summary> Triggered by the E_GiveTeamPoints(Team team, int points) event since the GameManager is the only accurate place for storing the current team scores.
    ///           Then triggers the E_SetScore(int team1Score,int team2Score) event. </summary>
    private void GiveTeamPoints(Team team, int points)
    {
        // TeamData teamData = teamDict[team];
        // teamData.teamScore += points;
        // teamDict[team] = teamData;
        if(team == Team.Team1){
            team1Score += points;
        } else if(team == Team.Team2){
            team2Score += points;
        }
        EventManagerSO.TriggerEvent_SetScore(team1Score,team2Score);
    }

    /// <summary> Triggered by the E_SetScore(int team1Score, int team2Score) event. Determines if the game has ended due to a team receiving enough points to win. </summary>
    private void SetScore(int team1Score, int team2Score)
    {
        // Debug.Log("Setting new score, team1:"+team1Score+" team2: "+team2Score);
        this.team1Score = team1Score;
        this.team2Score = team2Score;
        if(this.team1Score >= gameConstants.WINNING_SCORE ||this.team2Score >= gameConstants.WINNING_SCORE )
        {
            if(team1Score > team2Score){
                EventManagerSO.TriggerEvent_EndGame(Team.Team1);
            } else if(team1Score < team2Score){
                EventManagerSO.TriggerEvent_EndGame(Team.Team2);
            }
        }
    }    

    GameState stateBeforePause = GameState.PreMatch;

    /// <summary> Called by the InputManager when the player presses the pause button (start on a controller, Tab on keyboard). 
    /// <para>  If gameState is GameState.MidMatch, the E_PauseGame() event is triggered. </para>
    /// <para>  If gamestate is GameState.Paused, the E_UnPauseGame() event is triggered. </para></summary>
    public void TogglePause()
    {
        if (currentState == GameState.Paused){
            EventManagerSO.TriggerEvent_UnpauseGame();
        }
        else //if(currentState == GameState.MidMatch)
        {
            EventManagerSO.TriggerEvent_PauseGame();
        }
    }

    /// <summary> Triggered from the E_PauseGame() Event. 
    /// Simply sets the current state to GameState.Paused and sets the timescale to 0. </summary>
    void PauseGame()
    {
        Time.timeScale = 0;
        stateBeforePause = currentState;
        currentState = GameState.Paused;
    }

    /// <summary> Triggered from the E_UnpauseGame() Event. 
    /// Simply sets the current state to GameState.MidMatch and sets the timescale to 1. </summary>
    void UnpauseGame()
    {
        Time.timeScale = 1;
        // currentState = GameState.MidMatch;
        currentState = stateBeforePause;
    }
}
