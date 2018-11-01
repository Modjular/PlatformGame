using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    [SerializeField] private float runSpeed;
    float horizontalMove = 0f;
    bool jump = false;
    bool pounce = false;
    public CharacterController2D controller;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        if (Input.GetButtonDown("Fire1"))
        {
            jump = true;
        }
        if (Input.GetButton("Fire2")) 
        {
            pounce = true;
        }
        if (Input.GetButtonDown("Fire3"))
        {
            shoot(); 
        }
    }

    //Instansiates the snowball to be shot
    private void shoot()
    {
        //Rigidbody snowball = (Rigidbody)Instantiate(snowball, Player.Transform.position.x);

        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.AddComponent<Rigidbody>();
        //cube.transform.position = new Vector2(1, 2);
        cube.GetComponent<Rigidbody2D>().velocity = new Vector2(50, 0);
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, jump, pounce);
        jump = false;
        pounce = false;
    }

}
