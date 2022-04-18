using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;

public enum NotifType {SCORED, DROPPED, TAKEN, DEATH, RETURNED}
[RequireComponent(typeof(CanvasGroup))]
public class Notification : MonoBehaviour
{
    [SerializeField] TMP_Text notifText;
    [SerializeField] GameObject blueBackgroundGO;
    [SerializeField] GameObject redBackgroundGO;
    [SerializeField] GameObject blueIconBackgroundGO;
    [SerializeField] GameObject redIconBackgroundGO;
    [SerializeField] GameObject iconParentGO;
    [SerializeField] GameObject iconDroppedFlagGO;
    [SerializeField] string droppedFlagTextFormula = "[team] team has dropped the flag!";
    [SerializeField] GameObject iconScoredFlagGO;
    [SerializeField] string scoredFlagTextFormula = "[detail1] has scored a point for the [team] team!";
    [SerializeField] GameObject iconDeathGO;
    [SerializeField] string deathTextFormula = "[detail1] was eliminated by [detail2]!";
    [SerializeField] GameObject iconFlagTakenGO;
    [SerializeField] string flagTakenTextFormula = "[team] team has taken the flag!";
    [SerializeField] string flagReturnedTextFormula = "The [team] team's flag was returned!";
    CanvasGroup canvasGroup => GetComponent<CanvasGroup>();
    [SerializeField] float notificationTime = 5f;

    // Start is called before the first frame update
    void Start()
    {
        Sequence notifSequence = DOTween.Sequence();
        transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        notifSequence
            .Append(transform.DOScale(new Vector3(1f, 1f, 1f), 1))
            .AppendInterval(notificationTime)
            .Append(canvasGroup.DOFade(0,1))
            .OnComplete(()=>Destroy(this.gameObject));
    }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }

    public void NewNotification(Team team, NotifType notifType) {
        NewNotification (team, notifType, "UNKNOWN");
    } 

    public void NewNotification(Team team, NotifType notifType, string detail1) {
        NewNotification (team, notifType, detail1, "UNKNOWN");
    } 

    public void NewNotification(Team team, NotifType notifType, string detail1, string detail2) 
    {
        // Turn off all children of the iconParentGO. Will need to turn the background and the associated icon back on
        for (int i = 0; i < iconParentGO.transform.childCount; i++) {
            Transform child = iconParentGO.transform.GetChild(i);
            child.gameObject.SetActive(false);
        }
        
        if (team == Team.Team1) {
            blueBackgroundGO.SetActive(true);
            redBackgroundGO.SetActive(false);
            blueIconBackgroundGO.SetActive(true);
            redIconBackgroundGO.SetActive(false);
            iconParentGO.transform.localScale = new Vector3(1,1,1);
        } else {
            blueBackgroundGO.SetActive(false);
            redBackgroundGO.SetActive(true);
            blueIconBackgroundGO.SetActive(false);
            redIconBackgroundGO.SetActive(true);
            iconParentGO.transform.localScale = new Vector3(-1,1,1);
        }
        string messageText = "";
        switch(notifType) {
            case NotifType.SCORED:
                iconScoredFlagGO.SetActive(true);
                // "[detail1] has scored a point for the [team? 'blue' | 'red'] team!";
                messageText = scoredFlagTextFormula.Replace("[detail1]",detail1).Replace("[team]",team == Team.Team1? "Your" : "The Enemy");
                break;
            case NotifType.DROPPED:
                iconDroppedFlagGO.SetActive(true);
                // "[team] team has dropped the flag!"
                messageText = droppedFlagTextFormula.Replace("[team]",team == Team.Team1? "Your" : "The Enemy");
                break;
            case NotifType.TAKEN:
                iconFlagTakenGO.SetActive(true);
                // "[team] team has taken the flag!"
                messageText = flagTakenTextFormula.Replace("[team]",team == Team.Team1? "Your" : "The Enemy");
                break;
            case NotifType.RETURNED:
                iconScoredFlagGO.SetActive(true);
                // "The [team]'s flag was returned!"
                messageText = flagReturnedTextFormula.Replace("[team]",team == Team.Team1? "blue" : "red");
                break;
            case NotifType.DEATH:
                iconDeathGO.SetActive(true);
                // "[detail2] was eliminated by [detail1]!"
                messageText = deathTextFormula.Replace("[detail1]",detail1);//.Replace("[detail2]",detail2);
                if (detail1 == "You"){
                    messageText = messageText.Replace("was","were");
                }
                break;
            default:
                messageText = "Unhandled notification, type: "+notifType+", detail1: "+detail1+", detail2: "+detail2;
                break;
        }

        notifText.text = messageText;
    }
}
