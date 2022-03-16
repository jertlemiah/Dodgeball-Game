using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class LoadingScreenController : MonoBehaviour
{
    [SerializeField] GameObject loadingVisualsGO;
    [SerializeField] Slider loadingBar;
    [SerializeField] float tweenTime = 1f;
    [SerializeField] float minLoadingTime = 1f;
    
    void Awake()
    {
        EventManagerSO.E_LoadingProgress += UpdateLoadingBar;
        EventManagerSO.E_FinishedLoading += TurnOffLoadingScreen;
    }

    void OnDisable()
    {
        EventManagerSO.E_LoadingProgress -= UpdateLoadingBar;
        EventManagerSO.E_FinishedLoading -= TurnOffLoadingScreen;
    }

    void UpdateLoadingBar(float progress)
    {
        if(!loadingVisualsGO.activeSelf){
            loadingBar.value = 0;
            loadingVisualsGO.SetActive(true);
        }
        loadingBar.DOValue(progress,tweenTime);
    }

    void TurnOffLoadingScreen()
    {
        loadingVisualsGO.SetActive(false);
    }
}
