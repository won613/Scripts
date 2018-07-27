using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

	public bool isFiring;
	public BulletController bullet;
	public int BulletCount;
	public int staticBulletCount;

	public CsvInfo weaponInfo;

	public float timeBetweenShots;
	private float shotCounter;
	public float reloadtime;
	public float reloadStart;

	public bool reloadcheck = false;

	public Transform firePoint;

	public PlayerController player;

	void Start()
	{
		reloadcheck = false;
	}

	// Update is called once per frame
	void Update()
	{
		if (player.whatGun == 0)
		{
			weaponInfo = GameObject.Find("pistol").GetComponent<CsvInfo>();
			staticBulletCount = weaponInfo.bulletCount;
			timeBetweenShots = weaponInfo.timeBetweenShots;
			reloadtime = weaponInfo.reloadTime;
		}


		if (player.whatGun == 1)
		{
			weaponInfo = GameObject.Find("mp5").GetComponent<CsvInfo>();
			staticBulletCount = weaponInfo.bulletCount;
			timeBetweenShots = weaponInfo.timeBetweenShots;
			reloadtime = weaponInfo.reloadTime;
		}

		if (Input.GetMouseButtonDown(0))
			isFiring = true;



		if (Input.GetMouseButtonUp(0))
			isFiring = false;


		if (Input.GetKeyDown(KeyCode.R))
		{
			isFiring = false;
			reloadcheck = true;
		}

		if (reloadcheck)
		{
			reloadStart += Time.deltaTime;
		}

		//reloadtime만큼 시간이 지나면 장전
		if (reloadtime <= reloadStart && reloadcheck)
		{
			BulletCount = weaponInfo.bulletCount;
			reloadStart = 0;
			reloadcheck = false;
		}

		if (isFiring && BulletCount > 0 && !reloadcheck)

		{
			shotCounter -= Time.deltaTime;
			if (shotCounter <= 0)
			{
				shotCounter = timeBetweenShots;
				Instantiate(bullet.transform, firePoint.transform.position, firePoint.rotation);
				BulletCount--;
			}
			if (BulletCount < 0)
			{
				BulletCount = 0;
			}
		}
		else
		{
			shotCounter = 0;
		}

	}
}
