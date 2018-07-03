using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropedWeapon : MonoBehaviour {

    public int whatGun;
    public PlayerController player;
   
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        player = GameObject.FindObjectOfType<PlayerController>();

		
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
