using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    public float currentHealth = 100f;
    public float totalHealth = 100f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision c)
    {
        // Check if the object is a ball, if so, check if the ball has a hit counter of 0, if so, reduce health.
        currentHealth = currentHealth - (totalHealth * c.gameObject.GetComponent<DodgeballController>().damage);
        Debug.Log(currentHealth);
        Debug.Log(gameObject.name+" has been hit by "+c.gameObject.name);
        // If health is less than 0, return to spawn. 
            // Find a way to create a spawn timer
        // Remember to do this in the player controller too.
    }
}
