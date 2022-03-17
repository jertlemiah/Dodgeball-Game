using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuController : MonoBehaviour
{
    [SerializeField] GameObject pauseMenuGO;
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider masterSlider;
    [SerializeField] Slider gameSfxSlider;
    [SerializeField] Slider uiSfxSlider;
    
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
        SetVolumeSliders();
    }
    void TurnOffPauseUI()
    {
        pauseMenuGO.SetActive(false);
    }

    public void LeaveMatchButton()
    {
        Debug.Log("Leaving Match");
        // Time.timeScale = 1;
        GameSceneManager.Instance.LoadScene_LoadingScreen(SceneIndex.TITLE_SCREEN);
    }

    public void ReturnButton()
    {
        EventManagerSO.TriggerEvent_UnpauseGame();
    }

    public void SetVolMaster(float newVol)
    {
        AudioManager.Instance.SetVolMaster(newVol);
    }

    public void SetVolGameSFX(float newVol)
    {
        AudioManager.Instance.SetVolGameSFX(newVol);
    }

    public void SetVolUiSFX(float newVol)
    {
        AudioManager.Instance.SetVolUiSFX(newVol);
    }

    public void SetVolMusic(float newVol)
    {
        AudioManager.Instance.SetVolMusic(newVol);
    }

    private void SetVolumeSliders()
    {
        musicSlider.value = AudioManager.Instance.GetVolMusic();
        masterSlider.value = AudioManager.Instance.GetVolMaster();
        gameSfxSlider.value = AudioManager.Instance.GetVolGameSFX();
        uiSfxSlider.value = AudioManager.Instance.GetVolUiSFX();
    }
}
