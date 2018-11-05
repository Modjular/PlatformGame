using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//assign this to some trigger
public class ChangeMovingPlatformDirectionTrigger : MonoBehaviour 
{
    public GameObject x;
    public BetterConstantSpeed script;

    void Start()
    {
        script = x.GetComponent<BetterConstantSpeed>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BetterMoving"))
        {
            Debug.Log("entered trigger");
            script.neg = -script.neg;
        }
    }
}