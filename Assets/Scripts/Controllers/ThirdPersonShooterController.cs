using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StarterAssets;

public class ThirdPersonShooterController : MonoBehaviour
{   
    [SerializeField] private CinemachineVirtualCamera aimVirtualCamera;
    [SerializeField] private float normalSensitivity;
    [SerializeField] private float aimSensitivity;
    [SerializeField] private LayerMask aimColliderLayerMask;

    [SerializeField] private GameObject handSpot;
    [SerializeField] private Transform debugTransform;

    [SerializeField] private float block_cooldown;
    [SerializeField] private float block_time;

    private StarterAssetsInputs starterAssetsInputs;
    private ThirdPersonController thirdPersonController;

    private PickUpZoneController pickUpZoneController;
    private Animator anim;

    private GameObject ball;
    private Rigidbody rb;
    public float shift_x;
    public float shift_y;
    public float shift_z;
    public float throw_speed;

    private Vector3 mouseWorldPosition;

    private CursorLockMode lockMode;

    private float last_block_time;
    private bool canBlock = true;
    private bool isBlocking = false;
    private float block_start_time;
    private Renderer blocker_renderer;

    // Start is called before the first frame update
    private void Awake()
    {   
        lockMode = CursorLockMode.Locked;
        Cursor.lockState = lockMode;
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
        thirdPersonController = GetComponent<ThirdPersonController>();
        pickUpZoneController = GetComponentInChildren<PickUpZoneController>();
        anim = GetComponent<Animator>();
        GameObject Blocker = GameObject.Find("Blocker");
        blocker_renderer = Blocker.GetComponent<Renderer>();
    }

    public void ReleaseBall()
    {
        ball.transform.parent = null;
        rb.isKinematic = false;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        Vector3 throw_direction = (mouseWorldPosition - ball.transform.position).normalized;
        throw_speed = ball.GetComponent<DodgeballController>().velocity;
        Debug.Log(ball.name);
        Debug.Log("The ball was thrown with a velocity of " + throw_speed);
        rb.AddForce(throw_direction*throw_speed*100f);
        pickUpZoneController.hasBall = false;
        anim.SetBool("Throw", false);

        ball.GetComponent<DodgeballController>().hasOwner = false;
        ball.GetComponent<DodgeballController>().isThrown = true; // the ball can now cause damage on collision
        ball.GetComponent<DodgeballController>().thrownBy = this.gameObject; // to let the dodgeball know not to damage the person who threw it on exit from hand
    }

    /* PickUpBall() - Triggered through animation events

    */
    public void PickUpBall()
    {
        ball.transform.parent = handSpot.transform;
        ball.transform.localPosition = Vector3.zero;
        ball.transform.localRotation = Quaternion.identity;

        rb = ball.GetComponent<Rigidbody>();
        rb.isKinematic = true;

        pickUpZoneController.hasBall = true;
        pickUpZoneController.foundBall = false;

        anim.SetBool("PickUp", false);
        thirdPersonController.canMove = true;
    }

    private void Update()
    {   

        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimColliderLayerMask))
        {
            //debugTransform.position = raycastHit.point;
            mouseWorldPosition = raycastHit.point;
        }

        if(!canBlock)
        {
            float elapsed_time = Time.time - last_block_time;
            if(elapsed_time >= block_cooldown){
                canBlock = true;
                Debug.Log("can block again");
            }
        }

        if(pickUpZoneController.foundBall)
        {   
            ball = pickUpZoneController.ball.transform.parent.gameObject;
            anim.SetBool("PickUp", true);
            thirdPersonController.canMove = false;
        }

        if(anim.GetBool("PickUp"))
        {
            transform.forward = ball.transform.position-transform.position;
        }
    
        if(starterAssetsInputs.aim && pickUpZoneController.hasBall)
        {   
            anim.SetBool("Aim", true);
            aimVirtualCamera.gameObject.SetActive(true);
            thirdPersonController.SetSensitivity(aimSensitivity);
            thirdPersonController.SetRotateOnMove(false);

            Vector3 worldAimTarget =  new Vector3(mouseWorldPosition.x, transform.position.y, mouseWorldPosition.z);
            Vector3 aimDirection = (worldAimTarget - transform.position);
            transform.forward = Vector3.Lerp(transform.forward, aimDirection, Time.deltaTime * 20f);
             
            if(starterAssetsInputs.throw_bool){
                anim.SetBool("Throw", true);
                //rb.constraints = RigidbodyConstraints.None;
                
            }
           
        }
        else if(starterAssetsInputs.block && pickUpZoneController.hasBall && canBlock)
        {   
            if(isBlocking){
                float elapsed_time = Time.time - block_start_time;
                if(elapsed_time >= block_time){
                    anim.SetBool("Block", false);
                    isBlocking = false;
                    canBlock = false;
                    last_block_time = Time.time;
                    blocker_renderer.enabled = false;
                }
            }
            else{
                anim.SetBool("Block", true);
                isBlocking = true;
                block_start_time = Time.time;
                blocker_renderer.enabled = true;
            }
        }
        else{
            anim.SetBool("Aim", false);
            anim.SetBool("Block", false);
            blocker_renderer.enabled = false;
            aimVirtualCamera.gameObject.SetActive(false);
            thirdPersonController.SetSensitivity(normalSensitivity);
            thirdPersonController.SetRotateOnMove(true);
        }
    }
}
