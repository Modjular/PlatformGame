using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : ScriptableObject {

	public string doorName = "Door";
	public GameObject Door;
	public Boolean pressed = false;
	public Color selfColor = Color.Red;
	public string Name = "Switch";
	public int number = 1;

	// Called when a new instance is created
	public void OnEnable
	{

		doorName += number;
		Door = GameObject.find.(doorName);
		number++;

	}
}
