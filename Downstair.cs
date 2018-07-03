using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Downstair : MonoBehaviour {

    public GameObject upstair;
    public PlayerController player;
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
                player.takeDownstair = true;
            }
        }

    }
}
