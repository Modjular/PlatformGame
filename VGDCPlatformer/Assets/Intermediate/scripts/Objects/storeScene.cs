using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// stores the last scene that the player was on before they die (assign to an empty gameobject)
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
