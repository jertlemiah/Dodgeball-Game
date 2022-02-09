using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollision(Collision c)
    {
        Debug.Log(gameObject.name+" has been hit by "+c.gameObject.name);
    }
}
