using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverButton : MonoBehaviour 
{
	GameObject storeScene;
	public string sceneName;
	public void Start()
	{
		storeScene = GameObject.Find("storeScene");
		Debug.Log(storeScene);
		sceneName = storeScene.GetComponent<storeScene>().sceneName;
	}

	public void RestartGame()
	{
<<<<<<< HEAD
		Debug.Log(sceneName);
		UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
	}
=======
        SceneManager.LoadScene("AlexScene");
    }
>>>>>>> 4c319f46a237c2fee9eb0b085ca58cf474bbd248

}
