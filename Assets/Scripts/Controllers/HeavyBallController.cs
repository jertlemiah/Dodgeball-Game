using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyBallController : DodgeballController
{
    // Start is called before the first frame update
    new public void Start()
    {
        base.Start(); 
        velocity = 8.5f;
        damage = 50;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}