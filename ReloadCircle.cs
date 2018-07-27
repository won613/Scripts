using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReloadCircle : MonoBehaviour {

	public Transform LoadingBar;
    public Image radialProgressBar;
    public Image center;
    public Weapon weapon;
    public PlayerController player;
    private float staticreloadTime;

    void Start()
    {
       
    }

    void Update()
    {
        transform.position = Input.mousePosition;
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        switch (player.whatGun)
        {
            case 0:
                weapon = GameObject.Find("pistol").GetComponent<Weapon>();
                staticreloadTime = weapon.reloadtime;
                LoadingBar.GetComponent<Image>().fillAmount = weapon.reloadStart / staticreloadTime;
                if (weapon.reloadcheck)
                {
                    Cursor.visible = false;
                    radialProgressBar.enabled = true;
                    center.enabled = true;
                }
                else
                {
                    Cursor.visible = true;
                    radialProgressBar.enabled = false;
                    center.enabled = false;
                }
                break;
            case 1:
                player.mp5.SetActive(true);
                weapon = GameObject.Find("mp5").GetComponent<Weapon>();
                staticreloadTime = weapon.reloadtime;
                LoadingBar.GetComponent<Image>().fillAmount = weapon.reloadStart / staticreloadTime;
                if (weapon.reloadcheck)
                {
                    Cursor.visible = false;
                    radialProgressBar.enabled = true;
                    center.enabled = true;
                }
                else
                {
                    Cursor.visible = true;
                    radialProgressBar.enabled = false;
                    center.enabled = false;
                }
                break;
            default:
                break;
        }   
    }
}
