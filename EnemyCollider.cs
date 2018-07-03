using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollider : MonoBehaviour {

    public Enemy enemy;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "EnemyEach")
        {
            //enemy.myRigidbody.velocity = Vector3.zero;
            Debug.Log("1");
        }

    }
}
