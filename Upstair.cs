using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upstair : MonoBehaviour {

    public GameObject downstair;
    public PlayerController player;
    public bool setActive;
    public WaveSpawner waveSpawner;
    public bool nextWave;
	// Use this for initialization
	void Start () {
        setActive = false;
        nextWave = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (setActive == true && nextWave == true)
        {
            waveSpawner.hatchOpened = true;
            nextWave = false;
        }
            
	}

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if(setActive == true)
                {
                    player.takeUpstair = true;

                }
               
            }

        }

    }
}
