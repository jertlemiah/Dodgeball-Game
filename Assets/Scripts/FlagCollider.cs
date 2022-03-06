using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagCollider : MonoBehaviour
{
    private FlagController mFlagController;

    // Start is called before the first frame update
    void Start()
    {
        mFlagController = this.GetComponentInParent<FlagController>();  // get the parent Flag controller, which houses all the flag logic
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider)
{
        // Flag controller functions decide whether or not the flag can be taken related to THE FLAGs current status condition. 
        // This (Flag Collider) needs to decide based on the collider aspects (who is colliding with the flag), then pass the decision making on to FlagController by way of function calls

        if (mFlagController != null)
        {
            if (collider.gameObject.tag == "Player") // Acceptable colliders for capturing the flag
            {
                mFlagController.FlagTaken(collider.gameObject);
            }
            else if (collider.gameObject.tag == "Base")
            {
                mFlagController.FlagScored();
            }
        }

    }
}
