using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//assign to button object and select that as your object in the on click thing
public class StartGameButton : MonoBehaviour 
{
	public storeScene storeSceneScript;
	//function you assign to the button list thing
	void Start()
	{
		storeSceneScript = GameObject.Find("storeScene").GetComponent<storeScene>();
        DontDestroyOnLoad(GameObject.Find("storeScene"));
	}

	public void StartGame()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("TutorialScene");
	}
}
