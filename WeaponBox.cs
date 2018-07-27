using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBox : MonoBehaviour {

    public GameObject mp5;
    public GameObject shotgun;
    public GameObject grenade;
    public int randomGun;//1 mp5 2 shotgun 3 grenade
	// Use this for initialization
	void Start () {
		
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
                randomGun= Random.Range(1,4);
                if (randomGun == 1)
                {
                    Instantiate(mp5, transform.position, transform.rotation);
                }
                if (randomGun == 2)
                {
                    Instantiate(shotgun, transform.position, transform.rotation);
                }
                if (randomGun == 3)
                {
                    Instantiate(grenade, transform.position, transform.rotation);
                }
                Destroy(gameObject);
            }

        }

    }
}
