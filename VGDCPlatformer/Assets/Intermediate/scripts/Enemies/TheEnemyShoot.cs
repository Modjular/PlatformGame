using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheEnemyShoot : MonoBehaviour {

	public bool moveRight = false; //checks if the enemy moves right or left
	public float movSpeed = 2.5f; //movement of the enemy
	public AudioClip deathSound;

    public GameObject parent;
	public GameObject projectile;

	public int lower_rate;
	private int time = 0;


	void shoot()
	{
		try{
			GameObject spike =  Instantiate(projectile, transform);
		}catch(System.Exception e){};

	}

	void FixedUpdate()
	{
		time ++;
		if(time==lower_rate)
		{
			time=0;
			shoot();
		}

	}
	


    //Destroys the GameObject
	public void Die()
	{
		if (deathSound)
		{
			AudioSource.PlayClipAtPoint(deathSound, transform.position);
		}
		Destroy(parent);
	}

}