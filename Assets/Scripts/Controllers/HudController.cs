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
    [SerializeField] private TMP_Text textTeam1MaxScore;
    [SerializeField] private Slider sliderTeam1Score;
    [SerializeField] private TMP_Text textTeam2Score;
    [SerializeField] private TMP_Text textTeam2MaxScore;
    [SerializeField] private Slider sliderTeam2Score;
    [SerializeField] GameObject ballRenderTexture;
    [SerializeField] GameObject pickUpTextGO;
    [SerializeField] private TMP_Text respawnText;
    private bool isRespawning = false;
    private float respawnTime;

    [SerializeField] Slider crouchBar;
    [SerializeField] Slider blockBar;
    [SerializeField] CooldownTimer blockCooldownTimer;

    public GameObject blueFlag;
    public GameObject redFlag;

    private float crouch_tween = 2;
    // [SerializeField] private SimpleHealthBar healthBar;
    [SerializeField] HealthbarController healthbar;
    [SerializeField] private TMP_Text ballTypeText;
    [SerializeField] GameObject renderCamGO_dodgeball;
    [SerializeField] GameObject renderCamGO_fastball;
    [SerializeField] GameObject renderCamGO_deathball;
    [SerializeField] GameObject renderCamGO_heavyball;

    [SerializeField] GameObject flagIndicatorBlueGO;
    // [SerializeField] TMP_Text blueFlagText;
    GameObject flagBlueGO;

    [SerializeField] GameObject flagIndicatorRedGO;
    // [SerializeField] TMP_Text redFlagText;
    GameObject flagRedGO;
    [SerializeField] Slider redFlagPositionSlider;
    [SerializeField] Image redFlagPosition;
    [SerializeField] Image redFlagHomePosition;

    [SerializeField] Slider blueFlagPositionSlider;
    [SerializeField] Image blueFlagPosition;
    [SerializeField] Image blueFlagHomePosition;
    [SerializeField] Vector3 flagIndicatorOffset = new Vector3(0,1.5f,0);
    [SerializeField] GameObject notificationPrefab;
    [SerializeField] Transform notificationParent;

    // private GameManager gameManager;
    
    new void Awake()
    {
        base.Awake();
        if (!gameConstants)
            Debug.LogError(gameObject.name+" does not have gameConstants property assigned");
        if (!healthbar)
            Debug.LogWarning(gameObject.name + " does not have a healthbarController assigned");
        // if(!healthBar){
        //     healthBar = GetComponent<SimpleHealthBar>();
        // }
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
        EventManagerSO.E_StartMatch += StartMatch;
        EventManagerSO.E_EndMatch += EndMatch;
        EventManagerSO.E_HideHUD += DisableHUD;
        EventManagerSO.E_PickUpText += PickUpTextActive;
        EventManagerSO.E_BallPickup += DisplayHeldBall;
        EventManagerSO.E_UpdateHealthbar += UpdateHealthbar;
        EventManagerSO.E_DeathNotification += DeathNotification;
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
        EventManagerSO.E_StartMatch -= StartMatch;
        EventManagerSO.E_EndMatch -= EndMatch;
        EventManagerSO.E_HideHUD -= DisableHUD;
        EventManagerSO.E_PickUpText -= PickUpTextActive;
        EventManagerSO.E_BallPickup -= DisplayHeldBall;
        EventManagerSO.E_UpdateHealthbar -= UpdateHealthbar;
        EventManagerSO.E_DeathNotification -= DeathNotification;
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
        UpdateFlagIndicators();
        UpdateFlagTransitProgress();

        GameObject[] ballGOs = GameObject.FindGameObjectsWithTag("Ball");
        if(ballGOs.Length > 0 && ballIndicators.Count == 0) {
            CreateBallIndicators();
        }

    }

    [SerializeField] GameObject ballIndicatorPrefab;
    [SerializeField] List<BallIndicator> ballIndicators = new List<BallIndicator>();

    void CreateBallIndicators()
    {
        if(!ballIndicatorPrefab){
            return;
        }
        GameObject[] ballGOs = GameObject.FindGameObjectsWithTag("Ball");
        foreach(GameObject ball in ballGOs){
            DodgeballController dodgeballController;
            if (ball.TryGetComponent<DodgeballController>(out dodgeballController)) {
                GameObject GO = Instantiate(ballIndicatorPrefab, Vector3.zero, Quaternion.identity, this.transform);
                BallIndicator ballIndicator = ballIndicatorPrefab.GetComponent<BallIndicator>();
                ballIndicator.LoadNewBall(dodgeballController);
                ballIndicators.Add(ballIndicator);
            }    
        }
    }

    void MaintainBallIndicators()
    {

    }

    void DeathNotification(Team teamOfPlayer, string playerName, string killerName)
    {
        CreateNewNotification(teamOfPlayer, NotifType.DEATH, playerName, killerName);
    }

    void CreateNewNotification (Team team, NotifType notifType)
    {
        GameObject notifGo = Instantiate(notificationPrefab, Vector3.zero, Quaternion.identity, notificationParent);
        Notification notif = notifGo.GetComponent<Notification>();
        if(notif) {
            notif.NewNotification(team, notifType);
        }
    }
    void CreateNewNotification (Team team, NotifType notifType, string detail1)
    {
        GameObject notifGo = Instantiate(notificationPrefab, Vector3.zero, Quaternion.identity, notificationParent);
        Notification notif = notifGo.GetComponent<Notification>();
        if(notif) {
            notif.NewNotification(team, notifType, detail1);
        }
    }
    void CreateNewNotification (Team team, NotifType notifType, string detail1, string detail2)
    {
        GameObject notifGo = Instantiate(notificationPrefab, Vector3.zero, Quaternion.identity, notificationParent);
        Notification notif = notifGo.GetComponent<Notification>();
        if(notif) {
            notif.NewNotification(team, notifType, detail1, detail2);
        }
    }

    void UpdateFlagIndicators()
    {
        GameObject[] foundGOs = GameObject.FindGameObjectsWithTag("Blue Flag");
        float cameraAngle = 0f;
        if(foundGOs.Length > 0) {
            flagBlueGO = foundGOs[0];            
            if(flagBlueGO){
                flagIndicatorBlueGO.transform.position = Camera.main.WorldToScreenPoint(flagBlueGO.transform.position + flagIndicatorOffset);
                // cameraAngle = Vector3.Angle(flagBlueGO.transform.position, Camera.main.transform.forward);
                cameraAngle = Vector3.Angle(flagBlueGO.transform.position - Camera.main.transform.position, Camera.main.transform.forward);
                // Debug.Log("Angle to the blue flag: "+cameraAngle);
                if(cameraAngle >= 100 || !overrideBlueInactive) {
                    flagIndicatorBlueGO.SetActive(false);
                } else {
                    flagIndicatorBlueGO.SetActive(true);
                }
            } else {
                flagIndicatorBlueGO.SetActive(false);
            }
        }
        
        foundGOs = GameObject.FindGameObjectsWithTag("Red Flag");
        if(foundGOs.Length > 0) {
            flagRedGO = foundGOs[0];
            if(flagRedGO){
                flagIndicatorRedGO.transform.position = Camera.main.WorldToScreenPoint(flagRedGO.transform.position + flagIndicatorOffset);
                cameraAngle = Vector3.Angle(flagRedGO.transform.position - Camera.main.transform.position, Camera.main.transform.forward);
                if(cameraAngle >= 100 || !overrideRedInactive) {
                    flagIndicatorRedGO.SetActive(false);
                } else {
                    flagIndicatorRedGO.SetActive(true);
                }
            } else {
                flagIndicatorRedGO.SetActive(false);
            }       
        }

    }

    bool overrideBlueInactive = true;
    bool overrideRedInactive = true;

    public void SetFlagActive(Team flagTeam, bool activeStatus)
    {
        if (flagTeam == Team.Team1) {
            // flagIndicatorBlueGO.SetActive(activeStatus);
            overrideBlueInactive = activeStatus;
        } else {
            // flagIndicatorRedGO.SetActive(activeStatus);
            overrideRedInactive = activeStatus;
        }
    }

    public void UpdateFlagStatus(Team flagTeam, FlagState flagState)
    {
        // {HOME, TRANSIT, DROPPED, CONTESTED, CAPTURING, RETURNING}
        string newText = "PROTECT";
        // Assuming the human player is blue TODO: fix this if there is time
        if (flagTeam == Team.Team1) {
            switch(flagState) {
                case FlagState.HOME:
                    newText = "PROTECT";
                    break;
                case FlagState.TRANSIT:
                    newText = "ATTACK";
                    break;
                case FlagState.CONTESTED:
                    newText = "CONTESTED";
                    break;
                case FlagState.DROPPED:
                case FlagState.CAPTURING:
                case FlagState.RETURNING:
                default:
                    newText = "RETRIEVE";
                    break;
            }
        } else {
            switch(flagState) {
                case FlagState.TRANSIT:
                    newText = "PROTECT";
                    break;
                case FlagState.CONTESTED:
                    newText = "CONTESTED";
                    break;
                case FlagState.HOME:
                case FlagState.DROPPED:
                case FlagState.CAPTURING:
                case FlagState.RETURNING:
                default:
                    newText = "CAPTURE";
                    break;
            }
        }

        SetFlagText(flagTeam, newText);
    }

    void SetFlagText (Team team, string newText)
    {
        // Debug.Log("Trying to set the flag indicator text for '"+team+"', '"+newText+"'");
        // if (team == Team.Team1 && blueFlagText){
        //     blueFlagText.text = newText;
        // } else if (team == Team.Team2 && redFlagText){
        //     redFlagText.text = newText;
        // }

        TextMeshProUGUI tmpText = null;
        if (team == Team.Team1 && flagIndicatorBlueGO!=null){
            tmpText = flagIndicatorBlueGO.GetComponentInChildren<TextMeshProUGUI>();
        } else if (team == Team.Team2 && flagIndicatorRedGO!=null){
            tmpText = flagIndicatorRedGO.GetComponentInChildren<TextMeshProUGUI>();
        }
        if (tmpText) {
            tmpText.text = newText;
        } else {
            Debug.Log("Couldn't set the flag indicator text for '"+team+"', '"+newText+"'");
        }

        
    }

    public void SetFlagCaptureProgress (Team team, float progress)
    {
        Image flagProgressBar = null;
        if (team == Team.Team1 && flagIndicatorBlueGO!=null){
            // This is a super dirty way to find the correct object, but it works for now
            flagProgressBar = flagIndicatorBlueGO.GetComponentInChildren<Slider>()
                .gameObject.GetComponent<Image>();
        } else if (team == Team.Team2 && flagIndicatorRedGO!=null){
            flagProgressBar = flagIndicatorRedGO.GetComponentInChildren<Slider>()
                .gameObject.GetComponent<Image>();
        }

        if (flagProgressBar) {
            flagProgressBar.fillAmount = (float)(progress);
        }
    }

    private void PickUpTextActive(bool activeStatus)
    {
        // pickUpTextGO.SetActive(activeStatus);
    }

    void StartMatch()
    {
        
        EnableHUD();
        ballIndicators.Clear();
        CreateBallIndicators();
        // EventManagerSO.TriggerEvent_UpdateHealthbar
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

    public void UpdateFlags(Team team, FlagState status) {
        if (team == Team.Team1) {
            // blueFlag.SetActive(status);
            if (status == FlagState.HOME) {
                blueFlagPosition.gameObject.SetActive(false);
                blueFlagHomePosition.gameObject.SetActive(true);
            } else {
                blueFlagPosition.gameObject.SetActive(true);
                blueFlagHomePosition.gameObject.SetActive(false);
                
            }
        } else {
            // redFlag.SetActive(status);
            if (status == FlagState.HOME) {
                redFlagPosition.gameObject.SetActive(false);
                redFlagHomePosition.gameObject.SetActive(true);
            } else {
                redFlagPosition.gameObject.SetActive(true);
                redFlagHomePosition.gameObject.SetActive(false);
                
            }
        }
        switch(status){
            case FlagState.DROPPED:
                CreateNewNotification(team == Team.Team1? Team.Team2 : Team.Team1, NotifType.DROPPED);
                break;
            case FlagState.HOME:
                CreateNewNotification(team, NotifType.RETURNED);
                break;
            case FlagState.TRANSIT:
                CreateNewNotification(team == Team.Team1? Team.Team2 : Team.Team1, NotifType.TAKEN);
                break;
        }
        
    }

    void UpdateFlagTransitProgress()
    {
        float flagTransitProgress = 0f;
        Vector3 blueHomePos = Vector3.zero;
        if(flagBlueGO) {
            blueHomePos = flagBlueGO.GetComponent<FlagController>().originalPosition;
        }
        Vector3 redHomePos = Vector3.zero;
        if(flagRedGO) {
            redHomePos = flagRedGO.GetComponent<FlagController>().originalPosition;
        }

        flagTransitProgress = blueFlagPositionSlider.value;
        if (flagBlueGO && flagRedGO) {
            // flagBlueGO.GetComponent<FlagController>().originalPosition
            flagTransitProgress = 1-(flagBlueGO.transform.position - redHomePos).magnitude / (blueHomePos - redHomePos).magnitude; 
        }
        blueFlagPositionSlider.value = flagTransitProgress; //needs to be set

        flagTransitProgress = redFlagPositionSlider.value;
        if (flagBlueGO && flagRedGO) {
            // flagBlueGO.GetComponent<FlagController>().originalPosition
            flagTransitProgress = 1-(flagRedGO.transform.position - blueHomePos).magnitude / (blueHomePos - redHomePos).magnitude; 
        }
        redFlagPositionSlider.value = flagTransitProgress; //needs to be set
    }
    
    public void SetScoreUI(int team1Score, int team2Score)
    {
        bool blueScored = (textTeam1Score.text != team1Score.ToString());
        bool redScored = (textTeam2Score.text != team2Score.ToString());

        textTeam1Score.text = team1Score.ToString();
        sliderTeam1Score.value = (float)team1Score/gameConstants.WINNING_SCORE;
        // sliderTeam1Score.value = (float)team1Score/gameManager.winningScore;
        textTeam2Score.text = team2Score.ToString();
        sliderTeam2Score.value = (float)team2Score/gameConstants.WINNING_SCORE;
        // sliderTeam2Score.value = (float)team2Score/gameManager.winningScore;
        textTeam1MaxScore.text = "/"+gameConstants.WINNING_SCORE.ToString();
        textTeam2MaxScore.text = "/"+gameConstants.WINNING_SCORE.ToString();

        if(blueScored){
            CreateNewNotification(Team.Team1, NotifType.SCORED);
        } else if (redScored){
            CreateNewNotification(Team.Team2, NotifType.SCORED);
        }
        
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
        blockCooldownTimer.StartCooldown(tween_time);
        // blockBar.value = 0;
        // blockBar.DOValue(1,tween_time);
    }

    void UpdateHealthbar(float newHealth, bool isNewMax)
    {
        if(isNewMax) healthbar.SetMaxHealth(newHealth);
        else {
            healthbar.SetHealth(newHealth);
        }
    }

    // public void SetMaxHealth(int health)
	// {
	// 	healthBar.SetMaxHealth(health);
	// }

    // public void SetHealth(int health)
	// {
    //     healthBar.SetHealth(health);
	// }
}
