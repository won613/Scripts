using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmRotation : MonoBehaviour {

    public float speed = 10f;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);

        if(angle > 0f && angle < 100f || angle < 0f && angle > -90f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        if(angle > 100f && angle < 180f || angle < -90f && angle > -180f)
        {
            transform.localScale = new Vector3(1f, -1f, 1f);
        }
	}
}
