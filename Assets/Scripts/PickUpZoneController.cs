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
                ball = other.gameObject;
                foundBall= true;
            }
        }
        

    }
}
