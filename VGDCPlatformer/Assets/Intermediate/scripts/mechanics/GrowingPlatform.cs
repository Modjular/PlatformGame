using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowingPlatform : MonoBehaviour 
{
    // pre variable stuff (i dont know what the technical term is)
    BoxCollider2D box;
    public float maxWidth;
    public float maxHeight;
    public float minWidth;
    public float minHeight;
    // bigger increments = slower growth
    public float increment;

    Vector2 boxMaxSize;
    Vector2 boxMinSize;
    //had this public for debugging purposes
    public float t;
    public bool increasing = false;
    // bigger number = increases how long platform stays gone
    public float goneDuration = 0.25f;

	void Start () 
    {
        //variable stuff
        t = 0f;
		box = GetComponent<BoxCollider2D>();
        boxMaxSize = new Vector3(maxWidth,maxHeight, 1);
        boxMinSize = new Vector3(minWidth,minHeight, 1);
	}

	void Update ()
    {
        // platform grows towards max as t goes towards 1 and shrinks as t goes towards 0 (and lower)
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

        if (t <= -goneDuration)
        {
            increasing = true;
        }
	}
}