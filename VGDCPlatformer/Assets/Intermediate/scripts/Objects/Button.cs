using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : ScriptableObject {

	public string doorName = "Door";
	public GameObject Door;
	public Boolean pressed = false;
	public Color selfColor = Color.Red;
	public string selfName = "Button";
	public int number = 1;

	// Called when a new instance is created
	OnEnable
	{
		doorName += (string)number;
		selfName += (string)number;
		Door = GameObject.find.(doorName);
		number++;
	}
}
