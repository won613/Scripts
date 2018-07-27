using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretRotation : MonoBehaviour {

	public float speed = 10f;

	// Update is called once per frame
	void Update () {
		FindClosestEnemy();

	}

	void FindClosestEnemy()
	{
		float distanceToClosestEnemy = Mathf.Infinity;
		Enemy closestEnemy = null;
		Enemy[] allEnemies = GameObject.FindObjectsOfType<Enemy>();

		foreach (Enemy currentEnemy in allEnemies)
		{
			float distanceToEnemy = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;
			if (distanceToEnemy < distanceToClosestEnemy)
			{
				distanceToClosestEnemy = distanceToEnemy;
				closestEnemy = currentEnemy;
			}
		}

		if (closestEnemy != null)
		{
			Vector2 direction = closestEnemy.transform.position - transform.position;
			float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
			Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
			transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);

			if (angle > 0f && angle < 100f || angle < 0f && angle > -90f)
			{
				transform.localScale = new Vector3(1f, 1f, 1f);
			}

			if (angle > 100f && angle < 180f || angle < -90f && angle > -180f)
			{
				transform.localScale = new Vector3(1f, -1f, 1f);
			}
		}
		
	}
	

}
