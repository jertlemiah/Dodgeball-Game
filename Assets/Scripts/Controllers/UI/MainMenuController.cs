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
        RectTransform rt = titleScreenGO.GetComponent<RectTransform>();
        offscreenHorizontal = rt.rect.width * rt.localScale.x;
        offscreenVertical = rt.rect.height * rt.localScale.y;
        playScreenGO.GetComponent<RectTransform>().anchoredPosition = new Vector2(offscreenHorizontal,0);
        settingsScreenGO.GetComponent<RectTransform>().anchoredPosition = new Vector2(0,offscreenVertical);
    }

    // Update is called once per frame
    void Update()
    {
        
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
        titleScreenGO.GetComponent<RectTransform>().DOAnchorPos(new Vector2(-offscreenHorizontal,0),screenTransitionTime);
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
        playScreenGO.GetComponent<RectTransform>().DOAnchorPos(new Vector2(offscreenHorizontal,0),screenTransitionTime);
    }
    public void Title_SettingsButton()
    {
        titleScreenGO.GetComponent<RectTransform>().DOAnchorPos(new Vector2(0,-offscreenVertical),screenTransitionTime);
        settingsScreenGO.GetComponent<RectTransform>().DOAnchorPos(Vector2.zero,screenTransitionTime);
    }
    public void Settings_ReturnButton()
    {
        titleScreenGO.GetComponent<RectTransform>().DOAnchorPos(Vector2.zero,screenTransitionTime);
        settingsScreenGO.GetComponent<RectTransform>().DOAnchorPos(new Vector2(0,offscreenVertical),screenTransitionTime);
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
