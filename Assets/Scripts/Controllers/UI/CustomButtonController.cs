using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using DG.Tweening;

public class CustomButtonController : MonoBehaviour,
    ISelectHandler, IDeselectHandler, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] public  GameObject UiSelector, UiSelected, UiPressed;
    
    [SerializeField] public  Color colorDarkText, colorLightText;
    [SerializeField] public  bool hasText = false;
    [SerializeField] public TMP_Text tmpText;
    
    Vector2 textStartPosition = Vector2.zero;
    [SerializeField] Vector2 textEndPosition = new Vector2(40,0);
    [SerializeField] float textShiftDuration = 1f;

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

    // void SetAlpha

    void ShiftSelectText()
    {
        tmpText.rectTransform.DOAnchorPos(textEndPosition,textShiftDuration,true);
    }
    void UnshiftSelectText()
    {
        tmpText.rectTransform.DOAnchorPos(textStartPosition,textShiftDuration,true);
    }

    // private void OnDisable()
    // {
    //     UiSelected.SetActive(false);
    // }

    public void OnSelect(BaseEventData eventData)
    {
        ShiftSelectText();
        if(UiSelected != null && disableVisuals == false)
            UiSelected.SetActive(true);
    }

    public void OnDeselect(BaseEventData eventData)
    {
        UnshiftSelectText();
        if (UiSelected != null && disableVisuals == false)
            UiSelected.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        ShiftSelectText();
        if (UiSelector != null && disableVisuals == false)
            UiSelector.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        UnshiftSelectText();
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
