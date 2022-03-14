using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleAIUnitBallPickUp : MonoBehaviour
{
    GameObject ballHoldSpot;
    Rigidbody ballRb;
    GameObject ball;
    // Start is called before the first frame update
    void Start()
    {
        ballHoldSpot = this.transform.parent.Find("BallHoldSpotAI").gameObject;
    }


    /** OnTriggerEnter Function
     * Function that is called when the AIUnit PickUpZone collides with something
     * It first filters out everything except ball objects, then makes sure that 
     *      1) the ball isn't already held (on your way to ball, if you collide with player holding different ball, don't take theirs)
     *      2) you don't already have a ball (somebody throws a ball at you while you are holding one)
     * The rest of the code is pulled from ThirdPersonShooterController PickUpBall(). 
     */
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Ball")) // filter out everything else except balls
        {
            DodgeballController controller = other.gameObject.GetComponentInParent<DodgeballController>();
            // if the dodgeball isn't already being carried and we also don't already have a ball and it isn't thrown
            if (!controller.hasOwner && ballHoldSpot.transform.childCount < 1 && controller.isThrown == false) 
            {
                ball = other.gameObject.transform.parent.gameObject; // all this ball grabbing code pulled straight from ThirdPersonShooterController
                ball.transform.parent = ballHoldSpot.transform;  
                ball.transform.localPosition = Vector3.zero;
                ball.transform.localRotation = Quaternion.identity;
                ballRb = ball.GetComponent<Rigidbody>();
                ballRb.isKinematic = true;
                this.transform.GetComponentInParent<SimpleAIUnitController>().hasBall = true;
                controller.hasOwner = true;
            }
        }
    }

    /** ThrowBall Function
     * Function used to execute the nitty gritty ball throwing
     * I pulled most of the code from existing ThirdPersonShooterController ReleaseBall()
     * However, there are issues with it, and I had to make modifications. 
     * I nulled out the ball and ballRB objects after throwing. The Player currently hangs onto those after throwing, which is not good.
     */
    public void ThrowBall(Vector3 throwingDirection)
    {
        ball.transform.parent = null;  // all this is ball throwing code is pulled straight from ThirdPersonShooterController
        ball.GetComponent<DodgeballController>().hasOwner = false;
        ball.GetComponent<DodgeballController>().isThrown = true;
        ball.GetComponent<DodgeballController>().thrownBy = this.transform.parent.gameObject;
        ball = null;
        ballRb.isKinematic = false;
        ballRb.velocity = Vector3.zero;
        ballRb.angularVelocity = Vector3.zero;

        //Vector3 throw_direction = (mouseWorldPosition - ball.transform.position).normalized;
        ballRb.AddForce(throwingDirection * 1000f);
        ballRb = null;
    }
}
