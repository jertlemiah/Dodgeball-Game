using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlane : MonoBehaviour
{
    public LayerMask PlayerLayer;//  = LayerMask.NameToLayer("Player");

    // void OnCollisionEnter(Collision c)
    void OnTriggerEnter(Collider c)
    {
        // Debug.Log("collided with "+c.gameObject.name);
        // if (c.gameObject.layer == PlayerLayer) 
        if (PlayerLayer == (PlayerLayer | (1 << c.gameObject.layer)))
        {
            UnitController unit = c.gameObject.GetComponent<UnitController>();
            if (unit != null)
            {
                Debug.Log("Deathplane killing player "+c.gameObject.name);
                unit.KillPlayer();
            }
        }
    }
}
