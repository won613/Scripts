using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletUI : MonoBehaviour
{
    public Text Bullet;
    public Weapon weapon;
    public PlayerController player;

    // Use this for initialization
    void Start()
    {
        Bullet = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        switch (player.whatGun)
        {
            case 0:
                weapon= GameObject.Find("pistol").GetComponent<Weapon>();
                Bullet.text = "Bullet " + weapon.BulletCount + "/" + weapon.staticBulletCount;
                break;
            case 1:
                player.mp5.SetActive(true);
                weapon = GameObject.Find("mp5").GetComponent<Weapon>();
                Bullet.text = "Bullet " + weapon.BulletCount + "/" + weapon.staticBulletCount;
                break;
            default:
                break;
        }

    }

}
