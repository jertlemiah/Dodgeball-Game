using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class HealthbarController : MonoBehaviour
{
    public Slider healthbarSlider;
    public TMP_Text tmpText;
    public float maxHealth = 4f;
    public float currentHealth = 4f;
    [SerializeField] float tweenTime = 0.5f;
    [SerializeField] Color healthbarColor = new Color32(0xFF, 0x8D, 0x00, 0xFF); // RGBA, #FF8D00;
    [SerializeField] Color healthbarBackgroundColor = new Color32(0xCB, 0xCB, 0xCB, 0xFF); // CBCBCB
    [SerializeField] Color powerupHealthColor = new Color32(0xCB, 0xCB, 0xCB, 0xFF); // CBCBCB
    
    public void SetMaxHealth(float newMaxHealth) {
        maxHealth = newMaxHealth;
        UpdateVisuals();
    }

    public void SetHealth(float newHealth)
    {
        currentHealth = newHealth;
        UpdateVisuals();
    }

    private void UpdateVisuals()
    {
        if (healthbarSlider)
            healthbarSlider.DOValue(currentHealth/maxHealth,tweenTime);
        if (tmpText)
            tmpText.text = (int)currentHealth+"/"+(int)maxHealth;
    }
}
