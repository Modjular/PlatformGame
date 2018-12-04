using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsButton : MonoBehaviour {
	public bool onCredits = false;
	public CanvasGroup cg;
	// Use this for initialization
	void Start () 
	{
		cg = GameObject.Find("Credits").GetComponent<CanvasGroup>();	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void credits()
	{
		if (onCredits == false)
		{
			Debug.Log("Credits shown");
			onCredits = true;
			cg.alpha = 1;
			cg.interactable = true;
		}
		else if (onCredits == true)
		{
			Debug.Log("Credits hidden");
			onCredits = false;
			cg.alpha = 0;
			cg.interactable = false;
		}
	}

}
