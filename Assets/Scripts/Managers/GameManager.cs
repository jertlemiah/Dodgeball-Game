using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Team {Team1,Team2, NoTeam}
public enum GameState {PreMatch,MidMatch,PostMatch,Paused}
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

    void Awake()
    {
        teamDict = new Dictionary<Team, TeamData>();
        foreach(Team team in System.Enum.GetValues(typeof(Team)))
        {
            TeamData teamData = new TeamData();
            teamDict.Add(team,teamData);
        }
        
        if(!gameConstants)
            Debug.LogError(gameObject.name+" does not have gameConstants property assigned");

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

    // Update is called once per frame
    void Update()
    {
        if (timerIsRunning)
            {RunTimer();}
    }
    void StartPrematch()
    {
        EventManagerSO.TriggerEvent_StartPrematch();
        currentState = GameState.PreMatch;
    }
    void StartMatch()
    {
        StartTimer(timeRemaining);
        currentState = GameState.MidMatch;
    }
    
    public void StartTimer(float timerTime)
    {
        timeRemaining = timerTime;
        EventManagerSO.TriggerEvent_SetTimer(timerTime);
        timerIsRunning = true;
    }
    
    void RunTimer()
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
    void EndGame(Team winningTeam)
    {
        currentState = GameState.PostMatch;
    }
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

    public void TogglePause()
    {
        if(currentState == GameState.MidMatch){
            EventManagerSO.TriggerEvent_PauseGame();
        } 
        else if (currentState == GameState.Paused){
            EventManagerSO.TriggerEvent_UnpauseGame();
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0;
        currentState = GameState.Paused;
    }

    void UnpauseGame()
    {
        Time.timeScale = 1;
        currentState = GameState.MidMatch;
    }
}
