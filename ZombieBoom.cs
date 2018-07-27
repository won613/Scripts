﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBoom : MonoBehaviour {


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
    public GameObject boomTrigger;
	private Vector2 Target;
   // private Animator myAnim;
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
        //myAnim = GetComponent<Animator>();
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
		Target = new Vector2(1f, 1f);
		//Debug.Log(target.transform.position);

	}

    // Update is called once per frame
    void Update()
    {
        DieCheck();
        FindPlayer();
        SetToTarget();
        flip();
        CheckCondition();
        MeleeAttack();
        MoveToTarget();
		Debug.DrawLine(transform.position, Target);
		Debug.Log(IsAttacking);
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
		if (!braking)
		{
			Debug.Log("not meet barri");
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
			IsAttacking = true;
		}
    }

    void MoveToTarget()
    {
        if (IsMove && !IsAttacking)
        {
            if (Target.x > transform.position.x)
            {
                IsLeft = true;
                transform.position = Vector2.MoveTowards(transform.position, Target, activeMoveSpeed * Time.deltaTime);
            }
            else
            {
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
			braking = true;
			IsMove = false;
			Debug.Log("meet barricade1");
			
		}

	}


    public void MeleeAttack()
    {
        if (IsAttacking&&attackCd<0)
        {
				if (attackdelay > 0)
				{
				Debug.Log("seeeex");
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
					Debug.Log("third sex");
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
			Boom();
			Destroy(gameObject);
			StopAllCoroutines();
		}

    }
    public void flip()
    {
        if (IsLeft)
            transform.localScale = new Vector3(1f + MonsterScale, 1f + MonsterScale, 1f);
        else
            transform.localScale = new Vector3(-(1f + MonsterScale), 1f + MonsterScale, 1f);

    }
	public void Boom()
	{
		Instantiate(boomTrigger, transform.position,transform.rotation);
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
