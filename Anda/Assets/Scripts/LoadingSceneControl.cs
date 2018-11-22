using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingSceneControl : MonoBehaviour {

    // Use this for initialization
    public GameObject loadingscreenObj;
    public Slider slider;

    AsyncOperation async;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator LoadingScreen()
    {
        loadingscreenObj.SetActive(true);
        async = SceneManager.LoadSceneAsync(1);
        async.allowSceneActivation = false;
        while (async.isDone == false)
        {
            slider.value = async.progress;
            if (async.progress == 0.9f)
            {
                slider.value = 1f;
                async.allowSceneActivation = true;
            }
            yield return null;
        }

    }

    public void LoadSceneMode()
    {
        StartCoroutine(LoadingScreen());
    }
}
