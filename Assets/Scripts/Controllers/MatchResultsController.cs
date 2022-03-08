using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchResultsController : MonoBehaviour
{
    [SerializeField] GameObject Team1WinsPanel;
    [SerializeField] GameObject Team2WinsPanel;
    [SerializeField] GameObject TieGamePanel;
    void Awake()
    {
        EventManagerSO.E_EndGame += EndMatchUI;
    } 
    void OnDisable()
    {
        EventManagerSO.E_EndGame -= EndMatchUI;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void EndMatchUI(Team winningTeam){
        if(winningTeam == Team.Team1)
        {
            Team1WinsPanel.SetActive(true);
            Team2WinsPanel.SetActive(false);
            TieGamePanel.SetActive(false);
        }
        else if(winningTeam == Team.Team2)
        {
            Team2WinsPanel.SetActive(true);
            Team1WinsPanel.SetActive(false);
            TieGamePanel.SetActive(false);
        }
        else{
            TieGamePanel.SetActive(true);
            Team1WinsPanel.SetActive(false);
            Team2WinsPanel.SetActive(false);
        }
    }
    private void TurnOffGameOverCanvas()
    {
        Team1WinsPanel.SetActive(false);
        Team2WinsPanel.SetActive(false);
        TieGamePanel.SetActive(false);
    }
}
