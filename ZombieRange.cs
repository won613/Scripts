using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieRange : MonoBehaviour {
	public PlayerController player;
	public float activeMoveSpeed;
	public float hp;
	public GameObject bulletEffect;
	public Transform firePoint;
	public GameObject Zombie_bullet;

	private int attackOrder;
	private float attackdelay;
	private float attackCd;
	public float getdelay;
	public float getCd;

	private float shootdelay;
	private float shootCd;
	public float getshootdelay;
	public float getshootCd;
	public float shootspeed;


	public float condition;
	private float distance;
	public Collider2D attackTrigger;
	private Vector2 Target;
	private Animator myAnim;
	private int playerIsUpperThanEnemy;
	private bool IsLeft;
	private bool IsMove;
	private bool IsAttacking;

	private bool braking;
	private float timer;

	private float MonsterScale;

	// Use this for initialization
	void Start()
	{
		myAnim = GetComponent<Animator>();
		playerIsUpperThanEnemy = 1;
		IsLeft = true;
		attackOrder = 2;
		IsMove = true;
		IsAttacking = false;
		braking = false;

		attackdelay = getdelay;
		attackCd = 0.0f;
		shootdelay = getshootdelay;
		shootCd = 0.0f;
		distance = 10;
		timer = 0.3f;
		MonsterScale = Random.Range(-0.1f, 0.5f);
		attackTrigger.enabled = false;
		Target = new Vector2(1f, 1f);
		//Debug.Log(target.transform.position);

	}

	// Update is called once per frame
	void Update()
	{
		DieCheck();
		//target.transform.position = new Vector2(1f, 1f);
		FindPlayer();
		SetToTarget();
		flip();
		CheckCondition();
		if (braking)
			MeleeAttack();
		else
			ShootAttack();
		MoveToTarget();
		//Debug.Log(attackOrder);
		//Debug.Log(shootCd);
		/*
		Debug.DrawLine(transform.position, Target);
		Debug.Log(IsAttacking);
		Debug.Log(IsMove);
		Debug.Log(attackOrder);*/
	}
	void FindPlayer()
	{
		player = FindObjectOfType<PlayerController>();
		if (player.transform.position.y > transform.position.y + 2f)
		{
			// Player is up floor than Monster
			playerIsUpperThanEnemy = 2;
		}
		else if (player.transform.position.y + 2f < transform.position.y)
		{
			//Player is down floor than Monster
			playerIsUpperThanEnemy = 0;
		}
		else
		{
			//Player is same floor Monster
			playerIsUpperThanEnemy = 1;
		}
	}
	void SetToTarget()
	{
		if (!braking) // 부수지 않는중이면 타겟 설정
		{
			if (playerIsUpperThanEnemy == 1)
			{
				Target = player.transform.position;
				distance = Vector2.Distance(Target, transform.position);
			}
			else if (playerIsUpperThanEnemy == 2)
			{
				Target = new Vector2(5.5f, transform.position.y);
			}
			else if (playerIsUpperThanEnemy == 0)
			{
				Target = new Vector2(-5.7f, transform.position.y);
			}
		}
		else
		{
			//부수는 중이면 공격on 나머지 off
			IsAttacking = true;
			//IsMove = false;
			//distance = Vector2.Distance(Target, transform.position);

		}
	}

	void MoveToTarget()
	{
		if (IsMove && !IsAttacking)
		{
			if (Target.x > transform.position.x)
			{
				//transform.localScale = new Vector3(1f, 1f, 1f);
				IsLeft = true;
				transform.position = Vector2.MoveTowards(transform.position, Target, activeMoveSpeed * Time.deltaTime);
			}
			else
			{
				//transform.localScale = new Vector3(-1f, 1f, 1f);
				IsLeft = false;
				transform.position = Vector2.MoveTowards(transform.position, Target, activeMoveSpeed * Time.deltaTime);
			}
		}
	}
	public bool NowSameFloor()
	{
		if (playerIsUpperThanEnemy == 1)
			return true;
		else
			return false;
	}
	void OnTriggerStay2D(Collider2D col)
	{

		if (col.gameObject.tag == "upstair")
		{
			if (playerIsUpperThanEnemy == 2)
			{
				//x - 11.24
				// y + 4.04
				transform.position = new Vector3(transform.position.x - 11.24f, transform.position.y + 4.04f, 0f);
			}
		}

		if (col.gameObject.tag == "downstair")
		{
			if (playerIsUpperThanEnemy == 0)
			{
				transform.position = new Vector3(transform.position.x + 11.24f, transform.position.y - 4.02f, 0f);
			}
		}
		if (col.gameObject.tag == "barricade1")
		{
			if (col.gameObject.GetComponent<Barricade>().broken)
			{
				//부숨
				//attackOrder = 2;
				braking = false;
				IsMove = true;

			}
			else
			{
				//못부숨
				//attackOrder = 1;
				braking = true;
				IsMove = false;
			}

		}

	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Bullet")
		{
			hp -= 20;
			Instantiate(bulletEffect, col.transform.position, col.transform.rotation);
			StartCoroutine(HitEffect());
			Destroy(col.gameObject);
		}
	}
	void OnTriggerExit2D(Collider2D col)
	{
		if (col.gameObject.tag == "barricade1")
		{
			//밀려남
			//Debug.Log("exit barricade");
			braking = false;
		}
	}

	public void MeleeAttack()
	{
		if (IsAttacking && attackCd < 0)
		{
			if (attackdelay > 0)
			{
				IsMove = false;
				attackdelay -= Time.deltaTime;
			}
			else
			{

				attackTrigger.enabled = true;
				if (timer > 0)
				{
					timer -= Time.deltaTime;
				}
				else
				{
					attackTrigger.enabled = false;
					attackCd = getCd;
					attackdelay = getdelay;
					timer = 0.3f;
					if (!braking)
					{
						IsMove = true;
						IsAttacking = false;
					}
				}
			}
		}
	}
	public void ShootAttack()
	{
		if (IsAttacking&&shootCd<=0)
		{
			if (shootdelay > 0)
			{
				IsMove = false;
				shootdelay -= Time.deltaTime;
			}
			else
			{
				Debug.Log("11111111111");
				GameObject bullet = (GameObject)Instantiate(Zombie_bullet, firePoint.position, firePoint.rotation);
				if (IsLeft)
				{
					bullet.GetComponent<Rigidbody2D>().velocity = Vector2.right * shootspeed;
				}
				else
				{
					bullet.GetComponent<Rigidbody2D>().velocity = Vector2.left * shootspeed;
				}
				shootCd = getshootCd;
				shootdelay = getshootdelay;
				IsMove = true;
				IsAttacking = false;
				//shootCd = getshootCd;

			}

		}
		
	}

	public void CheckCondition()
	{
		if (attackCd >= 0 || shootCd >= 0)
		{
			attackCd -= Time.deltaTime;
			shootCd -= Time.deltaTime;
			//IsAttacking = false;
		}
		else
		{
			if (condition > distance)
			{
				if (!braking)
				{ attackOrder = 3; }
				//Debug.Log("attack ok?");
				IsAttacking = true;
			}
		}
	}
	public void DieCheck()
	{
		if (hp <= 0)
		{
			Destroy(gameObject);
			StopAllCoroutines();
		}
		if (this.myAnim.GetCurrentAnimatorStateInfo(0).IsName("Zombie_die"))
		{
			Destroy(gameObject);
		}

	}
	public void flip()
	{
		//braking = true;
		if (IsLeft)
			transform.localScale = new Vector3(1f + MonsterScale, 1f + MonsterScale, 1f);
		else
			transform.localScale = new Vector3(-(1f + MonsterScale), 1f + MonsterScale, 1f);

	}
	void shoot()
	{
		GameObject bullet = (GameObject)Instantiate(Zombie_bullet, firePoint.position, firePoint.rotation);
		if (IsLeft)
		{
			bullet.GetComponent<Rigidbody2D>().velocity = Vector2.right *shootspeed;
		}
		else
		{
			bullet.GetComponent<Rigidbody2D>().velocity = Vector2.left * shootspeed;
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
