using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//DONT USE
public class ChangeMovingPlatformDirectionTrigger : MonoBehaviour 
{
    public BetterConstantSpeed script;

    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BetterMoving"))
        {
            script = collision.gameObject.GetComponent<BetterConstantSpeed>();
            Debug.Log("entered trigger");
            script.neg = -script.neg;
        }
    }
}