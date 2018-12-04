using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeToBlack : MonoBehaviour 
{
	private CanvasGroup canvasGroupBlack;
	private CanvasGroup textCanvasGroup;
	private CanvasGroup creditsCGroup;
	private CanvasGroup replayCG;
	public Image BlackImg;
	[HideInInspector]
	public bool winGet;

	// Use this for initialization
	void Start () 
	{
		textCanvasGroup = GameObject.Find("WinText").GetComponent<CanvasGroup>();
		canvasGroupBlack = BlackImg.GetComponent<CanvasGroup>();
		replayCG = GameObject.Find("RestartButton").GetComponent<CanvasGroup>();

	}
	
	// Update is called once per frame
	void Update () {
		if (winGet == true)
		{
			if (canvasGroupBlack.alpha < 1f)
			{
				canvasGroupBlack.alpha += .01f;
			}
			if (canvasGroupBlack.alpha >= 1f && textCanvasGroup.alpha < 1f)
			{
				textCanvasGroup.alpha += .01f;
			}
			if (textCanvasGroup.alpha >= 1f && replayCG.alpha < 1f)
			{
				replayCG.interactable = true;
				replayCG.alpha += .01f;
			}
		}
	}
}
