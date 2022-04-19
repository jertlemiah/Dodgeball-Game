using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBallController : DodgeballController
{
    // Start is called before the first frame update
    new public void Start()
    {
        base.Start();
        velocity = 20f;
        damage = 8.0f;
        dodgeballType = DodgeballType.Deathball;
    }

    // Update is called once per frame
    new public void Update()
    {
        base.Update();
    }
}
