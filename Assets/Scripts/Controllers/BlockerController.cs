using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockerController : MonoBehaviour
{   
    
    public float bounce_speed = 200;
    private Animator anim;
    private GameObject ball;
    private Rigidbody ballRb;
    private DodgeballController controller;

    void Start()
    {
        anim = GetComponentInParent<Animator>();

    }



    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Ball")){
            ball = other.gameObject.transform.parent.gameObject;
            controller = ball.GetComponent<DodgeballController>();
            if(controller.isThrown && anim.GetCurrentAnimatorStateInfo(2).IsName("Blocking")){
                ballRb = ball.GetComponent<Rigidbody>();
                Vector3 incoming_v = ballRb.velocity.normalized;
                Vector3 outgoing_v = new Vector3(-incoming_v.x, incoming_v.y, -incoming_v.z); 
                outgoing_v.x *= bounce_speed;
                outgoing_v.z *= bounce_speed;
                //Vector3 outgoing_v = -incoming_v;
                ballRb.velocity = Vector3.zero;
                ballRb.angularVelocity = Vector3.zero;
                ballRb.velocity = outgoing_v;
                Debug.Log("Blocked");
            }
        }
    } 
       

}
