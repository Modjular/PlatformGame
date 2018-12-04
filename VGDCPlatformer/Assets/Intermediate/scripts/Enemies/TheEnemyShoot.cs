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
		GameObject spike =  Instantiate(projectile, transform);
        spike.GetComponent<EnemyShoot>().direction = (int)transform.localScale.x;
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