using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BallIndicator : MonoBehaviour
{
    [SerializeField] GameObject handIconGO;
    [SerializeField] TMP_Text ballName;
    [SerializeField] TMP_Text pickupText;
    public DodgeballController targetBall;
    Transform visualsParent;

    GameObject humanPlayer;
    public LayerMask obstacleMask;
    
    public void LoadNewBall (DodgeballController newTarget)
    {
        targetBall = newTarget;
        ballName.text = targetBall.dodgeballType.ToString();
    }

    void OnEnable()
    {
        visualsParent = transform.GetChild(0);
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject go in players) {
            HumanInput humanInput;
            if(go.TryGetComponent<HumanInput>(out humanInput)) {
                humanPlayer = go;
            }
        }
        
    }

    void Update()
    {
        if(targetBall){
            transform.position = Camera.main.WorldToScreenPoint(targetBall.transform.position);
        } else {
            visualsParent.gameObject.SetActive(false);
            return;
        }
        bool withinPickupRange = false;
        bool lineOfSight = false;
        if(humanPlayer) {
            PickUpZoneController pickUpZone = humanPlayer.GetComponentInChildren<PickUpZoneController>();
            if (pickUpZone.closestDodgeball == targetBall) {
                withinPickupRange = true;
            }
      
            // Vector3 humanCenter = humanPlayer.transform.position + Vector3.up*1f;
            // Vector3 dirToTarget = (humanCenter - targetBall.transform.position).normalized;
            // float distToTarget = Vector3.Distance(targetBall.transform.position, humanCenter);
            // lineOfSight = !Physics.Raycast(targetBall.transform.position, dirToTarget, distToTarget, obstacleMask);

            Vector3 humanCenter = Camera.main.transform.position;
            Vector3 dirToTarget = (humanCenter - targetBall.transform.position).normalized;
            float distToTarget = Vector3.Distance(targetBall.transform.position, humanCenter);
            lineOfSight = !Physics.Raycast(targetBall.transform.position, dirToTarget, distToTarget, obstacleMask);

            // RaycastHit hit;
            // Vector3 ray = humanPlayer.transform.position - targetBall.transform.position;
            // if (Physics.Raycast())
        }


        if(withinPickupRange && !targetBall.hasOwner && !humanPlayer.GetComponent<UnitController>().hasBall) {
            handIconGO.SetActive(true);
            // pickupText.gameObject.SetActive(true);
        } else {
            handIconGO.SetActive(false);
            // pickupText.gameObject.SetActive(false);
        }

        

        float cameraAngle = 0f;
        cameraAngle = Vector3.Angle(targetBall.transform.position - Camera.main.transform.position, Camera.main.transform.forward);
        // Debug.Log("Angle to the blue flag: "+cameraAngle);
        if(cameraAngle >= 100 || !lineOfSight || targetBall.hasOwner) {
            visualsParent.gameObject.SetActive(false);
        } else {
            visualsParent.gameObject.SetActive(true);
        }
    }
}
