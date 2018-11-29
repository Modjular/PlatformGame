using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : ScriptableObject {

	public string buttonName = "Button";
	public GameObject Button;
	public bool open = false;
	public Color selfColor = Color.grey;
	public string selfName = "Door";
	public int number = 1;
	Rigidbody2D barrier;

	void Start()
	{
		barrier = Button.GetComponent<Rigidbody2D>();
	}

	//Called when a new instance is created
	void OnEnable()
	{
		barrier.bodyType = RigidbodyType2D.Static;
		buttonName += number.ToString();
		selfName += number.ToString();
		Button = GameObject.Find(buttonName);
		number++;
	}
}
