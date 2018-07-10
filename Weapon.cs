using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public bool isFiring;
    public BulletController bullet;

    public float timeBetweenShots;
    private float shotCounter;

    public Transform firePoint;
   

    public PlayerController player;
    
    
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
            isFiring = true;

        if (Input.GetMouseButtonUp(0))
            isFiring = false;

        if (isFiring)
        {
            shotCounter -= Time.deltaTime;
            if(shotCounter <= 0)
            {
                shotCounter = timeBetweenShots;
                
                Instantiate(bullet.transform, firePoint.transform.position, firePoint.rotation);
                               
            }
        } else
        {
            shotCounter = 0;
        }



	}

    
}
