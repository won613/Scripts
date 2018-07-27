using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

    public GameObject bullet;
    public GameObject firePoint;
	public bool isReloading;
	private float reloadCount;
	public float fireRate;
	// Use this for initialization
	void Start () {
		isReloading = false;
		reloadCount = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		reloadCount += Time.deltaTime;

		if (isReloading == true && reloadCount >= fireRate)
		{
			reloadCount = 0f;
			isReloading = false;
		}
	}

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy" && isReloading == false)
        {
			
			if (col.transform.position.x > transform.position.x)
			{
				transform.localScale = new Vector3(1f, 1f, 1f);
				Instantiate(bullet, firePoint.transform.position, transform.rotation);
			}

			else if (col.transform.position.x < transform.position.x)
			{
				transform.localScale = new Vector3(-1f, 1f, 1f);
				Instantiate(bullet, firePoint.transform.position, transform.rotation);
				
			}

			isReloading = true;
			reloadCount = 0f;
			
		}
        
    }
}
