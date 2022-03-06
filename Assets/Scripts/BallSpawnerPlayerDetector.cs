using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawnerPlayerDetector : MonoBehaviour
{
    private Animator SpawnerAnimator;
    private float Timer;
    // Start is called before the first frame update
    void Start()
    {
        SpawnerAnimator = transform.parent.gameObject.transform.parent.GetComponent<Animator>();
        Timer = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (SpawnerAnimator != null)
        {
            if (SpawnerAnimator.GetCurrentAnimatorStateInfo(0).IsName("PopUpBall"))
            {
                Timer -= Time.deltaTime;
                if (Timer < 0.0f)
                {
                    Timer = 0.1f;
                    SpawnerAnimator.SetTrigger("GoToFloating");
                }
            }
        }
    }

    private void OnTriggerEnter(Collider player)
    {
        if (player != null)
        {
            SpawnerAnimator.SetTrigger("PlayerEnter");
        }
    }
}
