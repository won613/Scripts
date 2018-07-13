using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_Boss_ArmShoot : MonoBehaviour {
	public float destroytime;
	// Use this for initialization
	void Start () {
		Destroy(this.gameObject, destroytime);
	}
	
	// Update is called once per frame
	void Update () {
		//transform.Translate(Vector3.right * Time.deltaTime * speed);

	}
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Ground")
		{
			Destroy(gameObject);
		}
		if (col.gameObject.tag == "Bullet")
		{
			Destroy(gameObject);
		}

	}
	
}
