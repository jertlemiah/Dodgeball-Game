using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(CharacterController))]
public class UnitController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] const float IFRAME_TIME = 1f;
    [SerializeField] private float timeOfLastHit;
    public int healthCurrent = 2;
    public int healthMax = 2;
    public bool hasBall = false;
    // Need to create a reference to the type of ball
    public GameObject heldBallGO;
    // Start is called before the first frame update
    public Team team = Team.Team1;
    public float DAMAGE_SPEED = 5; //  the minimum speed from which a ball will deal damage. This value needs to be elsewhere
    void Start()
    {
        healthCurrent = healthMax;
        timeOfLastHit = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(int damage)
    {
        timeOfLastHit = Time.time;
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
        if(collision.gameObject.CompareTag("Ball") && collision.rigidbody.velocity.magnitude > DAMAGE_SPEED){
            if((Time.time - timeOfLastHit) > IFRAME_TIME){
                TakeDamage(1);
            }
            
        }
    }

    public void Move(Vector3 direction)
    {

    }
    public void Jump()
    {

    }
    public void Throw(Vector3 direction)
    {

    }
}
