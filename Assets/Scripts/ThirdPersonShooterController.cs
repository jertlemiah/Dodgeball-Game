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
    // Start is called before the first frame update
    private void Awake()
    {
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
        thirdPersonController = GetComponent<ThirdPersonController>();
        pickUpZoneController = GetComponentInChildren<PickUpZoneController>();
        anim = GetComponent<Animator>();
    }

    public void ReleaseBall()
    {
        ball.transform.parent = null;
        rb.isKinematic = false;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        Vector3 throw_direction = (mouseWorldPosition - ball.transform.position).normalized;
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
        else{
            anim.SetBool("Aim", false);
            aimVirtualCamera.gameObject.SetActive(false);
            thirdPersonController.SetSensitivity(normalSensitivity);
            thirdPersonController.SetRotateOnMove(true);
        }
    }
}
