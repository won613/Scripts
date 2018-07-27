using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public static class Rigidbody2DExtension
{
	public static void AddExplosionForce(this Rigidbody2D body, float explosionForce, Vector3 explosionPosition, float explosionRadius)
	{
		var dir = (body.transform.position - explosionPosition);
		float wearoff = 1 - (dir.magnitude / explosionRadius);
		body.AddForce(dir.normalized * explosionForce * wearoff);
	}

	public static void AddExplosionForce(this Rigidbody2D body, float explosionForce, Vector3 explosionPosition, float explosionRadius, float upliftModifier)
	{
		var dir = (body.transform.position - explosionPosition);
		float wearoff = 1 - (dir.magnitude / explosionRadius);
		Vector3 baseForce = dir.normalized * explosionForce * wearoff;
		body.AddForce(baseForce);

		float upliftWearoff = 1 - upliftModifier / explosionRadius;
		Vector3 upliftForce = Vector2.up * explosionForce * upliftWearoff;
		body.AddForce(upliftForce);
	}
}


public class BoomTrigger : MonoBehaviour {
	public float destroytime;
	public 
	// Use this for initialization
	void Start () {
		//Boom();
		Destroy(this.gameObject, destroytime);
	}
	private void Boom()
	{
		Collider2D[] List = Physics2D.OverlapCircleAll(transform.position, 2f);

		foreach (Collider2D hit in List)
		{
			Rigidbody2D rigid = hit.gameObject.GetComponent<Rigidbody2D>();
			if (rigid != null)
			{
				Debug.Log("BOOM RUNNING");
				rigid.AddExplosionForce(100f,this.transform.position, 5f,10f);
				//Rigidbody2DExtension.AddExplosionForce(rigid, 2f, transform.position, 2f);
			}
		}
	}
	private void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "Player")
		{

			Debug.Log("hit player from Boom");
		}
	}
	



}
