using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class BallFollowCameraController : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera virtualCamera;
    [SerializeField] float folowDistance = 5;
    GameObject ballToFollow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ballToFollow = virtualCamera.Follow.gameObject;
        Rigidbody ballRb = ballToFollow.GetComponentInChildren<Rigidbody>();
        Vector3 direction =  new Vector3(ballRb.velocity.x,0,ballRb.velocity.z);
        // virtualCamera.
        // ballRb.velocity.normalized;
    }
}
