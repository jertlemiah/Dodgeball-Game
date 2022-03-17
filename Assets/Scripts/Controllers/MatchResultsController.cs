using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class MatchResultsController : MonoBehaviour
{
    [SerializeField] GameObject matchResultsScreenGO;
    [SerializeField] TMP_Text matchResultsText;
    [SerializeField] GameObject prematchParentGO;
    [SerializeField] TMP_Text countdownText;
    [SerializeField] int countdownSec = 10;
    void Awake()
    {
        EventManagerSO.E_EndMatch += EndMatchUI;
        EventManagerSO.E_StartPrematch +=StartPrematchCountdown;
    } 
    void OnDisable()
    {
        EventManagerSO.E_EndMatch -= EndMatchUI;
        EventManagerSO.E_StartPrematch -= StartPrematchCountdown;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartPrematchCountdown()
    {
        StartCoroutine(CountdownTimer(countdownSec));
    }

    IEnumerator CountdownTimer(int startTime)
    {
        prematchParentGO.SetActive(true);
        countdownText.alpha = 0;
        for(int i = startTime; i > 0; i--)
        {
            countdownText.text = i.ToString();
            countdownText.DOFade(1,0.25f);
            yield return new WaitForSeconds(0.75f);
            countdownText.DOFade(0,0.25f);
            yield return new WaitForSeconds(0.25f);
        }
        prematchParentGO.SetActive(false);
        EventManagerSO.TriggerEvent_StartMatch();
    }

    private void EndMatchUI(Team winningTeam){
        matchResultsText.text = "Team "+ winningTeam.ToString() +" won!";
        // matchResultsScreenGO.GetComponent<CanvasGroup>().alpha = 0;
        matchResultsScreenGO.SetActive(true);
    }
    public void LeaveMatchButton()
    {
        Debug.Log("Leaving Match");
        // Time.timeScale = 1;
        GameSceneManager.Instance.LoadScene_LoadingScreen(SceneIndex.TITLE_SCREEN);
    }
}
