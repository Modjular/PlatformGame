using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLivesCounter : MonoBehaviour 
{
	//initializing variables
	int playerLives;
	GameObject player;
	Text livesText;

	void Awake ()
	{
		//grabs variables from gameobject and componenets
		player = GameObject.Find("Player(Beginner)");
		Debug.Log("found player");
		livesText = GetComponent<Text>();
	}

	// Use this for initialization
	void Start () 
	{
		//creates live counter on start
		LivesUpdate();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void LivesUpdate()
	{
		playerLives = player.GetComponent<PlayerHealth>().lives;
		Debug.Log("lives updated");
		livesText.text = "Lives:" +playerLives;
	}
	
}
