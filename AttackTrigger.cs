using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrigger : MonoBehaviour {

	public float dmg;
	void OnTriggerEnter2D(Collider2D col)
	{

		if (col.gameObject.tag == "Player")
		{
			Debug.Log("hit player");
		}
		if (col.gameObject.tag == "barricade1")
		{
			Debug.Log("aa");
			col.SendMessage("ApplyDamage", dmg);
		}

	}

		if (col.tag == "Player")
		{
			Debug.Log("hit player");
		}
	}

}
