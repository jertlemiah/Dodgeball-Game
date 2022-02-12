using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HudController : MonoBehaviour
{
    [SerializeField] private TMP_Text textTimer;
    [SerializeField] private TMP_Text textTeam1Score;
    [SerializeField] private Slider sliderTeam1Score;
    [SerializeField] private TMP_Text textTeam2Score;
    [SerializeField] private Slider sliderTeam2Score;
    private GameManager gameManager;
    // public float timeRemaining = 60; // seconds
    // public bool timerIsRunning = false;
    // float pointsToWin = 10; // This var needs to be in the GameManager
    
    void Awake()
    {
        // StartTimer(timeRemaining);
        // SetScore(0,0);
        gameManager = GameManager.Instance;
        GameManager.SetScore += SetScoreUI;
        GameManager.SetTimer += DisplayTime;
    } 
    void OnDisable()
    {
        GameManager.SetScore -= SetScoreUI;
        GameManager.SetTimer -= DisplayTime;
    }
  
    // Update is called once per frame
    void Update()
    {

    }
    
    public void SetScoreUI(int team1Score, int team2Score)
    {
        textTeam1Score.text = team1Score.ToString();
        sliderTeam1Score.value = team1Score/gameManager.pointsToWin;
        textTeam2Score.text = team2Score.ToString();
        sliderTeam2Score.value = team2Score/gameManager.pointsToWin;
    }
    
    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        textTimer.text = string.Format("{0:0}:{1:00}", minutes, seconds);
    }
}
