using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangeAttack : MonoBehaviour {

	private float shotdelay;
	private float shotCd;

	public float condition;
	public float distance;
	public GameObject EnemyBullet;
	public Transform firePoint;
	public float getdelay;
	public float getCd;

	public bool isleft;
	// Use this for initialization
	void Start () {
		shotdelay = getdelay;
		shotCd = getCd;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void ShootBullet()
	{
		if (shotCd > 0)
		{
			shotCd -= Time.deltaTime;
		}
		else
		{
			if (distance < condition)
			{
				if (shotdelay > 0)
				{
					shotdelay -= Time.deltaTime;
				}
				else
				{
					GameObject bullet = (GameObject)Instantiate(EnemyBullet, firePoint.position, firePoint.rotation);
					if (isleft)
					{
						bullet.GetComponent<Rigidbody2D>().velocity = Vector2.left * 10;
					}
					else
					{
						bullet.GetComponent<Rigidbody2D>().velocity = Vector2.right * 10;
					}
					shotCd = getCd;
				}
			}
		}
	}
	public void CdManger()
	{
		if (shotCd > 0)
			shotCd -= Time.deltaTime;
	}
}
