using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour {

    // Use this for initialization

    public GameObject parent;
    public int direction = -1;
    private Rigidbody2D shotBody;


    // Creates the shootThing and decides which direction it will go, then makes it move
	void Start () {
        shotBody = GetComponent<Rigidbody2D>();
        shotBody.velocity = new Vector2(7 * direction, 0);
        //shotBody.transform.position = new Vector2(Snail.transform.position.x, Snail.transform.position.y);
        //shotBody.transform.rotation = new Quaternion(0,1,1,1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Destroys the shootThing when it runs into a rigidbody
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Enemy" && collision.gameObject.tag != "hitbox" && collision.gameObject.tag != "hurtbox")
        {
            
            Destroy(gameObject);
        }
        //Debug.Log("ONTRIGGERENTER2D, deleting this");
        //Destroy(gameObject);
    }
}
