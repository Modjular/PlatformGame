using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : ScriptableObject {

	public GameObject Switch = GameObject.find.("Switch");
	public Boolean open = false;
	public Color selfColor = Color.Brown;
	public string Name = "Door";
}
