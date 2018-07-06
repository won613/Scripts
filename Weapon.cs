using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Weapon : MonoBehaviour
{
<<<<<<< HEAD
    public bool isFiring;
    public BulletController bullet;
    public int BulletCount;
    public int staticBulletCount;
=======

    public bool isFiring;
    public BulletController bullet;
    public int BulletCount;
>>>>>>> origin/master

    public float timeBetweenShots;
    private float shotCounter;
    public double reloadtime;
    private DateTime startreloadtime;
    private TimeSpan checkreloadtime;
<<<<<<< HEAD
    private bool reloadcheck = false;

    public Transform firePoint;

    public PlayerController player;
=======
    //private float timecount;
    private bool reloadcheck;

    //private void discountreloadtime(float timecount)
    //{
    //    reloadtime -= timecount*Time.deltaTime;
    //}

    public Transform firePoint;


    public PlayerController player;

    void Start()
    {
        reloadcheck = false;
    }

    // Update is called once per frame
    void Update()
    {
>>>>>>> origin/master

    void Start()
    {
        staticBulletCount = BulletCount;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
             isFiring = true;



        if (Input.GetMouseButtonUp(0))
            isFiring = false;


        if (Input.GetKeyDown(KeyCode.R))
        {
            isFiring = false;
            reloadcheck = true;
            startreloadtime = System.DateTime.Now;
        }

        if (reloadcheck)
        {
            checkreloadtime = System.DateTime.Now - startreloadtime;
        }

<<<<<<< HEAD
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

        }

        if (isFiring && BulletCount > 0 && !reloadcheck)
=======
        if (reloadtime <= (checkreloadtime.TotalSeconds%60)&&reloadcheck)
        {
            if (player.whatGun == 0)
            {
                BulletCount = 10;
            }

            if (player.whatGun == 1)
            {
                BulletCount = 30;
            }
            reloadcheck = false;
        }

        if (isFiring && BulletCount > 0)
>>>>>>> origin/master
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
<<<<<<< HEAD



=======
>>>>>>> origin/master
