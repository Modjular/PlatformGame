using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bobbing : MonoBehaviour {

   
    public void OnCollisionEnter2D(Collision2D collision)
    {
        //set the player as a child to the platform gaemObject
        //this allows movement of the player with moving platforms
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.collider.transform.SetParent(transform);
            transform.Translate(0, -1f, 0);
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        //removes the player from being a child of this platform gameObject
        //once player is not on the platform.
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.collider.transform.SetParent(null);
            transform.Translate(0, 1f, 0);
        }
    }
}
