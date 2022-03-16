using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using DG.Tweening;

public class LevelPanelController : MonoBehaviour,
    ISelectHandler, IDeselectHandler, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] public LevelDataSO levelData;
    [SerializeField] public  GameObject UiSelector, UiSelected, UiPressed;
    
    [SerializeField] public  Color colorDarkText, colorLightText;
    [SerializeField] public  bool hasText = false;
    [SerializeField] public TMP_Text tmpText;
    
    Vector2 textStartPosition = Vector2.zero;
    [SerializeField] float panelSelectedScale = 1.2f;
    [SerializeField] float scalingDuration = 1f;

    [SerializeField] public bool disableVisuals = false;

    //private MenuManager menuManager;

    private void Start()
    {
        if(hasText == true)
        {
            if (tmpText == null)
            {
                Debug.LogError("Button '" + this.name + "': TMP obj ref not given in editor");
            }
        }
        //menuManager = MenuManager.Instance;
    }
    public void LevelDetailsButton() 
    {
        MainMenuController.Instance.LoadLevelDetails(this);
    }

    // void SetAlpha

    void GrowSelectedPanel()
    {
        // tmpText.rectTransform.DOAnchorPos(textEndPosition,textShiftDuration,true);
        RectTransform panel = GetComponent<RectTransform>();
        if(panel != null)
            panel.DOScale(panelSelectedScale,scalingDuration);
    }
    void ShrinkSelectedPanel()
    {
        // tmpText.rectTransform.DOAnchorPos(textStartPosition,textShiftDuration,true);
        RectTransform panel = GetComponent<RectTransform>();
        if(panel != null)
            panel.DOScale(1,scalingDuration);
    }

    // private void OnDisable()
    // {
    //     UiSelected.SetActive(false);
    // }

    public void OnSelect(BaseEventData eventData)
    {
        GrowSelectedPanel();
        if(UiSelected != null && disableVisuals == false)
            UiSelected.SetActive(true);
    }

    public void OnDeselect(BaseEventData eventData)
    {
        ShrinkSelectedPanel();
        if (UiSelected != null && disableVisuals == false)
            UiSelected.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        GrowSelectedPanel();
        if (UiSelector != null && disableVisuals == false)
            UiSelector.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ShrinkSelectedPanel();
        if (UiSelector != null && disableVisuals == false)
            UiSelector.SetActive(false);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (UiPressed != null && disableVisuals == false)
        {
            UiPressed.SetActive(true);
            if (hasText == true)
            {
                tmpText.color = colorDarkText;
            }
        }       
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (UiPressed != null && disableVisuals == false)
        {
            UiPressed.SetActive(false);
            if (hasText == true)
            {
                tmpText.color = colorLightText;
            }
        }      
    }
}
