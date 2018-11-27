using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DivebombDestructable : MonoBehaviour 
{
    //assign to object w/ rigidbody and make a trigger slightly above the platform
    public float DestructThreshold;
    public bool Destroyed;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        //if player's velocity is greather than the threshold, allow platform to be destroyed
        if (collision.gameObject.tag == ("Player") & collision.GetComponent<Collider2D>().attachedRigidbody.velocity.y <= -DestructThreshold)
        {
            Destroyed = true;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Player") & Destroyed)
        {
            //if destroyed true, destroy on touch
            Debug.Log("Destroy");
            Destroy(gameObject, 0);
        }
    }
}
