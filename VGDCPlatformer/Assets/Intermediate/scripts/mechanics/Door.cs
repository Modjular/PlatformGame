using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : ScriptableObject {

	public GameObject Switch = GameObject.find.("Switch");
	public Boolean open = false;
	public Color selfColor = Color.Grey;
	public string Name = "Door";


	void OnEnable
	{
		private Rigidbody2D barrier;
		barrier.bodyType = RigidbodyType2D.Static;
	}
}
