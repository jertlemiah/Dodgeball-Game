using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagController : MonoBehaviour
{
    bool InTransit;
    Vector3 startingPosition;
    GameObject PlayerWithFlag;

    public bool IsFlagInTransit { get { return InTransit; } }

    /** Flag Taken Function
     * Called by player/CPU that is trying to take the flag. 
     * Returns: True if "taking the flag" action is successful, false if the flag cannot be taken
     */
    public bool FlagTaken(GameObject player)
    {
        if (InTransit)
        {
            // if the flag is already in transit, then you can't take it. 
            // This would occur if a teammate and you try to take the flag at the same time, only one of you can get it.
            return false;
        }
        else
        {
            // disable the base
            transform.Find("FlagBase").gameObject.SetActive(false);
            InTransit = true;
            PlayerWithFlag = player;
            //transform.SetParent(player.transform);
            return true;
        }
    }


    /** Flag Scored Function
     * Called by player/CPU that is trying to score the flag
     * Returns: True if the "scoring the flag" action is successful, false if the flag cannot be scored
     */
    public bool FlagScored()
    {
        if (!InTransit) // add conditions where we don't want to score the flag here
        {
            return false;
        }
        else
        {
            // Call the environment.Score script here to increment the score
            // Then, reset the flag's position and base
            transform.Find("FlagBase").gameObject.SetActive(true);
            //transform.SetParent(null);
            PlayerWithFlag = null;
            transform.position = startingPosition;
            //transform.rotation = new Quaternion(0, 0, 0, 0);
            InTransit = false;
            return true;
        }
    }


    /** Flag Returned Function
     * Called by Environment to return the flag. 
     * Returns: True if the "returning the flag" action is successful, false if the flag cannot be returned
     */
    public bool FlagReturned()
    {
        if (!InTransit)
        {
            return false;
        }
        else
        {
            transform.Find("FlagBase").gameObject.SetActive(true);
            //transform.SetParent(null);
            PlayerWithFlag = null;
            transform.position = startingPosition;
            //transform.rotation = new Quaternion(0,0,0,0);  
            InTransit = false;
            return true;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        InTransit = false;
        //startingPosition = transform.position; 
        startingPosition = GameObject.Find("FlagReturnPos").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (InTransit && PlayerWithFlag != null)
        {
            // keep the flag "attached" to the player
            this.transform.position = PlayerWithFlag.transform.position;   
        }
    }
}
