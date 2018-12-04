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

    public CharacterController2D scriptP;

    public Transform SpawnPoint;
    public GameObject parent;
    public PlayerLivesCounter LivesCounterScript;
    public storeScene storeSceneScript;
    //Use this for initialization
    void Start () {
		health = startHealth;
        GameManager.UpdateSpawn(SpawnPoint);
        gameObject.transform.position = GameManager.spawnPoint.position;

        //GameObject Player = GameObject.Find("Player");
        GameObject Player = transform.parent.gameObject;
        print(Player);
        CharacterController2D scriptP = GetComponent<CharacterController2D>();
        storeSceneScript = GameObject.Find("storeScene").GetComponent<storeScene>();
        Debug.Log(GameObject.Find("storeScene").transform.name);
        DontDestroyOnLoad(GameObject.Find("storeScene"));
        LivesCounterScript = GameObject.Find("LivesCounter").GetComponent<PlayerLivesCounter>();
        
    }
	
	
	//will occur when player interacts with Enemy object
	void OnTriggerEnter2D (Collider2D collide)
	{
        CharacterController2D scriptP = gameObject.GetComponent<CharacterController2D>();
        switch(collide.gameObject.tag){

            case "hurtbox":
            {
                if (!scriptP.m_NotPounced)
                {
                    //to kill enemy, we tell the enemy script
                    Destroy(collide.transform.parent.gameObject);
                    //TheEnemy script = collide.gameObject.GetComponentInParent<TheEnemy>();
                    //script.Die();
                }
            };break;
        //Checks if the object is the players hitbox and the player is not pouncing
            case "hitbox" :
            {
                if(scriptP.m_NotPounced)
                    health -=100; //player takes damage
            };break;//scriptP.m_NotPounced
            case "checkPoint":
             {
                SpawnPoint = collide.transform;
                GameManager.UpdateSpawn(collide.transform);
            };break;
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
                
                storeSceneScript.GetGameOver();

            }else{
                lives--;
                health = startHealth;
                transform.position = SpawnPoint.transform.position;
                LivesCounterScript.LivesUpdate();
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
