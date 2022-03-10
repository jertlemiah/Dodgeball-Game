using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuController : MonoBehaviour
{
    [SerializeField] GameObject pauseMenuGO;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake()
    {
        EventManagerSO.E_PauseGame += TurnOnPauseUI;
        EventManagerSO.E_UnpauseGame += TurnOffPauseUI;
    } 
    void OnDisable()
    {
        EventManagerSO.E_PauseGame -= TurnOnPauseUI;
        EventManagerSO.E_UnpauseGame -= TurnOffPauseUI;
    }
    void TurnOnPauseUI()
    {
        pauseMenuGO.SetActive(true);
    }
    void TurnOffPauseUI()
    {
        pauseMenuGO.SetActive(false);
    }

    public void LeaveMatchButton()
    {
        Debug.Log("Leaving Match");
        // Time.timeScale = 1;
        GameSceneManager.Instance.LoadScene(SceneIndex.TITLE_SCREEN);
    }
}
