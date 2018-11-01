using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// In order to use this, you'll need to attach this and a BoxCollider2D Component

public class DeathBox : MonoBehaviour {
	public void OnCollisionEnter2D(Collision2D collision)
    {
        // If the player lands in the death box, kill the player. To death
        if (collision.gameObject.CompareTag("Player"))
        { 
			// Kill the player by setting health to 0
            Debug.Log("You were killed. To death.");
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(100000);
        }
    }
}
