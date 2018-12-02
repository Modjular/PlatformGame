using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class storeScene : MonoBehaviour 
{
	public Scene scene;
	public string sceneName;
	public void GetGameOver()
	{
		scene = SceneManager.GetActiveScene();
		sceneName = scene.name;
		Debug.Log(sceneName);
		SceneManager.LoadScene("GameOverScene");
	}
}
