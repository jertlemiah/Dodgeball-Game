using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public enum MenuScreen {Title,Play,Settings,Credits,LevelDetails}
public class MainMenuController : Singleton<MainMenuController>
{
    [Header("Current Menu Screen")]
    [SerializeField] public MenuScreen currentScreen;
    [SerializeField] public List<MenuScreen> screenHistory = new List<MenuScreen>();
    public LevelDataSO selectedLevel;

    [Space(10f)][Header("Game Object Properties")]
    [SerializeField] GameObject titleScreenGO;
    [SerializeField] GameObject levelSelectScreenGO;
    [SerializeField] GameObject settingsScreenGO;
    [SerializeField] GameObject creditsScreenGO;
    [SerializeField] GameObject levelDetailsScreenGO;
    [SerializeField] Image levelDetailsImage;
    [SerializeField] TMP_Text levelDetailsText;
    [SerializeField] GameObject levelDetailsMask;
    [SerializeField] AudioClip clickSound;
    [SerializeField] AudioSource audioSource;
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider masterSlider;
    [SerializeField] Slider gameSfxSlider;
    [SerializeField] Slider uiSfxSlider;

    [Space(10f)][Header("Screen Transition Settings")]
    [SerializeField] float screenTransitionTime = 1f;
    [SerializeField] float screenScaleDiff = 0.3f;

    [Space(10f)][Header("Manual Screen Override")]
    [SerializeField] public MenuScreen overrideScreen;
    Dictionary<MenuScreen, GameObject> menuScreenDict = new Dictionary<MenuScreen, GameObject>();
    float screenWidth = 1000f;
    float screenHeight = 600f;
    // Start is called before the first frame update
    void Start()
    {
        GameSceneManager.CheckPersistentScene();
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
        if(!audioSource)
            audioSource = GetComponent<AudioSource>();
        // SwitchToScreen(MenuScreen.Title);
        SetVolumeSliders();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SwitchToScreen(MenuScreen newScreen, bool forwards) 
    {
        if(!menuScreenDict.ContainsKey(newScreen)){
            Debug.Log("Screen '"+newScreen.ToString()+"' does not exist, staying on current Screen '"+currentScreen.ToString()+"'");
        }
        else {
            PlayButtonSound();
            Debug.Log(currentScreen.ToString()+" switching to screen '"+newScreen.ToString()+"'");
            GameObject curScreenGO = menuScreenDict[currentScreen];
            GameObject newScreenGO = menuScreenDict[newScreen];
            
            Vector2 offscreenPos = new Vector2(-screenWidth,0);
            float scaleDiff = screenScaleDiff;
            if(forwards){
                screenHistory.Add(newScreen);
            } else {
                offscreenPos = -offscreenPos;
                scaleDiff = -scaleDiff;
                screenHistory.RemoveAt(screenHistory.Count-1);
            }

            // First place the screens in the correct places for transitions
            
            newScreenGO.GetComponent<RectTransform>().anchoredPosition = -0.5f*offscreenPos*(1+scaleDiff/2);//*(1/3f);
            newScreenGO.SetActive(true);
            newScreenGO.GetComponent<CanvasGroup>().alpha = 0;
            newScreenGO.transform.localScale = Vector3.one*(1-scaleDiff);
            

            // Then transition to the new screen
            curScreenGO.GetComponent<RectTransform>().DOAnchorPos(offscreenPos*(1+scaleDiff/4),screenTransitionTime);
            curScreenGO.GetComponent<CanvasGroup>().DOFade(0,screenTransitionTime);
            curScreenGO.transform.DOScale(1f+scaleDiff,screenTransitionTime);
            // curScreenGO.SetActive(false);
            newScreenGO.GetComponent<RectTransform>().DOAnchorPos(Vector2.zero,screenTransitionTime);
            newScreenGO.GetComponent<CanvasGroup>().DOFade(1,screenTransitionTime*1.5f);
            newScreenGO.transform.DOScale(1f,screenTransitionTime);


            // Sequence mySequence = DOTween.Sequence();
            // mySequence.Append(transform.DOMoveX(45, 1))
            //     .Append(transform.DORotate(new Vector3(0,180,0), 1));

            currentScreen = newScreen;
        }
    }

    private void PlayButtonSound()
    {
        audioSource.PlayOneShot(clickSound);
    }

    // public void OverrideScreenSwitch(MenuScreen newScreen)
    // {
        
    //     playScreenGO.GetComponent<RectTransform>().DOAnchorPos(Vector2.zero,screenTransitionTime);
    // }
    public void ReturnButton()
    {
        if(screenHistory.Count > 1){
            SwitchToScreen(screenHistory[screenHistory.Count-2],false);
            PlayButtonSound();
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
        // GameSceneManager.Instance.LoadScene_LoadingScreen(selectedLevel.sceneIndex);
        GameSceneManager.LoadScene_LoadingScreen(selectedLevel.sceneIndex);
    } 
    public void QuitButton()
    {
        Debug.Log("Quitting game");
        Application.Quit();
    }

    // Used for the sliders on the Settings screen
    public void SetVolSliderMaster(float newVol)
    {
        AudioManager.Instance.SetVolMaster(newVol);
    }

    // Used for the sliders on the Settings screen
    public void SetVolSliderGameSFX(float newVol)
    {
        AudioManager.Instance.SetVolGameSFX(newVol);
    }

    // Used for the sliders on the Settings screen
    public void SetVolSliderUiSFX(float newVol)
    {
        AudioManager.Instance.SetVolUiSFX(newVol);
    }

    // Used for the sliders on the Settings screen
    public void SetVolSliderMusic(float newVol)
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
