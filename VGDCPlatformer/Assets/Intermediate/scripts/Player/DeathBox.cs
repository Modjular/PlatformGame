using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBox : MonoBehaviour {
	public void OnCollisionEnter2D(Collision2D collision)
    {
		Debug.Log("DEATH BOX HAS BEEN ENTERED");
        // If the player lands in the death box, kill the player. To death
        if (collision.gameObject.CompareTag("Player"))
        { 
			Debug.Log("Twas the player");
			// Kill the player by setting health to 0
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(100000);
        }
    }
}
