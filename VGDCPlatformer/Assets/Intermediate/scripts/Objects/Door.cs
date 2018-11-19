using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : ScriptableObject {

	public string buttonName = "Button"
	public GameObject Button;
	public Boolean open = false;
	public Color selfColor = Color.Grey;
	public string selfName = "Door";
	public int number = 1;


	//Called when a new instance is created
	OnEnable
	{
		private Rigidbody2D barrier;
		barrier.bodyType = RigidbodyType2D.Static;

		buttonName += (string)number;
		selfName += (string)number;
		Button = GameObject.find.(buttonName);
		number++;
	}
}
