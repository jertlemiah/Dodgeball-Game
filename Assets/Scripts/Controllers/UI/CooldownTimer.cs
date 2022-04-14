using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

[RequireComponent(typeof(CanvasGroup))]
public class CooldownTimer : MonoBehaviour
{
    public Slider slider;
    public TMP_Text timeRemainingText;
    public float timeRemaining;
    public float cooldownTime = 5;
    public float totalTime;
    bool runCooldown = false;
    CanvasGroup canvasGroup => GetComponent<CanvasGroup>();

    void Start()
    {
        if (!slider) {
            slider = GetComponentInChildren<Slider>();
        }
        if (!timeRemainingText) {
            timeRemainingText = GetComponentInChildren<TMP_Text>();
        }
        canvasGroup.alpha = 0;
        runCooldown = false;
    }

    void Update()
    {
        if (runCooldown) {
            totalTime += Time.deltaTime;
            if(totalTime >= cooldownTime){
                runCooldown = false;
                canvasGroup.alpha = 0;
            } else {
                timeRemainingText.text = (Mathf.CeilToInt(cooldownTime-totalTime)).ToString();
            }
            
        }
    }

    public void StartCooldown(float newCooldownTime)
    {
        if(newCooldownTime <= 0){
            return;
        }
        cooldownTime = newCooldownTime;
        slider.value = 1;
        slider.DOValue(0,newCooldownTime);
        timeRemainingText.text = newCooldownTime.ToString();
        totalTime = 0;
        runCooldown = true;
        canvasGroup.alpha = 1;
        
    }
}
