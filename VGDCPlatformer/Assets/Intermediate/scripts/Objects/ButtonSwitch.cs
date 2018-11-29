using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSwitch : ScriptableObject {

	public string doorName = "Door";
	public GameObject Door;
	public bool pressed = false;
	public Color selfColor = Color.red;
	public string selfName = "Button";
	public int number = 1;

	// Called when a new instance is created
	void OnEnable()
	{
		doorName += number.ToString();
		selfName += number.ToString();
		Door = GameObject.Find(doorName);
		number++;
	}
}
