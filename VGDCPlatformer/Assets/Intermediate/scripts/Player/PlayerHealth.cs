using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

	// Tony's test change
	public int startHealth = 1; //the amount of health the player is suppose to start with
	public int health; //the amount of health the player has, at 0 player dies
    public int lives = 3; //Later this should reference a global
                          //public float playerSpawnX = -17.3f; //where the player spawns at start or death, X coord
                          //public float playerSpawnY = -1.9f; //where the player spawns at start or death, Y coord

    public CharacterController2D script;

    public Transform SpawnPoint;
    public GameObject parent;


    //Use this for initialization
    void Start () {
		health = startHealth;
        GameManager.UpdateSpawn(SpawnPoint);
        gameObject.transform.position = GameManager.spawnPoint.position;

        //GameObject Player = GameObject.Find("Player");
        GameObject Player = transform.parent.gameObject;
        print(Player);
        CharacterController2D script = GetComponent<CharacterController2D>();
        

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
        //Checks if the object is the players hitbox and the player is not pouncing

		if (collide.gameObject.tag == "hitbox" && script.m_NotPounced)
		{
            health -=100; //player takes damage
		}

        if(collide.gameObject.tag == "checkPoint")
        {
            SpawnPoint = collide.transform;
            GameManager.UpdateSpawn(collide.transform);
        }
	}

	// Update is called once per frame
	void Update () {

        //print("Player is pounced" + script.m_NotPounced);
		//player dies here
		if (health <= 0)
		{
            if(lives == 0){
                //restarts level
                Debug.Log("OUT OF LIVES! --- GAME OVER ---\n RESTARTING...");
                SceneManager.LoadScene("AlexScene");
            }else{
                lives--;
                health = startHealth;
                transform.position = SpawnPoint.transform.position;
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
