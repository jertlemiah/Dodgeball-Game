using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] GameObject titleScreenGO;
    [SerializeField] GameObject playScreenGO;
    [SerializeField] GameObject settingsScreenGO;
    [SerializeField] float offscreenHorizontal = 1000f;
    [SerializeField] float offscreenVertical = 600f;
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
        titleScreenGO.GetComponent<RectTransform>().DOMoveX(-offscreenHorizontal,screenTransitionTime);
        playScreenGO.GetComponent<RectTransform>().DOMoveX(0,screenTransitionTime);
    }
    public void Play_ReturnButton()
    {
        titleScreenGO.GetComponent<RectTransform>().DOMoveX(0,screenTransitionTime);
        playScreenGO.GetComponent<RectTransform>().DOMoveX(offscreenHorizontal,screenTransitionTime);
    }
    public void Title_SettingsButton()
    {
        titleScreenGO.GetComponent<RectTransform>().DOMoveY(offscreenVertical,screenTransitionTime);
        settingsScreenGO.GetComponent<RectTransform>().DOMoveY(0,screenTransitionTime);
    }
    public void Settings_ReturnButton()
    {
        titleScreenGO.GetComponent<RectTransform>().DOMoveY(0,screenTransitionTime);
        settingsScreenGO.GetComponent<RectTransform>().DOMoveY(-offscreenVertical,screenTransitionTime);
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
