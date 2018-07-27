using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieFast : MonoBehaviour {
<<<<<<< HEAD
=======


>>>>>>> origin/master
	public PlayerController player;
	public float activeMoveSpeed;
	public float hp;
	public GameObject bulletEffect;

	private int attackOrder;
	private float attackdelay;
	private float attackCd;
	public float getdelay;
	public float getCd;

<<<<<<< HEAD
	private float dashdelay;
	private float dashCd;
	public float getdashdelay;
	public float getdashCd;
	public float dashpower;

=======
>>>>>>> origin/master

	public float condition;
	private float distance;
	public Collider2D attackTrigger;
<<<<<<< HEAD
	private Vector2 Target;
=======
	private Transform target;
>>>>>>> origin/master
	private Animator myAnim;
	private int playerIsUpperThanEnemy;
	private bool IsLeft;
	private bool IsMove;
	private bool IsAttacking;
<<<<<<< HEAD

	private bool braking;
	private float timer;
	private Rigidbody2D rb;
=======
	private bool braking;
	private float timer;
>>>>>>> origin/master

	private float MonsterScale;

	// Use this for initialization
	void Start()
	{
<<<<<<< HEAD
		rb = GetComponent<Rigidbody2D>();
		myAnim = GetComponent<Animator>();
		playerIsUpperThanEnemy = 1;
		IsLeft = true;
		attackOrder = 2;
		IsMove = true;
		IsAttacking = false;
		braking = false;

		attackdelay = getdelay;
		attackCd = 0.0f;
		dashdelay = getdashdelay;
		dashCd = 0.0f;
=======
		myAnim = GetComponent<Animator>();
		playerIsUpperThanEnemy = 1;
		IsLeft = true;
		IsMove = true;
		IsAttacking = false;
		attackdelay = getdelay;
		attackCd = 0.0f;
>>>>>>> origin/master
		distance = 10;
		timer = 0.3f;
		MonsterScale = Random.Range(-0.1f, 0.5f);
		attackTrigger.enabled = false;
<<<<<<< HEAD
		Target = new Vector2(1f, 1f);
=======
		braking = false;
		if (target == null)
		{
			Debug.Log("no target");
		}
>>>>>>> origin/master
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
<<<<<<< HEAD
		if (braking)
			MeleeAttack();
		else
			DashAttack();
		MoveToTarget();
		/*
		Debug.DrawLine(transform.position, Target);
		Debug.Log(IsAttacking);
		Debug.Log(IsMove);
		Debug.Log(attackOrder);*/
=======
		MeleeAttack();
		MoveToTarget();
		Debug.DrawLine(transform.position, target.position);
		Debug.Log(IsAttacking);
>>>>>>> origin/master
	}
	void FindPlayer()
	{
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
<<<<<<< HEAD
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
=======
		if (!braking)
		{
			Debug.Log("not meet barri");
			if (playerIsUpperThanEnemy == 1)
			{
				player = GameObject.FindObjectOfType<PlayerController>();
				target = player.transform;
				if (target == null)
					Debug.Log("nooob target");
				distance = Vector2.Distance(target.transform.position, transform.position);
			}
			else if (playerIsUpperThanEnemy == 2)
			{
				target.position = new Vector2(5.5f, transform.position.y);
			}
			else if (playerIsUpperThanEnemy == 0)
			{
				target.position = new Vector2(-5.7f, transform.position.y);
>>>>>>> origin/master
			}
		}
		else
		{
<<<<<<< HEAD
			//부수는 중이면 공격on 나머지 off
			IsAttacking = true;
			IsMove = false;
			distance = Vector2.Distance(Target, transform.position);

=======
			//Debug.Log(attackCd);

			IsAttacking = true;
>>>>>>> origin/master
		}
	}

	void MoveToTarget()
	{
		if (IsMove && !IsAttacking)
		{
<<<<<<< HEAD
			if (Target.x > transform.position.x)
			{
				//transform.localScale = new Vector3(1f, 1f, 1f);
				IsLeft = true;
				transform.position = Vector2.MoveTowards(transform.position, Target, activeMoveSpeed * Time.deltaTime);
=======
			if (target.position.x > transform.position.x)
			{
				//transform.localScale = new Vector3(1f, 1f, 1f);
				IsLeft = true;
				transform.position = Vector2.MoveTowards(transform.position, target.transform.position, activeMoveSpeed * Time.deltaTime);
>>>>>>> origin/master
			}
			else
			{
				//transform.localScale = new Vector3(-1f, 1f, 1f);
				IsLeft = false;
<<<<<<< HEAD
				transform.position = Vector2.MoveTowards(transform.position, Target, activeMoveSpeed * Time.deltaTime);
=======
				transform.position = Vector2.MoveTowards(transform.position, target.transform.position, activeMoveSpeed * Time.deltaTime);
>>>>>>> origin/master
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
<<<<<<< HEAD
			if (!col.gameObject.GetComponent<Barricade>().broken)
			{
			
				//부숨
				attackOrder = 2;
				braking = false;
				IsMove = true;
	
			}
			else
			{
				//못부숨
				attackOrder = 1;
				braking = true;
				IsMove = false;
			}
			
			
=======
			//braking = true;
			//IsMove = false;
			Debug.Log("meet barricade1");
			if (col.gameObject.GetComponent<Barricade>().broken)
			{
				braking = false;
				IsMove = true;
			}
			else
			{
				braking = true;
				IsMove = false;
				Debug.Log("meet barricade1");
			}

>>>>>>> origin/master
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
<<<<<<< HEAD
	}
	void OnTriggerExit2D(Collider2D col)
	{
		if (col.gameObject.tag == "barricade1")
		{
			if (col.gameObject.GetComponent<Barricade>().broken)
			{
				attackOrder = 2;
				IsMove = true;
				//밀려남
				//Debug.Log("exit barricade");
				braking = false;
			}
		}
=======
		if (col.gameObject.tag == "barricade1")
		{
			braking = true;
			IsMove = false;
			Debug.Log("meet barricade1");

		}

	}
	public void SetToTargetBraking(Collider2D col)
	{
		Debug.Log("set to breaking");
		//Collider2D col = Physics2D.OverlapCircle(transform.position, 2.0f);
		target.position = col.transform.position;

>>>>>>> origin/master
	}

	public void MeleeAttack()
	{
<<<<<<< HEAD
		if (IsAttacking&&attackCd < 0)
=======
		if (IsAttacking && attackCd < 0)
>>>>>>> origin/master
		{
			if (attackdelay > 0)
			{
				IsMove = false;
				attackdelay -= Time.deltaTime;
			}
			else
			{
<<<<<<< HEAD

=======
>>>>>>> origin/master
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
<<<<<<< HEAD
					}
				}
			}
		}
	}
	public void DashAttack()
	{
		if (IsAttacking&&dashCd < 0)
		{
			if (dashdelay > 0)
			{

				IsMove = false;
				dashdelay -= Time.deltaTime;
			}
			else
			{
				rb.AddForce(new Vector2(dashpower, 0), ForceMode2D.Impulse);
				attackTrigger.enabled = true;
				if (timer > 0)
				{
					timer -= Time.deltaTime;
				}
				else
				{
					//Debug.Log("sibal?");
					attackTrigger.enabled = false;
					dashCd = getdashCd;
					dashdelay = getdashdelay;
					timer = 0.3f;
					if (!braking)
					{
						//Debug.Log("shall we moving me ?");
						IsMove = true;
						IsAttacking = false;
					}
				}
			}
		}
	}

	public void CheckCondition()
	{
		if (attackCd >= 0||dashCd>=0)
		{
			attackCd -= Time.deltaTime;
			dashCd -= Time.deltaTime;
			IsAttacking = false;
=======
					}   // Debug.Log("attack end");
				}
				// Debug.Log("melee attack end");
			}
		}
	}
	public void CheckCondition()
	{
		if (attackCd >= 0)
		{
			attackCd -= Time.deltaTime;
>>>>>>> origin/master
		}
		else
		{
			if (condition > distance)
<<<<<<< HEAD
			{
				//Debug.Log("attack ok?");
				IsAttacking = true;
			}
=======
				IsAttacking = true;
>>>>>>> origin/master
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

	IEnumerator HitEffect()
	{
		Renderer rend = GetComponent<Renderer>();

		rend.material.color = Color.red;
		yield return new WaitForSeconds(0.04f);
		rend.material.color = Color.white;
		yield return new WaitForSeconds(0.04f);

	}
<<<<<<< HEAD

=======
>>>>>>> origin/master
}
