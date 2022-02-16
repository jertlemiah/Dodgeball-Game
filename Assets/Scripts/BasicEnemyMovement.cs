using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyMovement : MonoBehaviour
{
 
     private bool dirRight = true;
     public float speed = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dirRight)
            transform.Translate (Vector2.right * speed * Time.deltaTime);
        else
            transform.Translate (-Vector2.right * speed * Time.deltaTime);
        
        if(transform.position.x >= 4.0f) {
            dirRight = false;
        }
        
        if(transform.position.x <= -4) {
            dirRight = true;
        }
        
    }
}
