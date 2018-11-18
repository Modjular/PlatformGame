using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//note: you will need two siblings with stopbobbing script and triggers in order to create bobbing effect, also bobbing tag on platform
public class Bobbing : MonoBehaviour 
{
    //assign to object w/ rigid body
    Rigidbody2D rb;
    private bool onPlatform;
    void Start()
    {
        //grabs rigid body component from platform and assigns to variable
        rb = GetComponent<Rigidbody2D>();
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        //checks for if collider is a player and is standing on ground (note this counts for if they are standing on ground and runs into its side)
        if (collision.gameObject.CompareTag("Player") & collision.gameObject.GetComponent<CharacterController2D>().IsGrounded()) 
        {
            //makes player's and platform's rigidbody's velocity go in neg-y direction
            onPlatform = true;
            collision.collider.transform.SetParent(transform);
            collision.collider.attachedRigidbody.velocity = new Vector2(0, -2);
            rb.velocity = new Vector2(0, -2);
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        //check for player tag on collider and if they are actually on the platform (in case they exit from the side)
        if (collision.gameObject.CompareTag("Player") & onPlatform == true)
        {
            //moves platform back up
            onPlatform = false;
            collision.collider.transform.SetParent(null);
            collision.collider.attachedRigidbody.velocity = new Vector2(0, collision.collider.attachedRigidbody.velocity.y + 2) ;
            rb.velocity = new Vector2(0, 2);
        }
    }
}
