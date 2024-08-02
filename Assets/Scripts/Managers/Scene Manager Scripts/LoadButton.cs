using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Example for triggering the loading
public class LoadButton : MonoBehaviour
{
    public SceneLoader sceneLoader;
    public string sceneName;

    public void OnButtonPress()
    {
        if (sceneLoader != null)
        {
            sceneLoader.LoadScene(sceneName);
        }
    }
}

