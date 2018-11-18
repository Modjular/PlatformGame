using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : ScriptableObject {

	public GameObject Door = GameObject.find.("Door");
	public Boolean pressed = false;
	public Color selfColor = Color.Red;
	public string Name = "Switch";
}
