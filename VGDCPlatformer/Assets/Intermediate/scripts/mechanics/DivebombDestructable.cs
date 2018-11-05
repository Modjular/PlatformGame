using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DivebombDestructable : MonoBehaviour 
{
    //assign to object w/ rigidbody
    public float DestructThreshold;
    public bool Destroyed;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Player") & collision.GetComponent<Collider2D>().attachedRigidbody.velocity.y <= -DestructThreshold)
        {
            Destroyed = true;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Player") & Destroyed)
        {
            Debug.Log("Destroy");
            Destroy(gameObject, 0);
        }
    }
}
