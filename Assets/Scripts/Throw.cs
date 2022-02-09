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
    [SerializeField] GameObject throwSpot;
    public bool followingBall = false;
    private InputActions _input;
    // StarterAssetsInputs 
    // Start is called before the first frame update
    void Awake()
    {
        _input = new InputActions();
        _input.Player.Throw.performed += ctx => ThrowBall();
    }
    void Start()
    {
        // _input = new InputActions();
        
        if(!cineAnimator)
            cineAnimator = GetComponent<Animator>();
        
    }
    private void OnEnable()
    {
        _input.Enable();
    }
    private void OnDisable()
    {
        _input.Disable();
    }

    void ThrowBall()
    {
        if(!followingBall)
        {
            GameObject ball = Instantiate(ballPrefab, throwSpot.transform.position, throwSpot.transform.rotation) as GameObject;
            // ball.GetComponent<DodgeballController>();
            Rigidbody ballRb = ball.GetComponent<Rigidbody>();
            ballRb.AddForce(throwSpot.transform.forward * throwPower,ForceMode.VelocityChange);
            ballVirtualCamera.LookAt = ball.transform;
            ballVirtualCamera.Follow = ball.transform;
            cineAnimator.SetTrigger("SwitchToBall");
            
            followingBall = true;
        }
        else
        {
            cineAnimator.SetTrigger("SwitchToPlayer");
            followingBall = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
