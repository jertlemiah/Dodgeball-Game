using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// State Machine implementation.
/// Uses BaseState as base class for storing currently operating state.
/// </summary>
public class AIStateMachine : MonoBehaviour
{
    [SerializeField] public AIController aiController  => GetComponent<AIController>();
    [SerializeField] public AIState currentState;
    [SerializeField] public AIStateEnum currentStateEnum;
    [SerializeField] public AIStateEnum defaultState;
    public Dictionary<AIStateEnum, AIState> stateDictionary;
    bool busyChange;
    void Start(){
        // StartMachine(this.gameObject,aiController.states);
    }
    public void StartMachine(GameObject playerObject, List<AIState> states)
    {
        // if(machineStarted) return;
        stateDictionary = new Dictionary<AIStateEnum, AIState>();

        for (int i = 0; i<states.Count; i++)
        {
            if (states[i] == null)
            {
                continue;
            }
            // states[i].Init(this);
            if(!stateDictionary.ContainsKey(states[i].aiStateEnum)){
                stateDictionary.Add(states[i].aiStateEnum, states[i]);
            }
            
        }

        // previousState = stateDictionary[MinionStateEnum.Idle];
        currentState = stateDictionary[defaultState];
        

        ChangeState(defaultState);
    }

    /// <summary>
    /// Unity method called each frame
    /// </summary>
    private void Update()
    {
        // If we have reference to state, we should update it!
        // if (currentState != null)
        // {
        //     currentState.UpdateState();
        // }
        currentState?.UpdateState(); // ? means do this if it is not null
    }
    /// <summary>
    /// Method used to change state
    /// </summary>
    /// <param name="newState">New state.</param>
    // public void ChangeState(UnitState newState)
    // {
    //     // If we currently have state, we need to destroy it!
    //     if (currentState != null)
    //     {
    //         currentState.ExitState();
    //     }
    //     // Swap reference
    //     currentState = newState;
    //     // If we passed reference to new state, we should assign owner of that state and initialize it!
    //     // If we decided to pass null as new state, nothing will happened.
    //     if (currentState != null)
    //     {
    //         currentState.ownerStateMachine = this;
    //         currentState.EnterState();
    //     }
    // }
    public void ChangeState(AIStateEnum newState) //call this function when changing states
    { 
        if (!busyChange){
            StartCoroutine(ChangeStateWait(newState));
        }
    }

    public IEnumerator ChangeStateWait(AIStateEnum newState)
    {
        busyChange = true;
        currentState.ExitState();
        currentState = stateDictionary[newState];
        currentStateEnum = currentState.aiStateEnum;
        Debug.Log(gameObject.name +" changing to state "+newState.ToString());
        currentState.EnterState();
        yield return new WaitForEndOfFrame();
        busyChange = false;
    }
}