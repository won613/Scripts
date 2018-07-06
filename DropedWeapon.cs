using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropedWeapon : MonoBehaviour {

    public int whatGun;
    public PlayerController player;
   
	// Use this for initialization
	void Start () {
        player = GameObject.FindObjectOfType<PlayerController>();

    }

    // Update is called once per frame
    void Update () {
     
	}

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (whatGun == 1)
                {
                    player.whatGun = 1;
                    Destroy(gameObject);
                }
            }

        }

    }
}
