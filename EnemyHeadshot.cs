using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHeadshot : MonoBehaviour {

	public Enemy enemy;
	public GameObject bulletEffect;
	// Use this for initialization
	void Start () {
		enemy = transform.parent.gameObject.GetComponent<Enemy>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Bullet" && enemy.canHit == true)
		{
			enemy.hp -= 40;
			enemy.canHit = false;
			enemy.hitTimer = 0;
			Instantiate(bulletEffect, col.transform.position, col.transform.rotation);
			Destroy(col.gameObject);
			StartCoroutine(HitEffect());
			Debug.Log("HeadShot");
		}

	}

	IEnumerator HitEffect()
	{
		Renderer rend = transform.parent.gameObject.GetComponent<Renderer>();

		rend.material.color = Color.red;
		yield return new WaitForSeconds(0.04f);
		rend.material.color = Color.white;
		yield return new WaitForSeconds(0.04f);

	}
}
