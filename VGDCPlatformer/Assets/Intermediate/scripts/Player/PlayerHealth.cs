using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerHealth : MonoBehaviour {

	// Tony's test change
	public int startHealth = 1; //the amount of health the player is suppose to start with
	public int health; //the amount of health the player has, at 0 player dies
	public int m_lives;
	public Text lives_Text;
	//public float playerSpawnX = -17.3f; //where the player spawns at start or death, X coord
	//public float playerSpawnY = -1.9f; //where the player spawns at start or death, Y coord

    public Transform SpawnPoint;
    
	//Use this for initialization
	void Start () {
		health = startHealth;
		m_lives = GameManager.startLives; // We can change this to a GLOBAL variable later
        GameManager.UpdateSpawn(SpawnPoint);
        gameObject.transform.position = GameManager.spawnPoint.position;

		lives_Text.text = "Lives: " + m_lives;
	}
	
	
	//will occur when player interacts with Enemy object
	void OnTriggerEnter2D (Collider2D collide)
	{
		if (collide.gameObject.tag == "hurtbox")
		{
			//to kill enemy, we tell the enemy script
			TheEnemy script = collide.gameObject.GetComponentInParent<TheEnemy>();
			script.Die();
		}

		if (collide.gameObject.tag == "hitbox")
		{
			health--; //player takes damage
		}

        if(collide.gameObject.tag == "checkPoint")
        {
            /*
                What happens if you go backwards
                and hit a previous checkpoint?
             */
             
			Debug.Log("Hit a checkpoint!");
            SpawnPoint = collide.transform;
            GameManager.UpdateSpawn(collide.transform);
        }
	}

	// Update is called once per frame
	void Update () {
		//player dies here
		if (health <= 0)
		{
			if(m_lives > 1){

				// If we have lives left, decrement, and go to checkpoint
				m_lives--;
				health = startHealth;
				lives_Text.text = "Lives: " + m_lives;


				// Later on we want to clear any status-effects or power-ups
				// before we respawn the player at the closest checkpoint
				transform.position = SpawnPoint.position;

			}else{
            	//restarts level
            	SceneManager.LoadScene("SampleScene");
			}
            
		}
	}

	public void TakeDamage(){
		health--;
	}

	public void TakeDamage(int amt){
		health -= amt;
	}

}
