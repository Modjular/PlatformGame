using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//DONT USE: USE MOVINGPLATFORM INSTEAD
public class BetterConstantSpeed : MonoBehaviour 
{
    Rigidbody2D rb;
    public float xMoveSpeed;
    public float yMoveSpeed;
    public int neg = 1;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //transform.Translate(neg * xMoveSpeed, neg * yMoveSpeed,0);
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(neg * xMoveSpeed, neg * yMoveSpeed);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        collision.collider.transform.SetParent(transform);
        collision.collider.attachedRigidbody.velocity = new Vector2(neg * xMoveSpeed, neg * yMoveSpeed);
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        collision.collider.transform.SetParent(transform);
        collision.collider.attachedRigidbody.velocity = new Vector2(neg * xMoveSpeed, neg * yMoveSpeed);
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
