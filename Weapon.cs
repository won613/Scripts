using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Weapon : MonoBehaviour
{

	public bool isFiring;
	public GameObject bullet;
	public int BulletCount;
	public int staticBulletCount;
	private int fullBulletCount;
	
	public CsvInfo weaponInfo;

	public float timeBetweenShots;
	private float shotCounter;
	public float reloadtime;
	private DateTime startreloadtime;
	private TimeSpan checkreloadtime;

    public float minRecoil;
    public float maxRecoil;
    public float nowMinRecoil;
    public float nowMaxRecoil;
    public float recoilAmount;
    public float restoreRecoilAmount;

	private bool reloadcheck;

	public Transform firePoint;
    GameObject tempMyBullet;
	
    public PlayerController player;
	public float reloadStart;


	void Start()
	{
		staticBulletCount = BulletCount;
		reloadcheck = false;
		fullBulletCount = BulletCount;

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
			if (reloadcheck == false)
			{
				if (BulletCount != fullBulletCount)
				{
					isFiring = false;
					reloadcheck = true;
					startreloadtime = System.DateTime.Now;
				}
			}	
						
		}
        		
		if (reloadcheck)
		{
			checkreloadtime = System.DateTime.Now - startreloadtime;
		}
        	
		if (reloadtime <= (checkreloadtime.TotalSeconds % 60) && reloadcheck)
		{

			switch (player.whatGun)
			{
				case 0:
					BulletCount = 20;
					reloadcheck = false;
					break;

				case 1:
					BulletCount = 100;
					reloadcheck = false;
					break;
				default:
					break;
			}
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

                tempMyBullet = Instantiate(bullet, firePoint.position, Quaternion.Euler(0, 0, transform.eulerAngles.z + UnityEngine.Random.Range(nowMinRecoil, nowMaxRecoil))) as GameObject;
                Vector3 velocity = tempMyBullet.transform.rotation * Vector3.right;
                tempMyBullet.GetComponent<Rigidbody2D>().AddForce(velocity * 10f);
                BulletCount--;
                nowMinRecoil -= recoilAmount;
                nowMaxRecoil += recoilAmount;

                if (nowMinRecoil < minRecoil)
                    nowMinRecoil = minRecoil;
                if (nowMaxRecoil > maxRecoil)
                    nowMaxRecoil = maxRecoil;

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


        nowMinRecoil += restoreRecoilAmount * Time.deltaTime;
        nowMaxRecoil -= restoreRecoilAmount * Time.deltaTime;
        if (nowMinRecoil > 0)
            nowMinRecoil = 0;
        if (nowMaxRecoil < 0)
            nowMaxRecoil = 0;
        

	}


}

