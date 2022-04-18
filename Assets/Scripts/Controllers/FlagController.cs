using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;

public enum FlagState {HOME, TRANSIT, DROPPED, CONTESTED, CAPTURING, RETURNING}
[RequireComponent(typeof(Rigidbody))]
public class FlagController : MonoBehaviour
{
    public Team teamOwner;
    bool InTransit;
    Vector3 startingPosition;
    Quaternion startingRotation;
    public GameObject playerWithFlag;
    public float captureTime = 5f;
    [SerializeField] public List<RecentPlayer> contendingPlayers = new List<RecentPlayer>();
    public FlagState currentFlagState;
    private Transform originalParent;
    public Vector3 originalPosition;
    private Quaternion originalRotation;

    [SerializeField] Collider captureCollider;

    #region MonoBehaviour
    void Start()
    {
        originalParent = transform.parent;
        originalPosition = transform.position;
        originalRotation = transform.rotation;
        InTransit = false;
        startingPosition = transform.position; 
        startingRotation = transform.rotation;
        if (!captureCollider) {
            captureCollider = GetComponentInChildren<Collider>();
        }
        GetComponent<Rigidbody>().useGravity = false;
    }

    void Update()
    {
        
        DetermineContendStatus();
        if (currentFlagState == FlagState.TRANSIT) {
            contendingPlayers.Clear();
        } else if(currentFlagState != FlagState.CONTESTED) {
            UpdateRecentPlayersList();
        }
        UpdateFlagProgress();

        

        // Turn off the capture collider
        if (currentFlagState == FlagState.TRANSIT) {
            captureCollider.gameObject.SetActive(false);
        } else {
            captureCollider.gameObject.SetActive(true);
        }
        
    }

    private void OnTriggerEnter(Collider collider) 
    {
        Debug.Log("collided with "+collider.gameObject.name);
        if (collider.gameObject.tag == "Player") // Acceptable colliders for taking the flag
        {
            contendingPlayers.Add(new RecentPlayer(collider.GetComponent<UnitController>()));
        } if (collider.gameObject.tag == "Base" && playerWithFlag) // Acceptable colliders for scoring the flag
        {
            Debug.Log("collided with "+collider.gameObject.name);
            // TODO: Need to differentiate between the different teams
            if (originalParent.gameObject != collider.transform.parent.gameObject) {
                FlagScored();
            }
        }        
    }
    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player") // Acceptable colliders for taking the flag
        {
            RemovePlayerFromRecent(collider.GetComponent<UnitController>());
        }  
    }

    #endregion MonoBehaviour

    // HUD_CONTROLLER_TYPE mHUDController;

    void UpdateFlagProgress()
    {
        if(currentFlagState == FlagState.TRANSIT) {
            HudController.Instance.SetFlagCaptureProgress(teamOwner, 0); 
            return;
        }
        
        float highestProgress = 0;
        for (int i = 0; i < contendingPlayers.Count; i++) {
            RecentPlayer player = contendingPlayers[i];
            float progress = player.timeSpent/captureTime;
            if (progress > highestProgress) {
                highestProgress = progress;
            }
        }
        HudController.Instance.SetFlagCaptureProgress(teamOwner, highestProgress);   
        // // tmpText = flagIndicatorBlueGO.GetComponentInChildren<TextMeshProUGUI>();
        // if(teamOwner == Team.Team1) {
        //     // Blue team
                     
        // } else {
        //     // Red Team

        // }
    }

    void RemovePlayerFromRecent(UnitController unitController) {
        int playerIndex = -1;
        for (int i = 0; i < contendingPlayers.Count; i++) {
            RecentPlayer player = contendingPlayers[i];
            if (player.unitController == unitController) {
                playerIndex = i;
            }
        }

        if (playerIndex >= 0) {
            contendingPlayers.RemoveAt(playerIndex);
        } 
    }

    void UpdateRecentPlayersList()
    {
        List<RecentPlayer> newPlayersList = new List<RecentPlayer>(); // This needs to be like this because C# does not allow modifying the list you are looping through
        // Manage the recent memory players
        for (int i = 0; i < contendingPlayers.Count; i++) {
            
            RecentPlayer player = contendingPlayers[i];
            // Debug.Log("updaging time for "+player.unitController.gameObject.name);
            if (currentFlagState == FlagState.HOME && teamOwner == player.unitController.team) {
                player.timeSpent = 0;
            } else {
                player.timeSpent += Time.deltaTime;
            }
            

            // captureTime
            if (player.timeSpent >= captureTime) {
                // Then capture or return the flag
                if (player.unitController.team == teamOwner) {
                    FlagReturned();
                } else {
                    FlagTaken(player.unitController);
                }
            } 
            newPlayersList.Add(player);
        }
        contendingPlayers = newPlayersList;
    }

    [SerializeField] bool allyNearby = false;
    [SerializeField] bool enemyNearby = false;

    void DetermineContendStatus()
    {
        // {HOME, TRANSIT, DROPPED, CONTESTED, CAPTURING, RETURNING}
        if (currentFlagState == FlagState.TRANSIT) {
            // if in transit, do nothing
            return;
        }
        
        allyNearby = false;
        enemyNearby = false;
        foreach (RecentPlayer player in contendingPlayers){
            if (player.unitController.team == teamOwner) {
                allyNearby = true;
            } else {
                enemyNearby = true;
            }
        }

        if (!allyNearby && !enemyNearby) {
            // No one is nearby, state is either HOME or DROPPED. HOME is only set on score or return, so if it is not already home, then it has been dropped
            if(currentFlagState != FlagState.HOME && transform.position != originalPosition) {
                currentFlagState = FlagState.DROPPED;
            }
        } 
        else if (allyNearby && enemyNearby) {
            // If people from both teams are present, flag is contested
            currentFlagState = FlagState.CONTESTED;
        } 
        else if (allyNearby && currentFlagState!=FlagState.HOME) {
            // If only allies are around & flag is not HOME or TRANSIT, then return
            currentFlagState = FlagState.RETURNING;
        }
        else if (enemyNearby) {
            // If only enemies are around & not in transit, then capture
            currentFlagState = FlagState.CAPTURING;
        }

        HudController.Instance.UpdateFlagStatus(teamOwner, currentFlagState);
    }

    public bool IsFlagInTransit { get { return InTransit; } }

    /** Flag Taken Function
     * Called by player/CPU that is trying to take the flag. 
     * Returns: True if "taking the flag" action is successful, false if the flag cannot be taken
     */
    public bool FlagTaken(UnitController player)
    {
        // if (InTransit)
        // {
        //     // if the flag is already in transit, then you can't take it. 
        //     // This would occur if a teammate and you try to take the flag at the same time, only one of you can get it.
        //     return false;
        // }
        // else
        {
            currentFlagState = FlagState.TRANSIT;
            transform.SetParent(player.flagSpot.transform);
            transform.position = player.flagSpot.transform.position;
            transform.rotation = player.flagSpot.transform.rotation;
            // // disable the base
            // transform.Find("FlagBase").gameObject.SetActive(false);
            // transform.Find("FlagPole").gameObject.SetActive(false);
            // InTransit = true;
            playerWithFlag = player.gameObject;
            // transform.position = player.transform.Find("Skeleton/FlagCarryTarget").transform.position;
            // transform.SetParent(player.transform.Find("Skeleton/FlagCarryTarget").transform);
            // //this.GetComponent<Collider>().isKinematic = true;

            // true bc team actively has flag
            // Team team = playerWithFlag.tag == "Player" ? Team.Team1 : Team.Team2;
            EventManagerSO.TriggerEvent_UpdateFlagStatus(teamOwner, currentFlagState);

            // Turn off the Flag Capture Indicator when the human grabs the flag
            if(playerWithFlag.GetComponent<HumanInput>()) {
                HudController.Instance.SetFlagActive(teamOwner, false);
            } else {
                HudController.Instance.SetFlagActive(teamOwner, true);
            }

            return true;
        }
    }


    /** Flag Scored Function
     * Called by player/CPU that is trying to score the flag
     * Returns: True if the "scoring the flag" action is successful, false if the flag cannot be scored
     */
    public bool FlagScored()
   {
        // if (!InTransit) // add conditions where we don't want to score the flag here
        // {
        //     return false;
        // }
        // else
        {
            // currentFlagState = FlagState.HOME;
            // // Call the environment.Score script here to increment the score
            // // Then, reset the flag's position and base
            // transform.Find("FlagBase").gameObject.SetActive(true);
            // transform.Find("FlagPole").gameObject.SetActive(true);
            // transform.SetParent(null);

            // // false bc team does not actively have flag
            // Team team = PlayerWithFlag.tag == "Player" ? Team.Team1 : Team.Team2;
            // EventManagerSO.TriggerEvent_UpdateFlagStatus(team, false);
            if (teamOwner == Team.Team1){
                EventManagerSO.TriggerEvent_GiveTeamPoints(Team.Team2, 1);
            } else {
                EventManagerSO.TriggerEvent_GiveTeamPoints(Team.Team1, 1);
            }
            
            
            
            
            // PlayerWithFlag = null;
            // transform.position = startingPosition;
            // transform.rotation = startingRotation;
            // InTransit = false;
            // return true;

            FlagReturned();
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
        // if (!InTransit) // can't drop a flag that isn't in transit
        // { 
        //     return false; 
        // }
        // else
        {
            currentFlagState = FlagState.DROPPED;
            // transform.Find("FlagBase").gameObject.SetActive(true); // re enable base and pole
            // transform.Find("FlagPole").gameObject.SetActive(true);
            // transform.SetParent(null); // remove parent flag carrier

            transform.SetParent(originalParent);
            transform.rotation = Quaternion.identity;

            NavMeshHit navmeshHit;
            NavMesh.SamplePosition(transform.position,out navmeshHit, 50f, NavMesh.AllAreas);
            transform.position = navmeshHit.position;

            // false bc team does not actively have flag
            // Team team = PlayerWithFlag.tag == "Player" ? Team.Team1 : Team.Team2;
            EventManagerSO.TriggerEvent_UpdateFlagStatus(teamOwner, currentFlagState);
            playerWithFlag = null; // null out PlayerWithFlag
            // transform.position = new Vector3(transform.position.x, startingPosition.y, transform.position.z); // lower it to the ground
            // transform.rotation = startingRotation;
            // InTransit = false; // no longer in transit
            HudController.Instance.SetFlagActive(teamOwner, true);
            return true;
        }
    }


    /** Flag Returned Function
     * Called by Environment to return the flag. 
     * Returns: True if the "returning the flag" action is successful, false if the flag cannot be returned
     */
    public bool FlagReturned()
    {
        // if (!InTransit)
        // {
        //     return false;
        // }
        // else
        {
            Debug.Log("Returning team "+teamOwner+"'s flag");
            currentFlagState = FlagState.HOME;
            contendingPlayers.Clear();
            // transform.Find("FlagBase").gameObject.SetActive(true);
            // transform.Find("FlagPole").gameObject.SetActive(true);
            // transform.SetParent(null);
            transform.SetParent(originalParent);
            // transform.position = originalPosition;
            transform.DOMove(originalPosition,0.1f);
            transform.rotation = originalRotation;
            
            // false bc team does not actively have flag
            // Team team = PlayerWithFlag.tag == "Player" ? Team.Team1 : Team.Team2;
            EventManagerSO.TriggerEvent_UpdateFlagStatus(teamOwner, currentFlagState);

            playerWithFlag = null;
            // transform.position = startingPosition;
            // transform.rotation = startingRotation;
            // InTransit = false;
            HudController.Instance.SetFlagActive(teamOwner, true);
            return true;
        }
    }
    
}

[Serializable]
public struct RecentPlayer{
    public UnitController unitController;
    public float timeSpent;

    public RecentPlayer(UnitController controller){
        unitController = controller;
        timeSpent = 0;
    }
}
