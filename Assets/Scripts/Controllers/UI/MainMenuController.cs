using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public enum MenuScreen {Title,Play,Settings,Credits,LevelDetails}
public class MainMenuController : Singleton<MainMenuController>
{
    [SerializeField] public List<MenuScreen> screenHistory = new List<MenuScreen>();
    [SerializeField] public MenuScreen currentScreen;
    [SerializeField] GameObject titleScreenGO;
    [SerializeField] GameObject levelSelectScreenGO;
    [SerializeField] GameObject settingsScreenGO;
    [SerializeField] GameObject creditsScreenGO;
    [SerializeField] GameObject levelDetailsScreenGO;
    [SerializeField] Image levelDetailsImage;
    [SerializeField] TMP_Text levelDetailsText;
    [SerializeField] GameObject levelDetailsMask;
    public LevelDataSO selectedLevel;
    [SerializeField] float screenWidth = 1000f;
    [SerializeField] float screenHeight = 600f;
    [SerializeField] float screenTransitionTime = 1f;
    Dictionary<MenuScreen, GameObject> menuScreenDict = new Dictionary<MenuScreen, GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        RectTransform rt = titleScreenGO.GetComponent<RectTransform>();
        screenWidth = rt.rect.width * rt.localScale.x;
        screenHeight = rt.rect.height * rt.localScale.y;
        menuScreenDict.Add(MenuScreen.Title,titleScreenGO);
        menuScreenDict.Add(MenuScreen.Play,levelSelectScreenGO);
        menuScreenDict.Add(MenuScreen.Settings,settingsScreenGO);
        menuScreenDict.Add(MenuScreen.Credits,creditsScreenGO);
        menuScreenDict.Add(MenuScreen.LevelDetails,levelDetailsScreenGO);
        currentScreen = MenuScreen.Title;
        screenHistory.Add(currentScreen);
        titleScreenGO.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        // SwitchToScreen(MenuScreen.Title);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SwitchToScreen(MenuScreen newScreen, bool forwards) 
    {
        if(menuScreenDict.ContainsKey(newScreen)){
            Debug.Log(currentScreen.ToString()+" switching to screen '"+newScreen.ToString()+"'");
            GameObject curScreenGO = menuScreenDict[currentScreen];
            GameObject newScreenGO = menuScreenDict[newScreen];
            
            Vector2 offscreenPos = new Vector2(-screenWidth,0);
            if(forwards){
                screenHistory.Add(newScreen);
            } else {
                offscreenPos = -offscreenPos;
                screenHistory.RemoveAt(screenHistory.Count-1);
            }

            // First place the screens in the correct places for transitions
            newScreenGO.GetComponent<RectTransform>().anchoredPosition = -offscreenPos;
            newScreenGO.SetActive(true);
            titleScreenGO.GetComponent<CanvasGroup>().alpha = 0;
            

            // Then transition to the new screen
            curScreenGO.GetComponent<RectTransform>().DOAnchorPos(offscreenPos,screenTransitionTime);
            curScreenGO.GetComponent<CanvasGroup>().DOFade(0,screenTransitionTime*0.5f);
            // curScreenGO.SetActive(false);
            newScreenGO.GetComponent<RectTransform>().DOAnchorPos(Vector2.zero,screenTransitionTime);
            newScreenGO.GetComponent<CanvasGroup>().DOFade(1,screenTransitionTime*1.5f);

            currentScreen = newScreen;
        }
        else {
            Debug.Log("Screen '"+newScreen.ToString()+"' does not exist, staying on current Screen '"+currentScreen.ToString()+"'");
        }
    }
    // public void OverrideScreenSwitch(MenuScreen newScreen)
    // {
        
    //     playScreenGO.GetComponent<RectTransform>().DOAnchorPos(Vector2.zero,screenTransitionTime);
    // }
    public void ReturnButton()
    {
        if(screenHistory.Count > 1){
            SwitchToScreen(screenHistory[screenHistory.Count-2],false);
        }
    }
    public void LoadLevelDetails(LevelPanelController levelPanelController) 
    {
        // GameSceneManager.Instance.LoadScene(sceneIndex);
        // levelPanelController.GetComponent<RectTransform>().DOSizeDelta(new Vector2(screenWidth,screenHeight),screenTransitionTime);
        selectedLevel = levelPanelController.levelData;
        RectTransform panelRT = levelPanelController.GetComponent<RectTransform>();
        // RectTransform maskRT = levelDetailsMask.GetComponent<RectTransform>();

        levelDetailsImage.sprite = selectedLevel.panelImage;
        levelDetailsText.text = "LEVEL - "+selectedLevel.levelName;
        SwitchToScreen(MenuScreen.LevelDetails,true);
        // maskRT.position = panelRT.position;

        // maskRT.SetSizeWithCurrentAnchors( RectTranform.Axis.Vertical, myHeight);
    }
    // public void LoadLevelDetails(LevelDataSO levelData)
    // {
    //     levelDetailsImage.sprite = levelData.panelImage;
    //     levelDetailsText.text = "LEVEL - "+levelData.levelName;
    //     levelDetailsMask
    // }
    public void Title_LevelSelectButton()
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
        // titleScreenGO.GetComponent<RectTransform>().DOAnchorPos(new Vector2(-screenWidth,0),screenTransitionTime);
        // playScreenGO.GetComponent<RectTransform>().DOAnchorPos(Vector2.zero,screenTransitionTime);
        SwitchToScreen(MenuScreen.Play,true);
    }
    public void Title_SettingsButton()
    {
        SwitchToScreen(MenuScreen.Settings,true);
    }   
    public void Title_CreditsButton()
    {
        SwitchToScreen(MenuScreen.Credits,true);
    } 
    public void Level_PlayButton()
    {
        Debug.Log("Launching the level '"+selectedLevel.sceneIndex.ToString()+"'");
        GameSceneManager.Instance.LoadScene(selectedLevel.sceneIndex);
    } 
    public void QuitButton()
    {
        Debug.Log("Quitting game");
        Application.Quit();
    }
}
