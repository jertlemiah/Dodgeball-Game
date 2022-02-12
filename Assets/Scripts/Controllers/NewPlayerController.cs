using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class NewPlayerController : MonoBehaviour
{
    public int health;
    public bool hasBall = false;
    // Need to create a reference to the type of ball
    public GameObject heldBallGO;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
