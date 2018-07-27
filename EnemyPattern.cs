using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPattern : MonoBehaviour {


	public class Pattern
	{
		public int PatternType; // 1=normal , 2=Range, 3=Dash
		private float attackdelay;
		public bool isleft;
		public float movespeed;
		public float distance; // monseter - player  distance


		public float normalcondition;
		public int attackOrder;

		public float attackCd;
		public float getCd;

		public Collider2D attackTrigger;

		public virtual void SetActive()
		{
			NormalAttack();
		}
	public void NormalAttack()
		{
			
				attackTrigger.enabled = true;
				attackdelay = 0.3f;
				if (attackdelay > 0)
				{
					attackdelay -= Time.deltaTime;
				}
				else
				{
					attackTrigger.enabled = false;
					attackCd = getCd;
					attackdelay =0.3f;
				}
			
		}
	}
	public class RangeAttack : Pattern
	{
		
		public float shotdelay;
		public float shotCd;
		public Transform firePoint;
		public GameObject EnemyBullet;

		public override void SetActive() 
		{
			Fire();
		}
		public void Fire()
		{
			GameObject bullet = (GameObject)Instantiate(EnemyBullet, firePoint.position, firePoint.rotation);
			if (isleft)
				bullet.GetComponent<Rigidbody2D>().velocity = Vector2.left * 10;
			else
				bullet.GetComponent<Rigidbody2D>().velocity = Vector2.right * 10;
		}
	}
	public class DashAttack : Pattern
	{
		public int DashSpeed;
		public float DashDelay;
		public float DashCd;
		public Collider2D DashTrigger;
	}

	public List<Pattern> activePatternList = new List<Pattern>();

	protected virtual void ActiveCheckFrame()
	{
		for (int i = 0; i < activePatternList.Count; i++)
		{
			activePatternList[i].attackCd -= Time.deltaTime;
			if (activePatternList[i].attackCd < 0)
			{
				bool activated = ActivePattern(i,activePatternList[i].PatternType,i);
				if (activated)
				{
					activePatternList[i].attackCd = activePatternList[i].getCd;
				}
			}
		}
		

	}
	protected virtual bool ActivePattern(int idx, int type,int listnum)
	{
		switch (type)
		{
			case 1://근접공격시작
				activePatternList[listnum].SetActive();
				break;
			case 2:
				activePatternList[listnum].SetActive();
				break;
				
		}

		return true;
	}

}
