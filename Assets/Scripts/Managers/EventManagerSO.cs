using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EventManagerSO", menuName = "SO Channels/EventManager", order = 1)]
public class EventManagerSO : ScriptableObject
{
    public delegate void SetScoreHandler(int blueScore, int redScore);
    public static event SetScoreHandler SetScore;
    public delegate void SetTimerHandler(float timeRemaining);
    public static event SetTimerHandler SetTimer;
    public delegate void EndGameHandler();
    public static event EndGameHandler EndGame;
    
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
        // Debug.Log("Setting new score, team1:"+team1Score+" team2: "+team2Score);
        this.team1Score = team1Score;
        this.team2Score = team2Score;
        if(SetScore != null)
            SetScore(team1Score, team2Score);
        if(this.team1Score >= winningScore ||this.team2Score >= winningScore  )
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
}
