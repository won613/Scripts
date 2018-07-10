using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hatch : MonoBehaviour {

    public Image doorBar;
    public float timer;
    public Upstair upstair;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        doorBar.fillAmount = timer / 10;
        
        if(timer <= 0)
        {
            upstair.setActive = true;
            upstair.nextWave = true;
            Destroy(gameObject);
        }
        
	}

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
            {
                if (Input.GetKey(KeyCode.E))
                {
                    timer -= Time.deltaTime;
                }

            }
            
    }
}
