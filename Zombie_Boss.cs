using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_Boss : MonoBehaviour {

	public PlayerController player;
	public Rigidbody2D myRigidbody;
	public float activeMoveSpeed;
	public float hp;
	private Animator myAnim;
	public GameObject bulletEffect;
	// Use this for initialization
	public GameObject Zombie_bullet;
	public Transform firePoint;

	private bool isMove;
	public float shootCd;
	public float meleeCd;

	private bool Attacking = false;
	private float attackTimer = 0f;
	private float FirstAttackCd = 0.3f; // firstattack running timer
	private float firstdelay = 0f; // firstattack delay handle
	private float SecondAttackCd = 0.3f;  // secondattack running timer

	private int attackOrder = 1; // attack order 1~3
	public Collider2D attackTrigger;  // first attack
	public Collider2D attackTrigger2; // second attack

	private bool Shooting = false;
	private float delay = 0f; // shoot delay handle
	public float delayCd = 5.0f; // shoot delay timer


	void Start() {
		shootCd = 1;
		meleeCd = 1;
		isMove = true;
		attackTrigger.enabled = false;
		attackTrigger2.enabled = false;
		delay = delayCd;
	}


	void Update() {
		player = GameObject.FindObjectOfType<PlayerController>();
		float between = Vector2.Distance(player.transform.position, transform.position);
		if (transform.position.x > player.transform.position.x)
		{// playe <---boss move
			transform.localScale = new Vector2(1.3f, 1.8f);
		}
		else
		{//player -->boss move
			transform.localScale = new Vector2(-1.3f, 1.8f);
		}

		if (isMove&&!Attacking&&!Shooting)
		{
			Move();
		}

		if (between < 8&& shootCd < 0 && !Attacking)
		{

			if (!Shooting)
			{
				isMove = false;
				Shooting = true;
				delay = delayCd;
			}
			if (delay > 0)
			{
				delay -= Time.deltaTime; // shooting anim time
			}
			if(delay<0&&Shooting)
			{
				ShootArm();
			}// boss shoot arm
		}

		if (between < 3&&meleeCd<0&&!Shooting)
		{
			MeleeAttack();
		}


		if (hp <= 0)
		{
			Destroy(gameObject);
			StopAllCoroutines();
		}
	}




	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Bullet")
		{
			hp -= 10;
			Instantiate(bulletEffect, col.transform.position, col.transform.rotation);
			StartCoroutine(HitEffect());
			Destroy(col.gameObject);
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
	void Move()
	{

		transform.position = Vector2.MoveTowards(transform.position, player.transform.position, activeMoveSpeed * Time.deltaTime);
		shootCd -= Time.deltaTime;
		meleeCd -= Time.deltaTime;
	}
	void ShootArm()
	{
		if (transform.position.x > player.transform.position.x)
		{
			GameObject bullet = (GameObject)Instantiate(Zombie_bullet, firePoint.position, firePoint.rotation);
			// playe <---boss shooting
			bullet.GetComponent<Rigidbody2D>().velocity = Vector2.left * 10;
		//	delay = delayCd;
			shootCd = 5f;
			isMove = true;
			Shooting = false;
		}
		else
		{
			GameObject bullet = (GameObject)Instantiate(Zombie_bullet, firePoint.position, firePoint.rotation);
			//player -->boss shooting
			bullet.GetComponent<Rigidbody2D>().velocity = Vector2.right * 10;
			//bullet.transform.position = Vector2.MoveTowards(firePoint.position, player.transform.position, activeMoveSpeed * Time.deltaTime * 10);
		//	delay = delayCd;
			shootCd = 5f;
			isMove = true;
			Shooting = false;
		}
	}

	void MeleeAttack()
	{
		if (attackOrder == 1)
		{
			isMove = false;
			if (!Attacking)
			{
				Debug.Log("first attack start");
				Attacking = true;
				attackTimer = FirstAttackCd;
				attackTrigger.enabled = true;
			}
			if (Attacking)
			{
				if (attackTimer > 0)
				{
					attackTimer -= Time.deltaTime;

				}
				else
				{
					Attacking = false;
					attackTrigger.enabled = false;
					attackOrder = 2;
					firstdelay = 1f;
					//Debug.Log("first attack end");
				}
			}
		}
		if (attackOrder == 2)
		{
			if (firstdelay > 0)
			{
				//Debug.Log("delay first attack");
				firstdelay -= Time.deltaTime;
			}
			else
			{
				attackTrigger2.enabled = true;
				attackTimer = SecondAttackCd;
				attackOrder = 3;
				//Debug.Log("seconde attack start");
			}
		}
		if (attackOrder == 3)
		{
			if (attackTimer > 0)
			{
				attackTimer -= Time.deltaTime;
			}
			else
			{
				Attacking = false;
				attackTrigger2.enabled = false;
				attackOrder = 1;
				meleeCd = 3;
				isMove = true;
				//Debug.Log("second attack end");
			}
		}
	}

}

