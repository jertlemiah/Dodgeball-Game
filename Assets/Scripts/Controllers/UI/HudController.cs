using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HudController : MonoBehaviour
{
    [SerializeField] GameConstantsSO gameConstants;
    [SerializeField] private TMP_Text textTimer;
    [SerializeField] private TMP_Text textTeam1Score;
    [SerializeField] private Slider sliderTeam1Score;
    [SerializeField] private TMP_Text textTeam2Score;
    [SerializeField] private Slider sliderTeam2Score;
    [SerializeField] GameObject ballRenderTexture;
    // private GameManager gameManager;
    
    void Awake()
    {
        if(!gameConstants)
            Debug.LogError(gameObject.name+" does not have gameConstants property assigned");
        // StartTimer(timeRemaining);
        // SetScore(0,0);
        EventManagerSO.E_SetScore += SetScoreUI;
        EventManagerSO.E_SetTimer += SetTimerUI;
        // gameManager = GameManager.Instance;
        // GameManager.SetScore += SetScoreUI;
        // GameManager.SetTimer += SetTimerUI;
        // GameManager.PickupBall += DisplayHeldBall;
        // GameManager.RemoveBall += HideHeldBall;
    } 
    void OnDisable()
    {
        EventManagerSO.E_SetScore -= SetScoreUI;
        EventManagerSO.E_SetTimer -= SetTimerUI;
        // GameManager.SetScore -= SetScoreUI;
        // GameManager.SetTimer -= SetTimerUI;
        // GameManager.PickupBall -= DisplayHeldBall;
        // GameManager.RemoveBall -= HideHeldBall;
    }
  
    // Update is called once per frame
    void Update()
    {

    }
    
    public void SetScoreUI(int team1Score, int team2Score)
    {
        textTeam1Score.text = team1Score.ToString();
        sliderTeam1Score.value = (float)team1Score/gameConstants.WINNING_SCORE;
        // sliderTeam1Score.value = (float)team1Score/gameManager.winningScore;
        textTeam2Score.text = team2Score.ToString();
        sliderTeam2Score.value = (float)team2Score/gameConstants.WINNING_SCORE;
        // sliderTeam2Score.value = (float)team2Score/gameManager.winningScore;
    }
    
    void SetTimerUI(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        textTimer.text = string.Format("{0:0}:{1:00}", minutes, seconds);
    }
    void DisplayHeldBall()
    {
        ballRenderTexture.SetActive(true);
    }
    void HideHeldBall()
    {
        ballRenderTexture.SetActive(false);
    }
}
