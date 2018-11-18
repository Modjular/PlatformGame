using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//assign to button object and select that as your object in the on click thing
public class StartGameButton : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	//function you assign to the button list thing
	public void StartGame()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("AlexScene");
	}
}
