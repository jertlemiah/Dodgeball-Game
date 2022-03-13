using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpZoneController : MonoBehaviour
{
    // Start is called before the first frame update
    public bool hasBall = false;
    public bool foundBall = false;
    public GameObject ball; 
    private void OnTriggerEnter(Collider other)
    {   
        if(!hasBall)
        {
            if(other.gameObject.CompareTag("Ball"))
            {   
                DodgeballController controller = other.gameObject.GetComponentInParent<DodgeballController>();
                if(!controller.hasOwner)
                {
                    if (other.gameObject.GetComponentInParent<Animator>() != null)
                    {
                        other.gameObject.GetComponentInParent<Animator>().enabled = false;
                    }
                    ball = other.gameObject;
                    foundBall= true;
                    controller.hasOwner = true;
                    // GameManager.Instance.TEMP_TurnOnBallHUD();

                }
                
            }
        }

    }
}
