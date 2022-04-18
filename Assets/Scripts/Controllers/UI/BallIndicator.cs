using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BallIndicator : MonoBehaviour
{
    [SerializeField] GameObject handIconGO;
    [SerializeField] TMP_Text ballName;
    [SerializeField] TMP_Text pickupText;
    public DodgeballController targetBall;
    
    public void LoadNewBall (DodgeballController newTarget)
    {
        targetBall = newTarget;
        ballName.text = targetBall.dodgeballType.ToString();
    }

    void Update()
    {
        if(targetBall){
            transform.position = Camera.main.WorldToScreenPoint(targetBall.transform.position);
        }
        bool close = false;
        if(close) {
            handIconGO.SetActive(true);
            pickupText.gameObject.SetActive(true);
        } else {
            handIconGO.SetActive(false);
            pickupText.gameObject.SetActive(false);
        }
    }
}
