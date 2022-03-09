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
    List<AsyncOperation> scenesLoading = new List<AsyncOperation>();
    public float totalLoadingProgress = 0f;
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
        
        for(int i = 0; i < SceneManager.sceneCount; i++)
        {
            Scene scene = SceneManager.GetSceneAt(i);
            if(scene == SceneManager.GetSceneByBuildIndex((int)SceneIndex.MANAGER)){
                continue;
            }
            scenesLoading.Add(SceneManager.UnloadSceneAsync(scene.buildIndex));
        }
        scenesLoading.Add(SceneManager.LoadSceneAsync((int)sceneIndex, LoadSceneMode.Additive));

        StartCoroutine(GetSceneLoadProgress());
    }
    
    public IEnumerator GetSceneLoadProgress()
    {
        loadingBar.value = 0;
        for(int i=0; i<scenesLoading.Count; i++)
        {
            float startTime = Time.time;
            while (!scenesLoading[i].isDone)
            {
                totalLoadingProgress = 0f;

                foreach(AsyncOperation operation in scenesLoading)
                {
                    totalLoadingProgress += operation.progress;
                }
                totalLoadingProgress = (float)(totalLoadingProgress / (float)scenesLoading.Count);
                loadingBar.DOValue(totalLoadingProgress,tweenTime-(Time.time - startTime));

                yield return null;
            }
            totalLoadingProgress = (float)((i+1) / (float)scenesLoading.Count);
            loadingBar.DOValue(totalLoadingProgress,tweenTime-(Time.time - startTime));

            Debug.Log("Loading progress: "+(totalLoadingProgress*100).ToString());
            if ((Time.time - startTime) < minLoadingTime)
            {
                yield return new WaitForSeconds(minLoadingTime-(Time.time - startTime) );
            }
        }

        loadingScreenGO.SetActive(false);
    }
}
