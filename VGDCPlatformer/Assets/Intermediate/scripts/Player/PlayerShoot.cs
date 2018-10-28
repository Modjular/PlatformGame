using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

    // Use this for initialization

    public GameObject parent;
    private Rigidbody2D shotBody;


    // Creates the shootThing and decides which direction it will go, then makes it move
	void Start () {

        int direction = -1;
        shotBody.bodyType = RigidbodyType2D.Kinematic;

        GameObject Player = GameObject.Find("Player");
        CharacterController2D controller = Player.GetComponent<CharacterController2D>();
        if (controller.m_FacingRight)
            direction = 1;
        shotBody = GetComponent<Rigidbody2D>();
        shotBody.velocity = new Vector2(50 * direction, 0);


	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Destroys the shootThing when it runs into a rigidbody
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            Destroy(this);
            Destroy(parent);
        }
    }
}
