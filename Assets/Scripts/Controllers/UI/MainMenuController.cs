using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public enum MenuScreen {Title,Play,Settings,Credits,LevelDetails}
public class MainMenuController : Singleton<MainMenuController>
{
    [SerializeField] public Screen currentScreen;
    [SerializeField] GameObject titleScreenGO;
    [SerializeField] GameObject playScreenGO;
    [SerializeField] GameObject settingsScreenGO;
    [SerializeField] float screenWidth = 1000f;
    [SerializeField] float screenHeight = 600f;
    [SerializeField] float screenTransitionTime = 1f;
    // Start is called before the first frame update
    void Start()
    {
        RectTransform rt = titleScreenGO.GetComponent<RectTransform>();
        screenWidth = rt.rect.width * rt.localScale.x;
        screenHeight = rt.rect.height * rt.localScale.y;
        playScreenGO.GetComponent<RectTransform>().anchoredPosition = new Vector2(screenWidth,0);
        settingsScreenGO.GetComponent<RectTransform>().anchoredPosition = new Vector2(0,screenHeight);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // public void OverrideScreenSwitch(MenuScreen newScreen)
    // {
        
    //     playScreenGO.GetComponent<RectTransform>().DOAnchorPos(Vector2.zero,screenTransitionTime);
    // }
    public void Play_LevelDetailsButton(LevelPanelController levelPanelController) 
    {
        // GameSceneManager.Instance.LoadScene(sceneIndex);
        levelPanelController.GetComponent<RectTransform>().DOSizeDelta(new Vector2(screenWidth,screenHeight),screenTransitionTime);
    }
    public void Title_PlayButton()
    {
        // titleScreenGO.GetComponent<RectTransform>().DOMoveX(-offscreenHorizontal,screenTransitionTime);
        // playScreenGO.GetComponent<RectTransform>().DOMoveX(0,screenTransitionTime);
        // Vector3 rotation = new Vector3(0,45,0);
        // // titleScreenGO.GetComponent<RectTransform>().DORotate(rotation,screenTransitionTime);
        // // titleScreenGO.GetComponent<CanvasGroup>().DOFade(0,screenTransitionTime);
        // // titleScreenGO.GetComponent<CanvasGroup>().interactable = false;
        // // titleScreenGO.GetComponent<CanvasGroup>().blocksRaycasts = false;
        // titleScreenGO.GetComponent<RectTransform>().DOMoveX(-offscreenHorizontal,screenTransitionTime);
        // // playScreenGO.GetComponent<RectTransform>().DORotate(Vector3.zero,screenTransitionTime);
        // // playScreenGO.GetComponent<CanvasGroup>().DOFade(1,screenTransitionTime);
        // // playScreenGO.GetComponent<CanvasGroup>().interactable = true;
        // // playScreenGO.GetComponent<CanvasGroup>().blocksRaycasts = true;
        // playScreenGO.GetComponent<RectTransform>().DOMoveX(0,screenTransitionTime);

        // titleScreenGO.SetActive(false);
        titleScreenGO.GetComponent<RectTransform>().DOAnchorPos(new Vector2(-screenWidth,0),screenTransitionTime);
        playScreenGO.GetComponent<RectTransform>().DOAnchorPos(Vector2.zero,screenTransitionTime);
    }
    public void Play_ReturnButton()
    {
        // Vector3 rotation = new Vector3(0,45,0);
        // // titleScreenGO.GetComponent<RectTransform>().DORotate(Vector3.zero,screenTransitionTime);
        // // titleScreenGO.GetComponent<CanvasGroup>().DOFade(1,screenTransitionTime);
        // // titleScreenGO.GetComponent<CanvasGroup>().interactable = true;
        // // titleScreenGO.GetComponent<CanvasGroup>().blocksRaycasts = true;
        // titleScreenGO.GetComponent<RectTransform>().DOMoveX(0,screenTransitionTime);
        // // playScreenGO.GetComponent<RectTransform>().DORotate(-rotation,screenTransitionTime);
        // // playScreenGO.GetComponent<CanvasGroup>().DOFade(0,screenTransitionTime);
        // // playScreenGO.GetComponent<CanvasGroup>().interactable = false;
        // // playScreenGO.GetComponent<CanvasGroup>().blocksRaycasts = false;
        // playScreenGO.GetComponent<RectTransform>().DOMoveX(offscreenHorizontal,screenTransitionTime);
        // titleScreenGO.SetActive(true);
        titleScreenGO.GetComponent<RectTransform>().DOAnchorPos(Vector2.zero,screenTransitionTime);
        playScreenGO.GetComponent<RectTransform>().DOAnchorPos(new Vector2(screenWidth,0),screenTransitionTime);
    }
    public void Title_SettingsButton()
    {
        titleScreenGO.GetComponent<RectTransform>().DOAnchorPos(new Vector2(0,-screenHeight),screenTransitionTime);
        settingsScreenGO.GetComponent<RectTransform>().DOAnchorPos(Vector2.zero,screenTransitionTime);
    }
    public void Settings_ReturnButton()
    {
        titleScreenGO.GetComponent<RectTransform>().DOAnchorPos(Vector2.zero,screenTransitionTime);
        settingsScreenGO.GetComponent<RectTransform>().DOAnchorPos(new Vector2(0,screenHeight),screenTransitionTime);
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
