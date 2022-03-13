using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagController : MonoBehaviour
{
    bool InTransit;
    Vector3 startingPosition;
    Quaternion startingRotation;
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
            transform.Find("FlagPole").gameObject.SetActive(false);
            InTransit = true;
            PlayerWithFlag = player;
            transform.position = player.transform.Find("Skeleton/FlagCarryTarget").transform.position;
            transform.SetParent(player.transform.Find("Skeleton/FlagCarryTarget").transform);
            this.GetComponent<Collider>().enabled = false; 
            //this.GetComponent<Collider>().isKinematic = true;

            // true bc team actively has flag
            Team team = PlayerWithFlag.tag == "Player" ? Team.Team1 : Team.Team2;
            EventManagerSO.TriggerEvent_UpdateFlagStatus(team, true);

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
            transform.Find("FlagPole").gameObject.SetActive(true);
            transform.SetParent(null);

            // false bc team does not actively have flag
            Team team = PlayerWithFlag.tag == "Player" ? Team.Team1 : Team.Team2;
            EventManagerSO.TriggerEvent_UpdateFlagStatus(team, false);
            EventManagerSO.GiveTeamPoints(team, 1);

            
            
            PlayerWithFlag = null;
            transform.position = startingPosition;
            transform.rotation = startingRotation;
            InTransit = false;
            this.GetComponent<Collider>().enabled = true;
            return true;
        }
    }

    /** FlaggedDropped Function
     * Function to handle the "dropping" of the flag
     * Makes sure you can only drop a flag that is in transit, then reactivates the base and pole. Removes the parent (newly deceased flag carrier), 
     * then sets the flag back on the ground. Finally, re-enables the collider so it can be picked up again and sets InTransit to false
     * Returns true if flag is successfully dropped, false otherwise
     */
    public bool FlagDropped()
    {
        if (!InTransit) // can't drop a flag that isn't in transit
        { 
            return false; 
        }
        else
        {
            transform.Find("FlagBase").gameObject.SetActive(true); // re enable base and pole
            transform.Find("FlagPole").gameObject.SetActive(true);
            transform.SetParent(null); // remove parent flag carrier

            // false bc team does not actively have flag
            Team team = PlayerWithFlag.tag == "Player" ? Team.Team1 : Team.Team2;
            EventManagerSO.TriggerEvent_UpdateFlagStatus(team, false);
            PlayerWithFlag = null; // null out PlayerWithFlag
            transform.position = new Vector3(transform.position.x, startingPosition.y, transform.position.z); // lower it to the ground
            transform.rotation = startingRotation;
            this.GetComponent<Collider>().enabled = true; // re enable collider so it can be picked up again
            InTransit = false; // no longer in transit
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
            transform.Find("FlagPole").gameObject.SetActive(true);
            transform.SetParent(null);
            
            // false bc team does not actively have flag
            Team team = PlayerWithFlag.tag == "Player" ? Team.Team1 : Team.Team2;
            EventManagerSO.TriggerEvent_UpdateFlagStatus(team, false);

            PlayerWithFlag = null;
            transform.position = startingPosition;
            transform.rotation = startingRotation;
            this.GetComponent<Collider>().enabled = true;
            InTransit = false;
            return true;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        InTransit = false;
        startingPosition = transform.position; 
        startingRotation = transform.rotation;
        this.GetComponent<Collider>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
