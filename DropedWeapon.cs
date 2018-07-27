using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropedWeapon : MonoBehaviour
{

    public int whatGun;
    public PlayerController player;
    public WeaponBox kindofGun;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindObjectOfType<PlayerController>();
        kindofGun = GameObject.Find("weaponBox").GetComponent<WeaponBox>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if(kindofGun.randomGun==1)
                {
                    player.whatGun = 1;
                    Destroy(gameObject);
                }
                if (kindofGun.randomGun == 2)
                {
                    player.whatGun = 2;
                    Destroy(gameObject);
                }
                if (kindofGun.randomGun == 3)
                {
                    player.whatGun = 3;
                    Destroy(gameObject);
                }

            }

        }

    }
}
