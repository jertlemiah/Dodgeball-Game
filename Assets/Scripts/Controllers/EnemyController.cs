using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    public float health = 100f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision c)
    {
        health = health - (health * c.gameObject.GetComponent<DodgeballController>().damage);
        Debug.Log(health);
        Debug.Log(gameObject.name+" has been hit by "+c.gameObject.name);
    }
}
