using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Team {Team1,Team2}
public enum GateState {PreMatch,MidMatch,PostMatch,Paused}
public class GameManager : Singleton<GameManager>
{
    public float timeRemaining = 60; // seconds
    public bool timerIsRunning = false;
    public int winningScore = 10; 
    public int team1Score;
    public int team2Score;
    public string teamWithFlag = null;
    public bool useStartingScores = false;
    public bool redTeamHasFlag = false;
    public bool blueTeamHasFlag = false;
    [SerializeField] GameObject GameOverPanelTeam1Wins; //TEMP
    [SerializeField] GameObject GameOverPanelTeam2Wins; //TEMP
    [SerializeField] GameObject GameOverPanelTie; //TEMP


    // [Header("Game Events")]
    public delegate void SetScoreHandler(int blueScore, int redScore);
    public static event SetScoreHandler SetScore;
    public delegate void SetTimerHandler(float timeRemaining);
    public static event SetTimerHandler SetTimer;
    public delegate void EndGameHandler();
    public static event EndGameHandler EndGame;

    public delegate void PickupBallHandler(); // This is temporary
    public static event PickupBallHandler PickupBall;// This is temporary
    public delegate void RemoveBallHandler(); // This is temporary
    public static event RemoveBallHandler RemoveBall;// This is temporary
    // Start is called before the first frame update
    void Start()
    {
        StartTimer(timeRemaining);
        if(useStartingScores)
            TriggerEvent_SetScore(team1Score,team2Score);
        else
            TriggerEvent_SetScore(0,0);
    }

    // Update is called once per frame
    void Update()
    {
        if (timerIsRunning)
            {RunTimer();}
    }
    
    public void StartTimer(float timerTime)
    {
        timeRemaining = timerTime;
        TriggerEvent_SetTimer(timerTime);
        timerIsRunning = true;
    }
    
    void RunTimer()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            TriggerEvent_SetTimer(timeRemaining);
        }
        else 
        {
            Debug.Log("Time has run out! Game Over!");
            TriggerEvent_SetTimer(0);
            timerIsRunning = false;
            TriggerEvent_EndGame();
        }
    }
    
    public void GiveTeam1Points(int newTeam1Points)
    {
        this.team1Score = Mathf.Min(team1Score+newTeam1Points, winningScore);
        TriggerEvent_SetScore(this.team1Score,this.team2Score);
    }
    
    public void GiveTeam2Points(int newTeam2Points)
    {
        this.team2Score = Mathf.Min(team2Score+newTeam2Points, winningScore);
        TriggerEvent_SetScore(this.team1Score,this.team2Score);
    }
    
    public void TriggerEvent_SetScore(int team1Score, int team2Score)
    {
        this.team1Score = team1Score;
        this.team2Score = team2Score;
        if(SetScore != null)
            SetScore(team1Score, team2Score);
        if(this.team1Score > winningScore ||this.team2Score > winningScore  )
        {
            TriggerEvent_EndGame();
        }
    }
    
    public void TriggerEvent_SetTimer(float timeRemaining)
    {
        this.timeRemaining = timeRemaining;
        if(SetTimer != null)
            SetTimer(timeRemaining);
    }
    
    public void TriggerEvent_EndGame()
    {
        // TEMP
        if(this.team1Score > this.team2Score)
        {
            GameOverPanelTeam1Wins.SetActive(true);
            GameOverPanelTeam2Wins.SetActive(false);
            GameOverPanelTie.SetActive(false);
        }
        else if(this.team1Score < this.team2Score)
        {
            GameOverPanelTeam2Wins.SetActive(true);
            GameOverPanelTeam1Wins.SetActive(false);
            GameOverPanelTie.SetActive(false);
        }
        else{
            GameOverPanelTie.SetActive(true);
            GameOverPanelTeam1Wins.SetActive(false);
            GameOverPanelTeam2Wins.SetActive(false);
        }
        
        if(EndGame != null)
            EndGame();
    }
    
    public void TEMP_TurnOffGameOverCanvas()
    {
        GameOverPanelTeam1Wins.SetActive(false);
        GameOverPanelTeam2Wins.SetActive(false);
        GameOverPanelTie.SetActive(false);
    }
    
    // Below is a temp function that will be removed as soon as the approprite architecture has been completed
    public void TEMP_TurnOnBallHUD()
    {
        // Debug.Log("Turning on ball hud element");
        if(PickupBall != null)
            PickupBall();
    }
    
    public void TEMP_TurnOffBallHUD()
    {
        if(RemoveBall != null)
            RemoveBall();
    }

    public void TEMP_ToggleRedTeamFlag() {
        redTeamHasFlag = !redTeamHasFlag;
    }
}
