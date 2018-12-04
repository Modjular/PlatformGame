using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheEnemyShoot : MonoBehaviour {


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