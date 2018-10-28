using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

    // Use this for initialization

    public GameObject shot;
    public Rigidbody2D shotBody;



	void Start () {

        int direction = -1;

        Instantiate(shot);
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
}
