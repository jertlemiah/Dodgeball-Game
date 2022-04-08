using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastBallController : DodgeballController
{
    // Start is called before the first frame update
    new public void Start()
    {
        base.Start();
        velocity = 40f;
        damage = 10;
    }

    // Update is called once per frame
    new public void Update()
    {
        base.Update();
    }
}
