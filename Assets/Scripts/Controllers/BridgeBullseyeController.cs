using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeBullseyeController : MonoBehaviour
{
    bool IsBroken;
    GameObject ParentBridge;
    // Start is called before the first frame update
    void Start()
    {
        IsBroken = false;
        ParentBridge = this.transform.parent.gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!IsBroken && other.CompareTag("Ball"))
        { 
            foreach (Transform child in ParentBridge.transform)
            {
                child.GetComponent<Rigidbody>().isKinematic = false;
                if (child.GetComponent<BridgeBullseyeController>() != null)
                {
                    child.GetComponent<CapsuleCollider>().isTrigger = false;
                }
            }
            IsBroken = true;
        }
    }


}
