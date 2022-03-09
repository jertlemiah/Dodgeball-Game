using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] GameObject titleScreenGO;
    [SerializeField] GameObject playScreenGO;
    [SerializeField] GameObject settingsScreenGO;
    [SerializeField] float offscreenOffset = 1000f;
    [SerializeField] float screenTransitionTime = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Title_PlayButton()
    {
        titleScreenGO.GetComponent<RectTransform>().DOMoveX(-offscreenOffset,screenTransitionTime);
        playScreenGO.GetComponent<RectTransform>().DOMoveX(0,screenTransitionTime);
    }
    public void Title_TrainingButton()
    {
        
    }
    public void Title_SettingsButton()
    {
        
    }
    public void Play_ReturnButton()
    {
        titleScreenGO.GetComponent<RectTransform>().DOMoveX(0,screenTransitionTime);
        playScreenGO.GetComponent<RectTransform>().DOMoveX(offscreenOffset,screenTransitionTime);
    }
    public void Play_LoadLevel(SceneIndex sceneIndex) 
    {
        GameSceneManager.Instance.LoadScene(sceneIndex);
    }
    public void QuitButton()
    {
        Debug.Log("Quitting game");
        Application.Quit();
    }
    // void OnDestroy()
    // {
        
    // }
}
