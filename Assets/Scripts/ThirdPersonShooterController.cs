using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StarterAssets;

public class ThirdPersonShooterController : MonoBehaviour
{   
    [SerializeField] private CinemachineVirtualCamera aimVirtualCamera;
    [SerializeField] private float normalSensitivity = 2f;
    [SerializeField] private float aimSensitivity = 0.5f;
    [SerializeField] private LayerMask aimColliderLayerMask = new LayerMask();
    //[SerializeField] private Transform debugTransform;

    private StarterAssetsInputs starterAssetsInputs;
    private ThirdPersonController thirdPersonController;

    private PickUpZoneController pickUpZoneController;

    private GameObject ball;
    private Rigidbody rb;
    public float shift_x = 0.4f;
    public float shift_y = 1.4f;
    public float shift_z = 0.4f;
    public float throw_speed = 10f;
    // Start is called before the first frame update
    private void Awake()
    {
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
        thirdPersonController = GetComponent<ThirdPersonController>();
        pickUpZoneController = GetComponentInChildren<PickUpZoneController>();
    }

    private void Update()
    {   
        if(pickUpZoneController.foundBall)
        {   
            ball = pickUpZoneController.ball.transform.parent.gameObject;
            ball.transform.position = transform.position + new Vector3(transform.right.x * shift_x, shift_y, transform.right.z * shift_z);
            rb = ball.GetComponent<Rigidbody>();
            rb.constraints = RigidbodyConstraints.FreezeAll;
            pickUpZoneController.hasBall = true;
            pickUpZoneController.foundBall = false;
        }

        if(pickUpZoneController.hasBall){
            ball.transform.position = transform.position + new Vector3(transform.right.x * shift_x, shift_y, transform.right.z * shift_z);
        }

        Vector3 mouseWorldPosition = Vector3.zero;

        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimColliderLayerMask))
        {
            //debugTransform.position = raycastHit.point;
            mouseWorldPosition = raycastHit.point;
        }

        if(starterAssetsInputs.aim)
        {
            aimVirtualCamera.gameObject.SetActive(true);
            thirdPersonController.SetSensitivity(aimSensitivity);
            thirdPersonController.SetRotateOnMove(false);

            Vector3 worldAimTarget =  new Vector3(mouseWorldPosition.x, transform.position.y, mouseWorldPosition.z);
            Vector3 aimDirection = (worldAimTarget - transform.position);
            transform.forward = Vector3.Lerp(transform.forward, aimDirection, Time.deltaTime * 20f);

            if(starterAssetsInputs.throw_bool && pickUpZoneController.hasBall){
                Debug.Log("thrown");
                rb.constraints = RigidbodyConstraints.None;
                Vector3 throw_direction = (mouseWorldPosition - ball.transform.position).normalized;
                rb.AddForce(throw_direction*throw_speed*100f);
                pickUpZoneController.hasBall = false;
                // GameManager.Instance.TEMP_TurnOffBallHUD();
            }
           
        }
        else{
            aimVirtualCamera.gameObject.SetActive(false);
            thirdPersonController.SetSensitivity(normalSensitivity);
            thirdPersonController.SetRotateOnMove(true);
        }
    }
}
