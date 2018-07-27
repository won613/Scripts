using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CsvInfo : MonoBehaviour
{

	public int bulletCount;
	public float timeBetweenShots;
	public float reloadTime;
	public PlayerController player;


	void Start()
	{

		player = GameObject.Find("Player").GetComponent<PlayerController>();

		List<Dictionary<string, object>> data = CsvParser.Read("weaponInfo");

		//플레이어의 총이 무엇인지에 따라 받아오는 정보가 다르도록 함.
		var i = player.whatGun;

		bulletCount = (int)data[i]["BULLETCOUNT"];
		timeBetweenShots = (float)data[i]["timeBetweenShots"];
		reloadTime = (float)data[i]["reloadTime"];

	}

	// Update is called once per frame
	void Update()
	{

	}
}
