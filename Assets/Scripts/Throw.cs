using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
// using StarterAssets;

public class Throw : MonoBehaviour
{
    [SerializeField] GameObject ballPrefab;
    [SerializeField] float throwPower = 5;
    [SerializeField] Animator cineAnimator;
    [SerializeField] CinemachineVirtualCamera ballVirtualCamera;
    public bool followingBall = false;
    // private InputActions _input;
    // // StarterAssetsInputs 
    // // Start is called before the first frame update
    // void Start()
    // {
    //     _input = new InputActions();
    //     _input.Player.Throw.performed += ctx => ThrowBall();
    //     if(!cineAnimator)
    //         cineAnimator = GetComponent<Animator>();
        
    // }
    // private void OnEnable()
    // {
    //     _input.Enable();
    // }
    // private void OnDisable()
    // {
    //     _input.Disable();
    // }

    // void ThrowBall()
    // {
    //     if(!followingBall)
    //     {
    //         GameObject ball = Instantiate(ballPrefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
    //         // ball.GetComponent<DodgeballController>();
    //         Rigidbody ballRb = ball.GetComponent<Rigidbody>();
    //         ballRb.AddForce(transform.forward * throwPower);
    //         ballVirtualCamera.LookAt = ball.transform;
    //         ballVirtualCamera.Follow = ball.transform;
    //         cineAnimator.SetTrigger("SwitchToBall");
            
    //         followingBall = true;
    //     }
    //     else
    //     {
    //         cineAnimator.SetTrigger("SwitchToPlayer");
    //         followingBall = false;
    //     }
    // }
    // // Update is called once per frame
    // void Update()
    // {
        
    // }
}
