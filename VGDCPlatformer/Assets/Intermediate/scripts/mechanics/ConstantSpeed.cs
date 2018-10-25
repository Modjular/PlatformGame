using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantSpeed : MonoBehaviour {
    [Header("Platform Attributes")]
    public string state; //named states on where the platform should move
    public float movementTime;
    // Use this for initialization
    void Start ()
    {
        ChangeTarget();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (state == "Move2")
        {
            transform.Translate(0.1f, 0, 0);
        }
        if (state == "Move1")
        {
            transform.Translate(-0.1f, 0, 0);
        }
        transform.Rotate(0, 0, 0);
    }
    void ChangeTarget()
    {
        /*check states and move platform, then we change states to update
        postion of the moving platform */

        //state names are abritrary and can program more 
        //states and positions if needed
        if (state == "Move1")
        {
            state = "Move2";
        }
        else if (state == "Move2")
        {
            state = "Move1";
        }
        else if (state == "") //default position
        {
            state = "Move2";
        }
        Invoke("ChangeTarget", movementTime);
    }
}

