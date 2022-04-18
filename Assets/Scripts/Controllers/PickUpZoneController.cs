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
    public bool ballNear = false;
    public DodgeballController closestDodgeball;
    private StarterAssetsInputs starterAssetsInputs;
    public List <DodgeballController> ballsInRange = new List<DodgeballController>();

    private void Awake()
    {
        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
    }

    private void Update()
    {
        // if(ballNear && starterAssetsInputs.pickup)
        // {
        //     foundBall = true;
        //     dodgeball.hasOwner = true;
        //     ballNear = false;
        //     // GameManager.Instance.TEMP_TurnOnBallHUD();
        //     EventManagerSO.TriggerEvent_PickUpText(false);
        // }
        if(ballsInRange.Count == 0) {
            closestDodgeball = null;
            ballNear = false;
        } else {
            SetClosestBall();
            ballNear = true;
        }
    } 

    void SetClosestBall()
    {
        float closestDist = -1f;
        foreach (DodgeballController ballController in ballsInRange) {
            float dist = (ballController.transform.position - transform.position).magnitude;
            if (closestDist == -1 || dist < closestDist) {
                closestDist = dist;
                closestDodgeball = ballController;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {   
        if(!hasBall)
        {
            if(other.gameObject.CompareTag("Ball"))
            {   
                DodgeballController dodgeballController = other.gameObject.GetComponentInParent<DodgeballController>();
                
                // closestDodgeball = other.gameObject.GetComponentInParent<DodgeballController>();
                if(!dodgeballController.hasOwner)
                {
                    // if (other.gameObject.GetComponentInParent<Animator>() != null){
                    //     other.gameObject.GetComponentInParent<Animator>().enabled = false;
                    // }
                    // ball = other.gameObject;
                    // ballNear = true;
                    // EventManagerSO.TriggerEvent_PickUpText(true);
                    ballsInRange.Add(dodgeballController);
                }
                
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {
        // if(other.gameObject == ball)
        if(other.gameObject.CompareTag("Ball"))
        {
            DodgeballController dodgeballController = other.gameObject.GetComponentInParent<DodgeballController>();
            // ballNear = false;
            // closestDodgeball = null;
            // ball = null;
            // EventManagerSO.TriggerEvent_PickUpText(false);
            try
            {
                ballsInRange.Remove(dodgeballController);
            }
            catch (System.Exception)
            {
            }
            
        }

    }

}
