using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {
	public PlayerController Player;
	public Rigidbody2D myrigidbody;
	public float activeMoveSpeed;
	public float hp;

	private Animator myAnim;
	private bool breaking;

	public GameObject bulletEffect;
	public Upstair upstair;
	public Downstair downstair;
	private int playerlsUpperThanEnemy;// 0=PlayerDown, 1=PlayerSame, 2=PlayerUpper
	private bool IsLeft;
	
	private Transform target;
	public string diename;

	// Use this for initialization
	void Start () {
		myAnim = GetComponent<Animator>();
		breaking = false;
		playerlsUpperThanEnemy = 1;
		IsLeft = true;
	
	}
	
	// Update is called once per frame
	void Update () {
		Player = GameObject.FindObjectOfType<PlayerController>();
		
		FindPlayer();
		SetToTarget();
		MoveToTarget();


		if (hp <= 0)
		{
			myAnim.SetBool("die", true);
		}
		if (this.myAnim.GetCurrentAnimatorStateInfo(0).IsName("Zombie_die"))
		{
			Destroy(gameObject);
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
	void OnTriggerStay2D(Collider2D col)
	{

		if (col.gameObject.tag == "upstair")
		{
			if (playerlsUpperThanEnemy == 2)
			{
				//x - 11.24
				// y + 4.04
				transform.position = new Vector3(transform.position.x-11.24f,transform.position.y+4.04f, 0f);
			}
		}

		if (col.gameObject.tag == "downstair")
		{
			if (playerlsUpperThanEnemy == 0)
			{
				transform.position = new Vector3(transform.position.x + 11.24f, transform.position.y - 4.02f, 0f);
			}
		}
	}
		void FindPlayer()
	{
		if (Player.transform.position.y > transform.position.y + 2f)
		{
			// Player is up floor than Monster
			playerlsUpperThanEnemy = 2;
		}
		else if (Player.transform.position.y + 2f < transform.position.y)
		{
			//Player is down floor than Monster
			playerlsUpperThanEnemy = 0;
		}
		else
		{
			//Player is same floor than Monster
			playerlsUpperThanEnemy = 1;
		}
	}
	void SetToTarget()
	{
		if (playerlsUpperThanEnemy == 1)
		{
			target = Player.transform;
			
		}
		else if (playerlsUpperThanEnemy == 2)
		{
			target.position = new Vector2(5.5f, transform.position.y);
		
		}
		else if (playerlsUpperThanEnemy == 0)
		{
			target.position = new Vector2(-5.7f, transform.position.y);
		}
	}
	void MoveToTarget()
	{
		if (target.position.x > transform.position.x)
		{
			transform.localScale = new Vector3(1f, 1f, 1f);
			transform.position = Vector2.MoveTowards(transform.position, target.transform.position, activeMoveSpeed * Time.deltaTime);
		}
		else
		{
			transform.localScale = new Vector3(-1f, 1f, 1f);
			transform.position = Vector2.MoveTowards(transform.position, target.transform.position, activeMoveSpeed * Time.deltaTime);
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
