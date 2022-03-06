using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagController : MonoBehaviour
{
    bool InTransit;
    Vector3 startingPosition;
    GameObject PlayerWithFlag;
    // HUD_CONTROLLER_TYPE mHUDController;

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
            transform.SetParent(player.transform);

            /*Call "Flag has been Taken" HUD Functions here
            if (PlayerWithFlag.tag == "Player")
            {
                mHUDController.FlagTakenByPlayer();   <- or whatever you want to call it
            }
            else if (PlayerWithFlag.tag == "Enemy")
            {
                mHUDController.FlagTakenByEnemy();   <- or whatever you want to call it
            }
             */

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
            transform.SetParent(null);
            /*Call "Flag has been Scored" HUD Functions here
            if (PlayerWithFlag.tag == "Player")
            {
                mHUDController.FlagScoredByPlayer();   <- or whatever you want to call it
            }
            else if (PlayerWithFlag.tag == "Enemy")
            {
                mHUDController.FlagScoredByEnemy();   <- or whatever you want to call it
            }
             */
            PlayerWithFlag = null;
            transform.position = startingPosition;
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
            transform.SetParent(null);
            /*Call "Flag has been Returned" HUD Functions here
            if (PlayerWithFlag.tag == "Player")
            {
                mHUDController.FlagReturnedByEnemy();   <- or whatever you want to call it
            }
            else if (PlayerWithFlag.tag == "Enemy")
            {
                mHUDController.FlagReturnedByPlayer();   <- or whatever you want to call it
            }
             */
            PlayerWithFlag = null;
            transform.position = startingPosition;
            InTransit = false;
            return true;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        InTransit = false;
        startingPosition = transform.position; 
        // Get reference to HUD Controller
        // mHUDController = GameObject.Find("WhateverTheHUDobjectNameIs").GetComponent<WhatevertheScriptNameIs>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
