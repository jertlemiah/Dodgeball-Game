using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public enum SceneIndex {MANAGER = 0, TITLE_SCREEN = 1, LEVEL_GYM = 2}
public class GameSceneManager : Singleton<GameSceneManager>
{
    [SerializeField] GameObject loadingScreenGO;
    [SerializeField] Slider loadingBar;
    [SerializeField] float tweenTime = 1f;
    [SerializeField] float minLoadingTime = 1f;
    public int numberOfScenes;
    List<AsyncOperation> scenesLoading = new List<AsyncOperation>();
    public float totalLoadingProgress = 0f;
    public float timeScale = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadScene(SceneIndex sceneIndex)
    {
        loadingScreenGO.SetActive(true);
        DOTween.KillAll();
        Time.timeScale = 1;
        // Time.timeScale = 0;
        
        for(int i = 0; i < SceneManager.sceneCount; i++)
        {
            Scene scene = SceneManager.GetSceneAt(i);
            if(scene == SceneManager.GetSceneByBuildIndex((int)SceneIndex.MANAGER) || scene.name == "DontDestroyOnLoad"){
                continue;
            }
            scenesLoading.Add(SceneManager.UnloadSceneAsync(scene.buildIndex));
        }
        scenesLoading.Add(SceneManager.LoadSceneAsync((int)sceneIndex, LoadSceneMode.Additive));

        StartCoroutine(GetSceneLoadProgress(sceneIndex));
    }
    
    public IEnumerator GetSceneLoadProgress(SceneIndex sceneIndex)
    {
        loadingBar.value = 0;
        for(int i=0; i<scenesLoading.Count; i++)
        {
            numberOfScenes = SceneManager.sceneCount;
            float startTime = Time.time;
            while (!scenesLoading[i].isDone)
            {
                totalLoadingProgress = 0f;
                timeScale = Time.timeScale;

                foreach(AsyncOperation operation in scenesLoading)
                {
                    totalLoadingProgress += operation.progress;
                    
                }
                Debug.Log("totalLoadingProgress: "+totalLoadingProgress);
                totalLoadingProgress = (float)(totalLoadingProgress / (float)scenesLoading.Count);
                loadingBar.DOValue(totalLoadingProgress,tweenTime-(Time.time - startTime));

                yield return null;
            }
            totalLoadingProgress = (float)((i+1) / (float)scenesLoading.Count);
            loadingBar.DOValue(totalLoadingProgress,tweenTime-(Time.time - startTime));

            Debug.Log("Loading progress: "+(totalLoadingProgress*100).ToString());
            if ((Time.time - startTime) < minLoadingTime)
            {
                Debug.Log("going to wait for "+(minLoadingTime-(Time.time - startTime)));
                yield return new WaitForSeconds(minLoadingTime-(Time.time - startTime) );
            }
        }
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex((int)sceneIndex));
        Debug.Log("active scene: "+SceneManager.GetActiveScene().name);

        loadingScreenGO.SetActive(false);
        EventManagerSO.TriggerEvent_FinishedLoading();
        // EventManagerSO.TriggerEvent_PauseGame();
        // Time.timeScale = 1;
    }
}
