using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bobbing : MonoBehaviour 
{
    Rigidbody2D rb;
    private bool onPlatform;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") & collision.gameObject.GetComponent<CharacterController2D>().IsGrounded()) 
        {
            onPlatform = true;
            collision.collider.transform.SetParent(transform);
            collision.collider.attachedRigidbody.velocity = new Vector2(0, -2);
            rb.velocity = new Vector2(0, -2);
        }
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.collider.transform.SetParent(transform);
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") & onPlatform == true)
        {
            onPlatform = false;
            collision.collider.transform.SetParent(null);
            rb.velocity = new Vector2(0, 2);
        }
    }
}
