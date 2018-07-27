using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieNormal : MonoBehaviour {


	public PlayerController player;
	public float activeMoveSpeed;
	public float hp;
	public GameObject bulletEffect;

	private int attackOrder;
	private float attackdelay;
	private float attackCd;
	public float getdelay;
	public float getCd;


	public float condition;
	private float distance;
	public Collider2D attackTrigger;
<<<<<<< HEAD
	//private Transform target;
	private Vector2 Target;
=======
	private Transform target;
>>>>>>> origin/master
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
		IsMove = true;
		IsAttacking = false;
		attackdelay = getdelay;
		attackCd = 0.0f;
		distance = 10;
		timer = 0.3f;
		MonsterScale = Random.Range(-0.1f, 0.5f);
		attackTrigger.enabled = false;
		braking = false;
<<<<<<< HEAD
		Target = new Vector2(1f, 1f);

=======
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
		MeleeAttack();
		MoveToTarget();
<<<<<<< HEAD
		Debug.DrawLine(transform.position, Target);
		//Debug.Log(IsAttacking);
	}
	void FindPlayer()
	{
		player = FindObjectOfType<PlayerController>();
=======
		Debug.DrawLine(transform.position, target.position);
		Debug.Log(IsAttacking);
	}
	void FindPlayer()
	{
>>>>>>> origin/master
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
		if (!braking)
		{
<<<<<<< HEAD
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
				//Debug.Log("???");
				Target = new Vector2(-5.7f, transform.position.y);
=======
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
=======
			//Debug.Log(attackCd);

>>>>>>> origin/master
			IsAttacking = true;
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
			//Debug.Log("meet barricade1");
=======
			//braking = true;
			//IsMove = false;
			Debug.Log("meet barricade1");
>>>>>>> origin/master
			if (col.gameObject.GetComponent<Barricade>().broken)
			{
				braking = false;
				IsMove = true;
			}
			else
			{
				braking = true;
				IsMove = false;
<<<<<<< HEAD
=======
				Debug.Log("meet barricade1");
>>>>>>> origin/master
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
<<<<<<< HEAD

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

	}
>>>>>>> origin/master

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
<<<<<<< HEAD
					}  
				}
=======
					}   // Debug.Log("attack end");
				}
				// Debug.Log("melee attack end");
>>>>>>> origin/master
			}
		}
	}
	public void CheckCondition()
	{
		if (attackCd >= 0)
		{
			attackCd -= Time.deltaTime;
		}
		else
		{
			if (condition > distance)
				IsAttacking = true;
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
<<<<<<< HEAD
=======
		//braking = true;
>>>>>>> origin/master
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
	/*
		public PlayerController player;
		public float activeMoveSpeed;
		public float hp;
		public GameObject bulletEffect;


		private int attackOrder;
		private float attackdelay;
		private float attackCd;
		public float getdelay;
		public float getCd;


		public float condition;
		private float distance;
		public Collider2D attackTrigger;

		private Transform target;
		private Animator myAnim;
		private int playerIsUpperThanEnemy;
		private bool IsLeft;
		private bool IsMove;
		private bool IsAttacking;
		private float timer;

		private float MonsterScale;

		// Use this for initialization
		void Start () {
			myAnim = GetComponent<Animator>();
			playerIsUpperThanEnemy = 0;
			IsLeft = true;
			IsMove = true;
			IsAttacking = false;
			attackdelay = getdelay;
			attackCd = 0.0f;
			distance = 10;
			timer = 0.3f;
			MonsterScale = Random.Range(-0.1f, 0.5f);
			attackTrigger.enabled = false;
		}

		// Update is called once per frame
		void Update () {
			DieCheck();

			FindPlayer();
			SetToTarget();
			flip();
			CheckCd();
			MeleeAttack();
			MoveToTarget();

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
				//Player is same floor than Monster
				playerIsUpperThanEnemy = 1;
			}
		}
		void SetToTarget()
		{
			if (playerIsUpperThanEnemy == 1)
			{
				player = GameObject.FindObjectOfType<PlayerController>();
				target = player.transform;
				distance = Vector2.Distance(player.transform.position, transform.position);
			}
			else if (playerIsUpperThanEnemy == 2)
			{
				target.position = new Vector2(5.5f, transform.position.y);
			}
			else if (playerIsUpperThanEnemy == 0)
			{
				target.position = new Vector2(-5.7f, transform.position.y);
			}
		}

		void MoveToTarget()
		{
			if (IsMove&&!IsAttacking)
			{
				if (target.position.x > transform.position.x)
				{
					//transform.localScale = new Vector3(1f, 1f, 1f);
					IsLeft = true;
					transform.position = Vector2.MoveTowards(transform.position, target.transform.position, activeMoveSpeed * Time.deltaTime);
				}
				else
				{
					//transform.localScale = new Vector3(-1f, 1f, 1f);
					IsLeft = false;
					transform.position = Vector2.MoveTowards(transform.position, target.transform.position, activeMoveSpeed * Time.deltaTime);
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
			if (col.gameObject.tag == "barricade1")
			{
				Debug.Log("bbbbbb");
				IsAttacking = true;
				MeleeAttack();
			}

		}
		public void MeleeAttack()
		{
			if (IsAttacking)
			{
				if (attackdelay > 0)
				{
					IsMove = false;
					attackdelay -= Time.deltaTime;
				}
				else
				{
					attackTrigger.enabled = true;
					// timer = 0.3f;
					if (timer > 0)
					{
						timer -= Time.deltaTime;
					}
					else
					{
						attackTrigger.enabled = false;
						attackCd = getCd;
						attackdelay = getdelay;
						IsMove = true;
						IsAttacking = false;
						// Debug.Log("attack end");
					}
					// Debug.Log("melee attack end");
				}
			}
		}
		public void CheckCd()
		{
			if (attackCd > 0)
			{
				attackCd -= Time.deltaTime;
			}
			else
			{
				if (condition > distance)
					IsAttacking = true;
			}
		}
		public void DieCheck()
		{
			if(hp<=0)
			{
				myAnim.SetBool("die", true);
			}
			if(this.myAnim.GetCurrentAnimatorStateInfo(0).IsName("Zombie_die"))
			{
				Destroy(gameObject);
			}
		}
		public void flip()
		{
			if (IsLeft)
				transform.localScale = new Vector3(1f+MonsterScale, 1f+MonsterScale, 1f);
			else
				transform.localScale = new Vector3(-(1f + MonsterScale), 1f+MonsterScale, 1f);

		}
		IEnumerator HitEffect()
		{
			Renderer rend = GetComponent<Renderer>();

			rend.material.color = Color.red;
			yield return new WaitForSeconds(0.04f);
			rend.material.color = Color.white;
			yield return new WaitForSeconds(0.04f);

		}*/
}
