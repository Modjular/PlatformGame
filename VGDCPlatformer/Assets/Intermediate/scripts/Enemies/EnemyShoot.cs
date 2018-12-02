using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour {

    // Use this for initialization

    public GameObject parent;
    private Rigidbody2D shotBody;


    // Creates the shootThing and decides which direction it will go, then makes it move
	void Start () {
        
        int direction = -1;
        //shotBody.bodyType = RigidbodyType2D.Kinematic;
        GameObject Snail = GameObject.Find("Enemy");
        TheEnemy controller = Snail.GetComponent<TheEnemy>();
        direction = (int)Snail.transform.localScale.x;
        shotBody = GetComponent<Rigidbody2D>();
        shotBody.velocity = new Vector2(20 * direction, 0);
        shotBody.transform.position = new Vector2(Snail.transform.position.x, Snail.transform.position.y);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Destroys the shootThing when it runs into a rigidbody
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Enemy")
        {
            Destroy(this);
            Destroy(parent);
            //Debug.Log("This code is being ran");
        }
    }
}
