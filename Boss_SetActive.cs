using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_SetActive : MonoBehaviour {

	public GameObject Boss;
	private bool BossSpawn;
	// Use this for initialization
	void Start () {
		BossSpawn = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player"&&!BossSpawn)
		{
			Boss.SetActive(true);
			BossSpawn = true;
		}

	}
}
