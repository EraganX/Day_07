using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class SceneLoader : MonoBehaviour
{
    public GameObject loadingCanvasPrefab;
    private GameObject loadingCanvasInstance;
    private Slider progressBar;

    [SerializeField] private float minimumLoadingTime = 2f;

    private void Start()
    {
        if (loadingCanvasPrefab != null)
        {
            loadingCanvasInstance = Instantiate(loadingCanvasPrefab);
            loadingCanvasInstance.SetActive(false);

            progressBar = loadingCanvasInstance.GetComponentInChildren<Slider>();
        }
        else
        {
            Debug.LogError("Loading Canvas Prefab is not assigned.");
        }
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneAsync(sceneName));
    }

    private IEnumerator LoadSceneAsync(string sceneName)
    {
        if (loadingCanvasInstance != null)
        {
            loadingCanvasInstance.SetActive(true);
        }

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);
        asyncOperation.allowSceneActivation = false;

        float startTime = Time.time;

        while (!asyncOperation.isDone)
        {
            float progress = Mathf.Clamp01(asyncOperation.progress / 0.9f);
            if (progressBar != null)
            {
                progressBar.value = progress;
            }

            // If the loading is complete, allow the scene activation
            if (asyncOperation.progress >= 0.9f && Time.time - startTime >= minimumLoadingTime)
            {
                asyncOperation.allowSceneActivation = true;
            }

            yield return null;
        }

        if (loadingCanvasInstance != null)
        {
            loadingCanvasInstance.SetActive(false);
        }
    }
}
