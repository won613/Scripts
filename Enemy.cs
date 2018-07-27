using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{

	public PlayerController player;
	public Rigidbody2D myRigidbody;
	public float activeMoveSpeed;
	public float hp;
	private Animator myAnim;
	private bool breaking;
	public Barricade barricade1;
	public Barricade barricade2;
	public Barricade barricade3;
	public Barricade barricade4;
	public GameObject bulletEffect;
	public Upstair upstair;
	public Downstair downstair;
	private int playerIsUpperThanEnemy;//0 = same 1 = playerUpper 2 = playerLower
	public int enemy; // 0 = normal 1 = fast 2 = range 3 = tanker
	public BulletController bullet;
	public Transform rangefirepoint;
	public bool canHit;
	public float hitTimer;

	
	public void actzombie_range()
	{
		if (player.transform.position.x - transform.position.x < 5.0f || -(player.transform.position.x - transform.position.x) < 5.0f)
		{
			bullet.speed = 10f;
			if (player.transform.position.x < transform.position.x)
			{
				Instantiate(bullet.transform, rangefirepoint.transform.position, rangefirepoint.rotation);

			}

			if (player.transform.position.x > transform.position.x)
			{

				Instantiate(bullet.transform, rangefirepoint.transform.position, rangefirepoint.rotation);

			}


		}
	}

	// Use this for initialization
	void Start()
	{
		myAnim = GetComponent<Animator>();
		breaking = false;
		canHit = true;
		playerIsUpperThanEnemy = 0;
	}

	// Update is called once per frame
	void Update()
	{

		player = GameObject.FindObjectOfType<PlayerController>();
		barricade1 = GameObject.Find("barricade1").GetComponent<Barricade>();
		barricade2 = GameObject.Find("barricade2").GetComponent<Barricade>();
		barricade3 = GameObject.Find("barricade3").GetComponent<Barricade>();
		barricade4 = GameObject.Find("barricade4").GetComponent<Barricade>();
		upstair = GameObject.Find("upstair").GetComponent<Upstair>();
		downstair = GameObject.Find("downstair").GetComponent<Downstair>();

		if (player.transform.position.y > transform.position.y + 2f)
		{
			playerIsUpperThanEnemy = 1;
		}
		else if (player.transform.position.y + 2f < transform.position.y)
		{
			playerIsUpperThanEnemy = 2;
		}
		else
		{
			playerIsUpperThanEnemy = 0;
		}

		if (breaking == false)
		{
			if (playerIsUpperThanEnemy == 0 && player.transform.position.x > transform.position.x)
			{

				myRigidbody.velocity = new Vector3(activeMoveSpeed, myRigidbody.velocity.y, 0f);
				transform.localScale = new Vector3(1f, 1f, 1f);
				if (enemy == 2)
				{
					actzombie_range();

				}
			}

			else if (playerIsUpperThanEnemy == 0 && player.transform.position.x < transform.position.x)
			{
				myRigidbody.velocity = new Vector3(-activeMoveSpeed, myRigidbody.velocity.y, 0f);
				transform.localScale = new Vector3(-1f, 1f, 1f);
				if (enemy == 2)
				{
					actzombie_range();

				}
			}

			else if (playerIsUpperThanEnemy == 1 && upstair.transform.position.x > transform.position.x)
			{
				myRigidbody.velocity = new Vector3(activeMoveSpeed, myRigidbody.velocity.y, 0f);
				transform.localScale = new Vector3(1f, 1f, 1f);
				if (enemy == 2)
				{
					actzombie_range();

				}
			}

			else if (playerIsUpperThanEnemy == 1 && upstair.transform.position.x < transform.position.x)
			{
				myRigidbody.velocity = new Vector3(-activeMoveSpeed, myRigidbody.velocity.y, 0f);
				transform.localScale = new Vector3(-1f, 1f, 1f);
				if (enemy == 2)
				{
					actzombie_range();
				}
			}

			else if (playerIsUpperThanEnemy == 2 && downstair.transform.position.x > transform.position.x)
			{
				myRigidbody.velocity = new Vector3(activeMoveSpeed, myRigidbody.velocity.y, 0f);
				transform.localScale = new Vector3(1f, 1f, 1f);
				if (enemy == 2)
				{
					actzombie_range();

				}
			}

			else if (playerIsUpperThanEnemy == 2 && downstair.transform.position.x < transform.position.x)
			{
				myRigidbody.velocity = new Vector3(-activeMoveSpeed, myRigidbody.velocity.y, 0f);
				transform.localScale = new Vector3(-1f, 1f, 1f);
				if (enemy == 2)
				{
					actzombie_range();

				}
			}
		}


		if (hp <= 0)
		{
			//myAnim.SetBool("die", true);
			Destroy(gameObject);
		}

		if (this.myAnim.GetCurrentAnimatorStateInfo(0).IsName("Zombie_die"))
		{
			Destroy(gameObject);
		}

		hitTimer += Time.deltaTime;

		if (hitTimer > 0.01f)
			canHit = true;
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Bullet" && canHit == true)
		{
			hp -= 20;
			canHit = false;
			hitTimer = 0;
			Instantiate(bulletEffect, col.transform.position, col.transform.rotation);
			Destroy(col.gameObject);
			StartCoroutine(HitEffect());
			Debug.Log("Hit");
		}

	}



	void OnTriggerStay2D(Collider2D col)
	{

		if (col.gameObject.tag == "upstair")
		{
			if (playerIsUpperThanEnemy == 1)
			{
				transform.position = new Vector3(downstair.transform.position.x, downstair.transform.position.y, 0f);
			}
		}

		if (col.gameObject.tag == "downstair")
		{
			if (playerIsUpperThanEnemy == 2)
			{
				transform.position = new Vector3(upstair.transform.position.x, upstair.transform.position.y, 0f);
			}
		}

		if (col.gameObject.tag == "barricade1")
		{

			if (barricade1.broken == false)
			{
				breaking = true;
				barricade1.hp -= Time.deltaTime;
			}
			else
			{
				breaking = false;
			}

		}
		if (col.gameObject.tag == "barricade2")
		{

			if (barricade2.broken == false)
			{
				breaking = true;
				barricade2.hp -= Time.deltaTime;
			}
			else
			{
				breaking = false;
			}

		}
		if (col.gameObject.tag == "barricade3")
		{

			if (barricade3.broken == false)
			{
				breaking = true;
				barricade3.hp -= Time.deltaTime;
			}
			else
			{
				breaking = false;
			}

		}
		if (col.gameObject.tag == "barricade4")
		{

			if (barricade4.broken == false)
			{
				breaking = true;
				barricade4.hp -= Time.deltaTime;
			}
			else
			{
				breaking = false;
			}

		}

	}

	IEnumerator HitEffect()
	{
		Renderer rend = GetComponent<Renderer>();

		rend.material.color = Color.red;
		yield return new WaitForSeconds(0.04f);
		rend.material.color = Color.white;
		yield return new WaitForSeconds(0.04f);

	}
}
