using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public float timeRemaining = 60; // seconds
    public bool timerIsRunning = false;
    public float pointsToWin = 10; // This var needs to be in the GameManager
    public int team2Score;
    public int team1Score;

    // [Header("Game Events")]
    public delegate void SetScoreHandler(int blueScore, int redScore);
    public static event SetScoreHandler SetScore;
    public delegate void SetTimerHandler(float timeRemaining);
    public static event SetTimerHandler SetTimer;
    // Start is called before the first frame update
    void Start()
    {
        StartTimer(timeRemaining);
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
        }
    }
    public void GiveTeam1Points(int newTeam1Points)
    {
        TriggerEvent_SetScore(this.team1Score+newTeam1Points,this.team2Score);
    }
    public void GiveTeam2Points(int newTeam2Points)
    {
        TriggerEvent_SetScore(this.team1Score,this.team2Score+newTeam2Points);
    }
    public void TriggerEvent_SetScore(int team1Score, int team2Score)
    {
        this.team1Score = team1Score;
        this.team2Score = team2Score;
        if(SetScore != null)
            SetScore(team1Score, team2Score);
    }
    public void TriggerEvent_SetTimer(float timeRemaining)
    {
        this.timeRemaining = timeRemaining;
        if(SetTimer != null)
            SetTimer(timeRemaining);
    }
}
