using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;

public class HudController : MonoBehaviour
{
    [SerializeField] GameConstantsSO gameConstants;
    [SerializeField] GameObject hudScreenGO;
    [SerializeField] float offscreenVertical = 100f;
    [SerializeField] float screenTransitionTime = 1f;
    [SerializeField] private TMP_Text textTimer;
    [SerializeField] private TMP_Text textTeam1Score;
    [SerializeField] private Slider sliderTeam1Score;
    [SerializeField] private TMP_Text textTeam2Score;
    [SerializeField] private Slider sliderTeam2Score;
    [SerializeField] GameObject ballRenderTexture;
    [SerializeField] GameObject pickUpTextGO;

    [SerializeField] Slider crouchBar;
    [SerializeField] Slider blockBar;

    public GameObject blueFlag;
    public GameObject redFlag;

    private float crouch_tween = 2;

    // private GameManager gameManager;
    
    void Awake()
    {
        if(!gameConstants)
            Debug.LogError(gameObject.name+" does not have gameConstants property assigned");
        // StartTimer(timeRemaining);
        // SetScore(0,0);

        // Hide Flags by default
        redFlag.SetActive(false);
        blueFlag.SetActive(false);
        // hudScreenGO.SetActive(false);
        
        EventManagerSO.E_SetScore += SetScoreUI;
        EventManagerSO.E_SetTimer += SetTimerUI;
        EventManagerSO.E_UpdateFlagStatus += UpdateFlags;
        EventManagerSO.E_FinishedLoading += DisableHUD;
        EventManagerSO.E_StartMatch += EnableHUD;
        EventManagerSO.E_EndMatch += EndMatch;
        EventManagerSO.E_HideHUD += DisableHUD;
        EventManagerSO.E_PickUpText += PickUpTextActive;
        // EventManagerSO.E_UnhideHUD += UnhideHUD;
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
        EventManagerSO.E_UpdateFlagStatus -= UpdateFlags;
        EventManagerSO.E_FinishedLoading -= DisableHUD;
        EventManagerSO.E_StartMatch -= EnableHUD;
        EventManagerSO.E_EndMatch -= EndMatch;
        EventManagerSO.E_HideHUD -= DisableHUD;
        EventManagerSO.E_PickUpText -= PickUpTextActive;
        // EventManagerSO.E_UnhideHUD += UnhideHUD;
        // GameManager.SetScore -= SetScoreUI;
        // GameManager.SetTimer -= SetTimerUI;
        // GameManager.PickupBall -= DisplayHeldBall;
        // GameManager.RemoveBall -= HideHeldBall;
    }
    // Update is called once per frame
    void Update()
    {
    }

    private void PickUpTextActive(bool activeStatus)
    {
        pickUpTextGO.SetActive(activeStatus);
    }

    private void EnableHUD()
    {
        Vector2 newPos = new Vector2(0,offscreenVertical);
        hudScreenGO.GetComponent<RectTransform>().DOAnchorPos(newPos,0);
        
        hudScreenGO.SetActive(true);
        hudScreenGO.GetComponent<RectTransform>().DOAnchorPos(Vector2.zero,screenTransitionTime);
        
    }

    private void EndMatch(Team NA)
    {
        DisableHUD();
    }
    private void DisableHUD()
    {
        hudScreenGO.SetActive(false);
    }

    public void UpdateFlags(Team team, bool status) {
        if (team == Team.Team1) {
            blueFlag.SetActive(status);
        } else {
            redFlag.SetActive(status);
        }
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
    public void CrouchCooldown(float tween_time)
    {
        crouchBar.value = 0;
        crouchBar.DOValue(1,tween_time);
    }

    public void BlockCooldown(float tween_time)
    {
        blockBar.value = 0;
        blockBar.DOValue(1,tween_time);
    }
}
