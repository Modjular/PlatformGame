using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : ScriptableObject {

	public string buttonName = "Button"
	public GameObject Button;
	public Boolean open = false;
	public Color selfColor = Color.Grey;
	public string Name = "Door";
	public int number = 1;


	//Called when a new instance is created
	void OnEnable
	{

		private Rigidbody2D barrier;
		barrier.bodyType = RigidbodyType2D.Static;

		buttonName += number;
		Button = GameObject.find.(buttonName);
		number++;

	}
}
