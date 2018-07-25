using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Barricade : MonoBehaviour {

    public Image barriBar;
    public float hp;
    private Animator myAnim;
    public bool broken;
    Collider2D m_collider;


	
    // Use this for initialization
    void Start () {
        myAnim = GetComponent<Animator>();
        broken = false;
        m_collider = GetComponent<Collider2D>();
    }
	
	// Update is called once per frame
	void Update () {
        barriBar.fillAmount = hp / 15;

        if(hp > 15)
        {
            hp = 15;
        }

        if(hp < 0)
        {
            hp = 0;
        }

        if(hp <= 0)
        {
            myAnim.SetBool("broken", true);
            broken = true;
        }
        else
        {
            myAnim.SetBool("broken", false);
            broken = false;
        }
        
    }
	public void ApplyDamage(float damage)
	{
		hp -= damage;
	}
	public bool brokenNow()
	{
			return broken;
	}
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (Input.GetKey(KeyCode.E))
            {
                hp += Time.deltaTime*4f;
            }
        }

    }
          
}
