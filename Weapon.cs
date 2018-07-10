using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< HEAD
public class Weapon : MonoBehaviour
{

    public bool isFiring;
    public BulletController bullet;
    public int BulletCount;
    public int staticBulletCount;

    public float timeBetweenShots;
    private float shotCounter;
    public double reloadtime;
    private DateTime startreloadtime;
    private TimeSpan checkreloadtime;

    private bool reloadcheck = false;
=======
public class Weapon : MonoBehaviour {

    public bool isFiring;
    public BulletController bullet;

    public float timeBetweenShots;
    private float shotCounter;
>>>>>>> origin/master

    public Transform firePoint;
   

    public PlayerController player;
<<<<<<< HEAD


   
    void Start()
    {
        staticBulletCount = BulletCount;
    }
=======
    
    
	// Update is called once per frame
	void Update () {
>>>>>>> origin/master

        if (Input.GetMouseButtonDown(0))
            isFiring = true;

        if (Input.GetMouseButtonUp(0))
            isFiring = false;

<<<<<<< HEAD

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

        //reloadtime만큼 시간이 지나면 장전
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
        if (isFiring)
>>>>>>> origin/master
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

<<<<<<< HEAD
    }
=======


	}

    
>>>>>>> origin/master
}
