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
		Debug.Log(sceneName);
		UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
	}

}