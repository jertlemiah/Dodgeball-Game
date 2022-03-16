using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

/// <summary> This enum records the build index for all our scenes. Currently we have {MANAGER = 0, TITLE_SCREEN = 1, LEVEL_GYM = 2, LEVEL_TEST = 3}. </summary>
public enum SceneIndex {MANAGER = 0, TITLE_SCREEN = 1, LEVEL_GYM = 2, LEVEL_TEST = 3}

/// <summary> This custom singleton is responsible for loading and unloading different scenes in the game. 
///           Use GameSceneManager.Instance.LoadScene(SceneIndex.SceneName) to load a scene.</summary>
public class GameSceneManager : Singleton<GameSceneManager>
{
    // [SerializeField] public static GameObject gameSceneManagerPrefab;
    // [SerializeField] GameObject loadingScreenGO;
    // [SerializeField] Slider loadingBar;
    // [SerializeField] float tweenTime = 1f;
    [SerializeField] float minLoadingTime = 1f;
    public int numberOfScenes;
    List<AsyncOperation> scenesLoading = new List<AsyncOperation>();
    [SerializeField] string activeSceneName = "None";
    public float totalLoadingProgress = 0f;
    // private static GameSceneManager _instance;
    // public static GameSceneManager Instance
    // {
    //     get 
    //     {
    //         if(_instance == null)
    //         {
    //             bool isManagerOpen = false;
    //             for(int i = 0; i < SceneManager.sceneCount; i++) {
    //                 if(SceneManager.GetSceneAt(i).buildIndex == (int)SceneIndex.MANAGER) {
    //                     isManagerOpen = true;
    //                 }
    //             }
    //             if(!isManagerOpen) {
    //                 Debug.Log("Persistent Scene is not open, opening it now.");
    //                 SceneManager.LoadScene((int)SceneIndex.MANAGER, LoadSceneMode.Additive);
    //                 // Instantiate(gameSceneManagerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
    //                 // _instance = gameSceneManagerPrefab.GetComponent<GameSceneManager>();
    //                 // GameSceneManager trash = GameSceneManager.Instance;
    //             } else{
    //                 _instance = (GameSceneManager) FindObjectOfType(typeof(GameSceneManager));
    //             }
                
    //             if (_instance == null) {
    //                 Debug.Log("GameSceneManager is a special singleton that must come from the persistent scene. Make sure to load that scene before making a call to this. ");
    //             }
    //         }
            
    //         return _instance;
    //     }
    // }
    void Awake()
    {
        // This is used for when only the persistent scene is open
        if(SceneManager.sceneCount == 1 && SceneManager.GetActiveScene().buildIndex == (int)SceneIndex.MANAGER) {
            SceneManager.LoadSceneAsync((int)SceneIndex.TITLE_SCREEN, LoadSceneMode.Additive);
            EventManagerSO.TriggerEvent_HideHUD();
        }     
        activeSceneName = SceneManager.GetActiveScene().name;
    }

    /// <summary> To load a scene, simply use the correct SceneIndex {MANAGER = 0, TITLE_SCREEN = 1, LEVEL_GYM = 2, LEVEL_TEST = 3}.
    ///     All non-persistent scenes will be unloaded and the loading screen will appear to show loading progress. </summary>
    /// <param name="sceneIndex">The SceneIndex will be used as a build index to load the selected scene. 
    ///     Current values: {MANAGER = 0, TITLE_SCREEN = 1, LEVEL_GYM = 2, LEVEL_TEST = 3}</param>
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
