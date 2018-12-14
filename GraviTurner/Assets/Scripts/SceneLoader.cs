using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    private bool loadNext;
    public string sceneToLoad;

	// Use this for initialization
	void Start () {
        StartCoroutine(SceneLoad());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Clicked()
    {
        loadNext = !loadNext;
    }

    IEnumerator SceneLoad()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneToLoad);
        asyncLoad.allowSceneActivation = false;
        //Debug.Log("Pro :" + asyncLoad.progress);
        while (!asyncLoad.isDone)
        {
			if (asyncLoad.progress >= 0.9f) {
				//Wait to you press the space key to activate the Scene
				if (loadNext) {
					//Activate the Scene
					asyncLoad.allowSceneActivation = true;
					Physics.gravity = new Vector3 (0, -9.81f, 0);
				}
			}
            yield return null;
        }
    }

    
}
