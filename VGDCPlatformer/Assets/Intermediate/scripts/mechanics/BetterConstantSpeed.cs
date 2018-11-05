using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//note: you will need two siblings with changeplatformdirection script and triggers in order to make this work
public class BetterConstantSpeed : MonoBehaviour 
{
    Rigidbody2D rb;
    public float xMoveSpeed;
    public float yMoveSpeed;
    public int neg = 1;
    void Start()
    {
    }

    void Update()
    {
        transform.Translate(neg * xMoveSpeed, neg * yMoveSpeed,0);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        collision.collider.transform.SetParent(transform);
    }


    public void OnCollisionExit2D(Collision2D collision)
    {
        //check for player tag on collider and if they are actually on the platform (in case they exit from the side)
        if (collision.gameObject.CompareTag("Player"))
        {
            //moves platform back up
            collision.collider.transform.SetParent(null);
        }
    }
}
