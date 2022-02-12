using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HudController : MonoBehaviour
{
    [SerializeField] private TMP_Text textTimer;
    [SerializeField] private TMP_Text textBlueScore;
    [SerializeField] private Slider sliderBlueScore;
    [SerializeField] private TMP_Text textRedScore;
    [SerializeField] private Slider sliderRedScore;
    public float timeRemaining = 60; // seconds
    public bool timerIsRunning = false;
    float pointsToWin = 10; // This var needs to be in the GameManager
    
    // Start is called before the first frame update
    void Start()
    {
        StartTimer(timeRemaining);
        SetScore(0,0);
    } 
  
    // Update is called once per frame
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else 
            {
                Debug.Log("Time has run out! Game Over!");
                timeRemaining = 0;
                DisplayTime(0);
                timerIsRunning = false;
            }
        }
    }
    public void GiveBluePoints(int bluePoints)
    {
        int currentRedScore = int.Parse(textRedScore.text);//Need to get this from the GameManager
        int currentBlueScore = int.Parse(textBlueScore.text);//Need to get this from the GameManager
        currentBlueScore += bluePoints;
        SetScore(currentBlueScore,currentRedScore);
    }
    public void GiveRedPoints(int redPoints)
    {
        int currentRedScore = int.Parse(textRedScore.text);//Need to get this from the GameManager
        currentRedScore += redPoints;
        int currentBlueScore = int.Parse(textBlueScore.text);//Need to get this from the GameManager
        SetScore(currentBlueScore,currentRedScore);
    }
    public void SetScore(int blueScore, int redScore)
    {
        textBlueScore.text = blueScore.ToString();
        sliderBlueScore.value = blueScore/pointsToWin;
        textRedScore.text = redScore.ToString();
        sliderRedScore.value = redScore/pointsToWin;
    }
    public void StartTimer(float timerTime)
    {
        timeRemaining = timerTime;
        DisplayTime(timerTime);
        timerIsRunning = true;
    }
    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        textTimer.text = string.Format("{0:0}:{1:00}", minutes, seconds);
    }
}
