using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(CharacterController))]
public class NewPlayerController : MonoBehaviour
{
    public int healthCurrent = 2;
    public int healthMax = 2;
    public bool hasBall = false;
    // Need to create a reference to the type of ball
    public GameObject heldBallGO;
    // Start is called before the first frame update
    public Team team = Team.Team1;
    public float DAMAGE_SPEED = 5;
    void Start()
    {
        healthCurrent = healthMax;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(int damage)
    {
        // This will need to be swapped out for the real system at some point
        if(team == Team.Team1)
        {
            GameManager.Instance.GiveTeam2Points(1);
        }
        else
        {
            GameManager.Instance.GiveTeam1Points(1);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ball") && collision.rigidbody.velocity.magnitude > DAMAGE_SPEED)
        {
            TakeDamage(1);
        }
    }
}
