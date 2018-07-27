using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hatch : MonoBehaviour
{

    public Image doorBar;
    public float timer;
    public Upstair upstair;
    public PlayerController player;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        doorBar.fillAmount = timer / 10;
        player = GameObject.Find("Player").GetComponent<PlayerController>();

        if (timer <= 0)
        {
            upstair.setActive = true;
            upstair.nextWave = true;
            player.oxygenpoint = 100f;
            Destroy(gameObject);
        }

    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (Input.GetKey(KeyCode.E))
            {
                timer -= Time.deltaTime * 0.5f;
            }
        }
    }
}
