using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// DONT USE; USE MOVINGPLATFORM INSTEAD
public class ConstantSpeed : MonoBehaviour {
    //assign to parent object w/ child platform
    [Header("Platform Attributes")]
    public string state; //named states on where the platform should move
    public float movementTime;
    public float xMoveSpeed = 0.05f;
    public float yMoveSpeed = 0.05f;
    void Start ()
    {
        ChangeTarget();
	}
	
	void Update ()
    {
        //states affect what direction platform moves
        if (state == "Move2")
        {
            transform.Translate(xMoveSpeed, yMoveSpeed, 0);
        }
        if (state == "Move1")
        {
            transform.Translate(-xMoveSpeed, -yMoveSpeed, 0);
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
