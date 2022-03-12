using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SimpleAIUnitController : MonoBehaviour
{
    private NavMeshAgent agent;  // navMeshAgent used to set destination, and also to check remaining distance in ChasePlayer state (to get in throwing range)
    public GameObject targetObject; // our target object (for chase player and chase dodgeball). Updated each Update() to prevent us from going after the "wrong" thing
    public GameObject[] enemyPlayers; // array of all players on MC team
    public GameObject[] activeDodgeballs; // array of all active dodgeballs. Right now is static on game start, will be dynamic in city level
    private float minimumTimeInState; // minimum time in ChasePlayer before it switches to ChaseBall, keeps things smooth. Can be reduced
    public float currentTimeInState; // current time in the state we are in

    private enum SimpleAIState {Idle, UpdateTarget, ChaseBall, ChasePlayer}; // 4 states, ctf not implemented yet. Gonna complicate things
    private SimpleAIState state; // our current state
    private Vector3 forwardDirection; // the forward direction of our AI unit, used for throwing direction. See ThrowBall()
    public bool hasBall; // Does this AI unit currently have a ball

    // Start is called before the first frame update
    void Start()
    {
        // init our variables
        agent = GetComponent<NavMeshAgent>(); 
        state = SimpleAIState.Idle;
        hasBall = false;
        minimumTimeInState = 2.0f;
        currentTimeInState = 0.0f;
    }

    /** Function FindNearestEnemyPlayer
     * Function to find the nearest enemy player to this AI unit
     * Iterates through enemyPlayers array, finds the nearest one, and returns it
     */
    GameObject FindNearestEnemyPlayer()
    {
        float currentShortest = float.MaxValue; // see FindNearestDodgeballs for more in depth comments, they are exactly the same
        int currentShortestIdx = -1;
        for (int i = 0; i < enemyPlayers.Length; i++)
        {
            if (Vector3.Distance(this.transform.position, enemyPlayers[i].transform.position) < currentShortest )
            {
                currentShortest = Vector3.Distance(this.transform.position, enemyPlayers[i].transform.position);
                currentShortestIdx = i;
            }
        }
        if (currentShortestIdx < 0)
        {
            return null;
        }
        else
        {
            return enemyPlayers[currentShortestIdx];
        }
    }

    /** Function FindNearestDodgeball
     * Function to find the nearest dodgeball to this AI unit
     * Iterates through activeDodgeballs array, finds the nearest one, and returns it
     */
    GameObject FindNearestDodgeball()
    {
        float currentShortest = float.MaxValue; // init to max so any dodgeball is closer
        int currentShortestIdx = -1;
        for (int i = 0; i < activeDodgeballs.Length; i++)  // iterate through all active dodgeballs
        {
            if (Vector3.Distance(this.transform.position, activeDodgeballs[i].transform.position) < currentShortest) // if the current dodgeball is closer than our previous closest
            {
                if (activeDodgeballs[i].transform.parent == null) // if this dodgeball doesn't have a parent (AKA its not being held by somebody else right now)
                {
                    currentShortest = Vector3.Distance(this.transform.position, activeDodgeballs[i].transform.position); // set its distance as new "current shortest"
                    currentShortestIdx = i; // set its idx as new "current shortest idx"
                }
            }
        }
        if (currentShortestIdx < 0) // if there are no active dodgeballs, return null
        {
            return null;
        }
        else
        {
            return activeDodgeballs[currentShortestIdx]; // else return the nearest non-owned dodgeball
        }
    }

    // Update is called once per frame
    void Update()
    {
        currentTimeInState = currentTimeInState + Time.deltaTime; // increment time in state
        forwardDirection = transform.forward; // always get our current forward direction, so we can throw the ball the right way
        /** Handle State Transitions 
         * This top switch statement handles state transitions. The bottom switch statement handles the "state actions" or what you do while you are in your state. 
         */
        switch (state)
        {
            case SimpleAIState.Idle: 
                /** Idle state immediately goes to Update Target
                 * My only concern is if all dodgeballs are held (or enemies are respawning) and we are looking for one, 
                 * we will toggle between Idle and Update Target. Maybe we can chill here for a bit and do an emote?
                 */
                state = SimpleAIState.UpdateTarget;
                currentTimeInState = 0.0f; // reset current time in state
                break;
            case SimpleAIState.UpdateTarget:
                /** Update Target can transition to 
                 * 1) Chase Player - if we have a ball and found a player to chase
                 * 2) Chase Ball - we don't have a ball and found a ball to chase
                 * 3) Idle - if there are no ball/players to chase :(
                 */
                if (hasBall == true) // if we already have a ball, find the nearest player
                {
                    /* Cramming the entry conditions in here for now
                     * Find the nearest Player, set that to the targetObject.
                     */
                    targetObject = FindNearestEnemyPlayer();
                    if (targetObject == null) // if all enemy players are currently respawning, go back to Idle 
                    {
                        state = SimpleAIState.Idle;
                    }
                    else // if we found a good enemy player target, set it as the new destination and transition to ChasePlayer
                    {
                        agent.destination = targetObject.transform.position;
                        state = SimpleAIState.ChasePlayer;
                        currentTimeInState = 0.0f; // reset current time in state
                    }
                }
                else // if we don't have a ball, go get the nearest one
                {
                    /* Cramming the entry conditions in here for now
                     * Find the nearest Dodgeball, set that to the targetObject.
                     */
                    targetObject = FindNearestDodgeball();
                    if (targetObject == null) // if all dodgeballs are currently held, then go back to Idle
                    {
                        state = SimpleAIState.Idle;
                    }
                    else // if we found a good dodgeball, set it as the new destination and transition to ChaseBall state
                    {
                        agent.destination = targetObject.transform.position;
                        state = SimpleAIState.ChaseBall;
                        currentTimeInState = 0.0f; // reset current time in state
                    }
                }
                break;
            case SimpleAIState.ChaseBall:
                if (hasBall == true) // If we now have a ball (this is set by the "ChaseBall" state action, see below switch statement)
                {
                    state = SimpleAIState.ChasePlayer; // transition to Chase Player state
                    currentTimeInState = 0.0f; // reset current time in state
                }
                break;
            case SimpleAIState.ChasePlayer:
                // if we don't have the ball anymore (we threw it, see "ChasePlayer" state action in below switch statement) and we've been in the state long enough (for movement smoothness)
                if (!hasBall && currentTimeInState > minimumTimeInState)
                {
                    state = SimpleAIState.ChaseBall; // transition to the Chase Ball state
                    currentTimeInState = 0.0f; // reset current time in state
                }
                break;
            default:
                break;
        }

        /* Handle State Actions */
        switch (state)
        {
            case SimpleAIState.ChaseBall:
                //Always chase the nearest dodgeball. Update the navMeshAgent's destination so we don't end up chasing a fast moving ball while walking right past a stationary one
                targetObject = FindNearestDodgeball();
                agent.destination = targetObject.transform.position;
                if (this.transform.Find("BallHoldSpotAI").childCount > 0 ) // if we've successfully picked up a dodgeball, set the hasBall flag
                {
                    hasBall = true; // this will cause us to transition into ChasePlayer state in the above switch statement
                }
                break;
            case SimpleAIState.ChasePlayer:
                // always chase the nearest player. bla bla see above comment in chaseball
                targetObject = FindNearestEnemyPlayer();
                agent.destination = targetObject.transform.position;
                if (agent.remainingDistance < 5.0f && currentTimeInState > minimumTimeInState) // if we've gotten close enough and have been in the state long enough (for smoothness)
                { 
                    ThrowBall(); // throw the ball
                    hasBall = false; 
                }
                else if (this.transform.Find("BallHoldSpotAI").childCount == 0) // our ball got stolen out of our hands :(
                {
                    hasBall = false;
                }
                break;
            default:
                break;
        }
    }

    /** Function Throw Ball
     * The function responsible for having the AI unit throw the ball 
     * Calls ThrowBall function on the SimpleAIUnitBallPickUp component, passing in the AI Unit's forward direction.
     * The forward direction gets used as the direction to apply the force (and hence throw the ball)
     */
    void ThrowBall()
    {
        this.GetComponentInChildren<SimpleAIUnitBallPickUp>().ThrowBall(forwardDirection);
    }
}
