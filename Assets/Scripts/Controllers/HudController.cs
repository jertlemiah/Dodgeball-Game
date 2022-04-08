using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;

public class HudController : Singleton<HudController>
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
    [SerializeField] private TMP_Text respawnText;
    private bool isRespawning = false;
    private float respawnTime;

    [SerializeField] Slider crouchBar;
    [SerializeField] Slider blockBar;

    public GameObject blueFlag;
    public GameObject redFlag;

    private float crouch_tween = 2;
    [SerializeField] private SimpleHealthBar healthBar;
    [SerializeField] private TMP_Text ballTypeText;
    [SerializeField] GameObject renderCamGO_dodgeball;
    [SerializeField] GameObject renderCamGO_fastball;
    [SerializeField] GameObject renderCamGO_deathball;
    [SerializeField] GameObject renderCamGO_heavyball;

    // private GameManager gameManager;
    
    new void Awake()
    {
        base.Awake();
        if(!gameConstants)
            Debug.LogError(gameObject.name+" does not have gameConstants property assigned");
        if(!healthBar){
            healthBar = GetComponent<SimpleHealthBar>();
        }
        // StartTimer(timeRemaining);
        // SetScore(0,0);

        // Hide Flags by default
        redFlag.SetActive(false);
        blueFlag.SetActive(false);
        respawnText.gameObject.SetActive(false);
        // hudScreenGO.SetActive(false);
        
        EventManagerSO.E_SetScore += SetScoreUI;
        EventManagerSO.E_SetTimer += SetTimerUI;
        EventManagerSO.E_UpdateFlagStatus += UpdateFlags;
        EventManagerSO.E_FinishedLoading += DisableHUD;
        EventManagerSO.E_StartMatch += EnableHUD;
        EventManagerSO.E_EndMatch += EndMatch;
        EventManagerSO.E_HideHUD += DisableHUD;
        EventManagerSO.E_PickUpText += PickUpTextActive;
        EventManagerSO.E_BallPickup += DisplayHeldBall;
        // EventManagerSO.E_UnhideHUD += UnhideHUD;
        // gameManager = GameManager.Instance;
        // GameManager.SetScore += SetScoreUI;
        // GameManager.SetTimer += SetTimerUI;
        // GameManager.PickupBall += DisplayHeldBall;
        // GameManager.RemoveBall += HideHeldBall;

        crouchBar.value = 1;
        blockBar.value = 1;
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
        EventManagerSO.E_BallPickup -= DisplayHeldBall;
        // EventManagerSO.E_UnhideHUD += UnhideHUD;
        // GameManager.SetScore -= SetScoreUI;
        // GameManager.SetTimer -= SetTimerUI;
        // GameManager.PickupBall -= DisplayHeldBall;
        // GameManager.RemoveBall -= HideHeldBall;
    }
    // Update is called once per frame
    void Update()
    {
        if (isRespawning) {
            respawnTime -= Time.deltaTime;
            respawnText.text = "Respawn in " + Mathf.Round(respawnTime * 10f) / 10f;;
            if (respawnTime <= 0) {
                respawnText.gameObject.SetActive(false);
                isRespawning = false;
                respawnText.text = "";
            }
        }

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
    void DisplayHeldBall(DodgeballType dodgeballType)
    {
        HideRenderCams();
        ballRenderTexture.SetActive(true);
        ballTypeText.text = dodgeballType.ToString();
        switch(dodgeballType){
            case DodgeballType.Dodgeball:
                renderCamGO_dodgeball.SetActive(true);
                break;
            case DodgeballType.Fastball:
                renderCamGO_fastball.SetActive(true);
                break;
            case DodgeballType.Heavyball:
                renderCamGO_heavyball.SetActive(true);
                break;
            case DodgeballType.Deathball:
                renderCamGO_deathball.SetActive(true);
                break;
            default:
                ballRenderTexture.SetActive(false);
                break;
        }
    }
    void HideRenderCams()
    {
        ballRenderTexture.SetActive(false);
        renderCamGO_dodgeball.SetActive(false);
        renderCamGO_fastball.SetActive(false);
        renderCamGO_heavyball.SetActive(false);
        renderCamGO_deathball.SetActive(false);
    }

    public void HandleRespawn(float time) {
        Debug.Log("HandleRespawn()");
        isRespawning = true;
        respawnTime = time;
        respawnText.text = "Respawn in " + Mathf.Round(time * 10f) / 10f;;
        respawnText.gameObject.SetActive(true);
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

    public void SetMaxHealth(int health)
	{
		healthBar.SetMaxHealth(health);
	}

    public void SetHealth(int health)
	{
        healthBar.SetHealth(health);
	}
}
