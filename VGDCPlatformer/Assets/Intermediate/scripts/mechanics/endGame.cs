using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endGame : MonoBehaviour {

	public GameObject blackImg;
	private FadeToBlack ftbScript;
	// Use this for initialization
	void Start () 
	{
		ftbScript = blackImg.GetComponent<FadeToBlack>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void OnTriggerEnter2D (Collider2D collision)
	{
		ftbScript.winGet = true; 
	}
}
