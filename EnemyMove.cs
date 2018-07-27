using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {

	public PlayerController Player;
	public float activeMoveSpeed;

	private int playerlsUpperThanEnemy;// 0=PlayerDown, 1=PlayerSame, 2=PlayerUpper
	public bool IsLeft;
	private Transform target;

	// Use this for initialization
	void Start () {
		playerlsUpperThanEnemy = 1;
		IsLeft = true;
	
	}

	public void FrameMove()
	{
		FindPlayer();//플레이어 위치가 위인지 아래인지 확인.
		SetToTarget();//위치에 맞게 타겟설정 ex) 문,유저
		MoveToTarget();//타겟에맞게 이동
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



	public bool MeetPlayer()
	{
		if (playerlsUpperThanEnemy == 1)
			return true;
		else
			return false;
	}

}
