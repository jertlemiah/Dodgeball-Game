using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    
    private int bluePoints = 0;
    private int redPoints = 0;
    public float timeRemaining = 60; // seconds
    public bool timerIsRunning = false;
    
    public Text timeText;
    public Text bluePointsText;
    public Text redPointsText;

    // Start is called before the first frame update
    void Start()
    {
        timerIsRunning = false;
        bluePointsText.text = bluePoints.ToString();
        redPointsText.text = redPoints.ToString();
    }

    // Update is called once per frame
    private void Update()
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
                timerIsRunning = false;
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

}
