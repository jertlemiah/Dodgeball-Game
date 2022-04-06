using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class LoadingManager : Singleton<LoadingManager>
{
    [SerializeField] float minLoadingTime = 1f;
    public int numberOfScenes;
    List<AsyncOperation> scenesLoading = new List<AsyncOperation>();
    [SerializeField] string activeSceneName = "None";
    public float totalLoadingProgress = 0f;
    
    new void Awake()
    {
        base.Awake();
        activeSceneName = SceneManager.GetActiveScene().name;
    }

    public void LoadScene_LoadingScreen(SceneIndex sceneIndex)
    {  
        // loadingScreenGO.SetActive(true);
        DOTween.KillAll();  // This prevents any null references from attempting to tween a deleted object. Technically DOTween will catch these, but this is better practice
        Time.timeScale = 1; // This is in case you leave a paused scene, as timeScale affects ALL scenes
        
        for(int i = 0; i < SceneManager.sceneCount; i++)
        {
            Scene scene = SceneManager.GetSceneAt(i);
            if(scene == SceneManager.GetSceneByBuildIndex((int)SceneIndex.MANAGER) || scene.name == "DontDestroyOnLoad"){
                continue;
            }
            scenesLoading.Add(SceneManager.UnloadSceneAsync(scene.buildIndex));
        }
        scenesLoading.Add(SceneManager.LoadSceneAsync((int)sceneIndex, LoadSceneMode.Additive));
        if(sceneIndex == SceneIndex.TITLE_SCREEN){
            EventManagerSO.TriggerEvent_HideHUD();
        }
        // AudioManager.Instance.PlayLoadingMusic();
        StartCoroutine(GetSceneLoadProgress(sceneIndex));
    }
    
    /// <summary> GetSceneLoadProgress monitors the progress of unloading the previous scenes and loading the new scene.</summary>
    /// <param name="sceneIndex">The SceneIndex will be used as a build index to load the selected scene. 
    ///     Current values: {MANAGER = 0, TITLE_SCREEN = 1, LEVEL_GYM = 2, LEVEL_TEST = 3}</param>
    private IEnumerator GetSceneLoadProgress(SceneIndex sceneIndex)
    {
        // loadingBar.value = 0;
        EventManagerSO.TriggerEvent_LoadingProgress(0);
        for(int i=0; i<scenesLoading.Count; i++)
        {
            numberOfScenes = SceneManager.sceneCount;
            float startTime = Time.time;
            while (!scenesLoading[i].isDone)
            {
                totalLoadingProgress = 0f;

                foreach(AsyncOperation operation in scenesLoading)
                {
                    totalLoadingProgress += operation.progress;
                    
                }
                Debug.Log("totalLoadingProgress: "+totalLoadingProgress);
                totalLoadingProgress = (float)(totalLoadingProgress / (float)scenesLoading.Count);
                // loadingBar.DOValue(totalLoadingProgress,tweenTime-(Time.time - startTime));
                EventManagerSO.TriggerEvent_LoadingProgress(totalLoadingProgress);

                yield return null;
            }
            totalLoadingProgress = (float)((i+1) / (float)scenesLoading.Count);
            // loadingBar.DOValue(totalLoadingProgress,tweenTime-(Time.time - startTime));
            EventManagerSO.TriggerEvent_LoadingProgress(totalLoadingProgress);

            Debug.Log("Loading progress: "+(totalLoadingProgress*100).ToString());
            float waitTime = (float)minLoadingTime/scenesLoading.Count;
            if ((Time.time - startTime) < waitTime)
            {
                Debug.Log("going to wait for "+(waitTime-(Time.time - startTime)));
                yield return new WaitForSeconds(waitTime-(Time.time - startTime) );
            }
        }
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex((int)sceneIndex));
        Debug.Log("Setting active scene to "+SceneManager.GetActiveScene().name);
        activeSceneName = SceneManager.GetActiveScene().name;

        // loadingScreenGO.SetActive(false);
        EventManagerSO.TriggerEvent_FinishedLoading();
    }
}
