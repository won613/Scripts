using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeAttack : MonoBehaviour {

	private int attackOrder;
	private float attackdelay;
	private float attackCd;
	//public int whatmonsetertype;

	public float getdelay;
	public float getCd;

	public float condition;
	public float distance;
	public Collider2D attackTirgger;
	// Use this for initialization
	void Start () {
		attackdelay = getdelay;
		attackCd = 0.0f;/*
		if (whatmonsetertype == 1)
		{
			attackOrder = 1;
		}*/
	}


	public void MeleeAttack()
	{
		//if 거리제한
		if (attackCd > 0)
		{
			attackCd -= Time.deltaTime;
		}
		else
		{
			if (distance < condition)
			{
				if (attackdelay > 0)
				{
					attackdelay -= Time.deltaTime;
				}
				else
				{
					//attacktrigger.enabled = true;
					attackdelay = 0.3f;
					if (attackdelay > 0)
					{
						attackdelay -= Time.deltaTime;
					}
					else
					{
						//attackTirgger.enabled = false;
						attackCd = getCd;
						attackdelay = getdelay;
					}
				}
			}
		}

	}
	public void CdManger()
	{
		if (attackCd > 0)
			attackCd -= Time.deltaTime;
	}
}
