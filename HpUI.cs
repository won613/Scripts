using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpUI : MonoBehaviour {

    public Text hp;
    public PlayerController player;

    // Use this for initialization
    void Start () {
        hp = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        hp.text = player.hp + " / " + player.staticHp;
    }
}
