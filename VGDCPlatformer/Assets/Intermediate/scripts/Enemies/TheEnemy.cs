using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheEnemy : MonoBehaviour {

	public bool moveRight = false; //checks if the enemy moves right or left
	public float movSpeed = 2.5f; //movement of the enemy
	
    //Patrol Positions
    public Transform positionA;
    public Transform positionB;

    public GameObject parent;

	public GameObject projectile;
	private int time = 0;

	

	
	// Update is called once per frame
	void Update () {
		
		if (moveRight == true)
		{
			transform.Translate(Vector2.right * movSpeed * Time.deltaTime);
		}

		else
		{
			transform.Translate(Vector2.left * movSpeed * Time.deltaTime);
		}

		//enemy moves until reaching a boundary, then we will flip the gameObject
		if (transform.position.x >= positionA.position.x ||
		transform.position.x < positionB.position.x) 
		{
			Flip();
		}
	}

	void shoot()
	{
		GameObject spike = Instantiate(projectile, transform);
		
		//GameObject cube = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
        ////GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //GameObject cube = new GameObject("snowball");
        ////cube.AddComponent<Rigidbody>();
        ////cube.transform.position = new Vector2(transform.position.x, transform.position.y);
        //fast = cube.GetComponent<Rigidbody2D>();
        //fast.velocity = new Vector2(-50, 0);

		
        ////cube.GetComponent<Rigidbody>().velocity = new Vector2(-20 * gameObject.transform.localScale.x, 0);
		//Debug.Log("Facing value is: " + facing);
		//Debug.Log("rotation value is:" + transform.rotation.y);
        //cube.GetComponent<Rigidbody2D>().AddForce(transform.forward * 30);

	}

	void FixedUpdate()
	{
		time ++;
		if(time==50)
		{
			time=0;
			shoot();
		}

	}
	


    //Destroys the GameObject
	public void Die()
	{
		Destroy(parent);
	}

    //flips the entire gameObject and its components
    void Flip()
    {
        moveRight = !moveRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
}