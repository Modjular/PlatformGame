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
        Vector3 offset = new Vector3(1 * (int)transform.localScale.x, 0, 0);
        Quaternion rot = Quaternion.Euler(0,0,90 * -(int)transform.localScale.x);
		GameObject spike =  Instantiate(projectile, transform.position + offset, rot);
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