using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class PickUpZoneController : MonoBehaviour
{
    // Start is called before the first frame update
    public bool hasBall = false;
    public bool foundBall = false;
    public GameObject ball;
    private bool ballNear = false;
    private DodgeballController controller;
    private StarterAssetsInputs starterAssetsInputs;

    private void Awake()
    {
        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
    }

    private void Update()
    {
        if(ballNear && starterAssetsInputs.pickup)
        {
            foundBall = true;
            controller.hasOwner = true;
            ballNear = false;
            // GameManager.Instance.TEMP_TurnOnBallHUD();
            EventManagerSO.TriggerEvent_PickUpText(false);
        }
    } 
    private void OnTriggerEnter(Collider other)
    {   
        if(!hasBall)
        {
            if(other.gameObject.CompareTag("Ball"))
            {   
                controller = other.gameObject.GetComponentInParent<DodgeballController>();
                if(!controller.hasOwner)
                {
                    if (other.gameObject.GetComponentInParent<Animator>() != null){
                        other.gameObject.GetComponentInParent<Animator>().enabled = false;
                    }
                    ball = other.gameObject;
                    ballNear = true;
                    EventManagerSO.TriggerEvent_PickUpText(true);
                }
                
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == ball)
        {
            ballNear = false;
            EventManagerSO.TriggerEvent_PickUpText(false);
        }

    }

}
