using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyModularization : MonoBehaviour {


	public float Hp;
	public float speed;

	public int MonsterType;  // 1= normal , 2= Range



	//공용	
	public float NormalCondition; // 조건
	public float NormalAttackDelay;
	public float NormalAttackCd;
	public Collider2D NormalAttackTrigger;
	//range 추가
	public float RangeCondition;
	public float RangeAttackDelay;
	public float RangeAttackCd;
	public Transform FirePoint;
	public GameObject EnemyBullet;
	//third
	public float nullcondition;
//	public string DieName;


	//private bool isleft; // move에서 direction 체크
	private float distance; // move에서 거리체크
	private bool MeetPlayer; // move에서 player와 만남을 체크
	private Animator myAnim;


	public EnemyMeleeAttack MeleeAttack;
	public EnemyMove Move;
	public EnemyRangeAttack RangeAttack;
	public PlayerController Player;
	public GameObject bulletEffect;




	//develop static num
	public float GetDamage;
	private float MonseterScale;



	// Use this for initialization
	void Start() {
		Init();
		//var com = GetComponent("EnemyRangeAttack");
	}

	// Update is called once per frame
	void Update() {
		WherePlayer(); // condition을 위한 player 위치 확인 + 플립함수
		Move.FrameMove();
		if (MeetPlayer)
		{
			MeleeAttack.MeleeAttack();
			if(MonsterType==2)
			RangeAttack.ShootBullet();
		}
		DieCheck();
		CdManger();
	
	}
	void CdManger()
	{
		MeleeAttack.CdManger();
		if(MonsterType==2)
		RangeAttack.CdManger();
	}




	void WherePlayer()
	{
		Debug.Log("where Player?");
		Player = GameObject.FindObjectOfType<PlayerController>();//player transform 할당
		Move.Player = Player;
	
		MeetPlayer = Move.MeetPlayer(); // player랑 같은층이면 true , 아니면 false
		distance = Vector2.Distance(Player.transform.position, transform.position);//player distance 체크
		MeleeAttack.distance = distance;
		RangeAttack.distance = distance;
		if (Move.IsLeft)
		{
			transform.localScale = new Vector3(1f+ MonseterScale, 1f+MonseterScale, 1f);
		}
		else
			transform.localScale = new Vector3(-1f+ MonseterScale, 1f+ MonseterScale, 1f);
		RangeAttack.isleft = Move.IsLeft;
	}
	void DieCheck()
	{
		if (MonsterType == 3)
		{ }
		else
		{
			if (Hp <= 0)
			{
				myAnim.SetBool("die", true);
			}
			if (this.myAnim.GetCurrentAnimatorStateInfo(0).IsName("Zombie_die"))
			{
				Destroy(gameObject);
			}
		}
	}

	void Init()
	{
		Debug.Log("Init ...");
		myAnim = GetComponent<Animator>();
		MeetPlayer = false;
		InitMove();
		InitAttack();
		if (MonsterType == 2)
			InitRange();
		MonseterScale = Random.Range(-0.1f, 0.5f);
	}






	void InitMove()
	{
		Move.activeMoveSpeed = speed;
	}
	void InitAttack()
	{
		MeleeAttack.attackTirgger = NormalAttackTrigger; // 근접공격 위치
		MeleeAttack.getdelay = NormalAttackDelay; // 근접공격 delay
		MeleeAttack.getCd = NormalAttackCd; // 근접공격 cool down , after delay
		MeleeAttack.condition = NormalCondition; // 근접공격 성립 거리

	}
	void InitRange()
	{
		RangeAttack.getdelay = RangeAttackDelay; // 원거리공격 delay
		RangeAttack.getCd = RangeAttackCd; // 원거리공격 cool down, after delay
		RangeAttack.firePoint = FirePoint; // 원거리공격 start point
		RangeAttack.EnemyBullet = EnemyBullet; // 원거리공격 인스턴스화
		RangeAttack.condition = RangeCondition; // 원거리공격 성립 거리
	}


	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Bullet")
		{
			Hp -= GetDamage;
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
}
