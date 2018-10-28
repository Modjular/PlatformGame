using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowingPlatform : MonoBehaviour 
{
    BoxCollider2D box;
    public float width;
    public float height;
    public boxMaxSize = new Vector2 (width, height);
	// Use this for initialization
	void Start () 
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        box.size = Vector2.Lerp((0,0), boxMaxSize);
	}
}