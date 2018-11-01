using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowingPlatform : MonoBehaviour 
{
    BoxCollider2D box;
    public float maxWidth;
    public float maxHeight;
    public float minWidth;
    public float minHeight;
    public float increment;
    Vector2 boxMaxSize;
    Vector2 boxMinSize;
    public float t;
    public bool increasing = false;
	// Use this for initialization
	void Start () 
    {
        t = 0f;
		box = GetComponent<BoxCollider2D>();
        boxMaxSize = new Vector3(maxWidth,maxHeight, 1);
        boxMinSize = new Vector3(minWidth,minHeight, 1);
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        transform.localScale = Vector3.Lerp(boxMinSize, boxMaxSize, t);
        if (increasing == true)
        {
            t = t + 1/increment;
        }

        if (increasing == false)
        {
            t = t - 1/increment;
        }

        if (t >= 1)
        {
            increasing = false;
        }

        if (t <= -0.25)
        {
            increasing = true;
        }
	}
}