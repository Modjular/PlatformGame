﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    [SerializeField] private float runSpeed;
    public Animator animator;
    float horizontalMove = 0f;
    bool jump = false;
    bool pounce = false;
    public CharacterController2D controller;
    public GameObject projectile;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("speed", Mathf.Abs(horizontalMove));
        if (Input.GetButtonDown("Fire1"))
        {
            jump = true;
        }
        if (Input.GetButton("Fire2")) 
        {
            pounce = true;
        }
        //if (Input.GetButtonDown("Fire3"))
        //{
        //    shoot(); 
        //}
    }

    //Instansiates the snowball to be shot
    //private void shoot()
    //{
    //    //Rigidbody snowball = (Rigidbody)Instantiate(snowball, Player.Transform.position.x);
    //    GameObject cube = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
    //    //GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
    //    //GameObject cube = new GameObject("snowball");
    //    //cube.AddComponent<Rigidbody>();
    //    //cube.transform.position = new Vector2(1, 2);
    //    //fast = cube.GetComponent<Rigidbody2D>();
    //    //fast.velocity = new Vector2(500, 0);
    //    cube.GetComponent<Rigidbody2D>().velocity = new Vector2(10, 0);
    //    //cube.GetComponent<Rigidbody2D>().AddForce(transform.forward * 30);
        
    //}

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, jump, pounce);
        jump = false;
        pounce = false;
    }

}
