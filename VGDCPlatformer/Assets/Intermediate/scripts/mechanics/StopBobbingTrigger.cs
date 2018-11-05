using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//assign this to some trigger
public class StopBobbingTrigger : MonoBehaviour 
{

    void Start()
    {
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bobbing"))
        {
            Debug.Log("entered trigger");
            collision.GetComponent<Collider2D>().attachedRigidbody.velocity = new Vector2(0, 0);
        }
    }
}