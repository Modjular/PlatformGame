using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverButton : MonoBehaviour 
{
	public PlayerHealth healthScript;
	public void RestartGame()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene(healthScript.lastScene.name);
	}

}
