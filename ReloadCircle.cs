using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReloadCircle : MonoBehaviour {

	public Transform LoadingBar;
	public Transform TextIndicator;
	[SerializeField]
	private float currentAmount;
	[SerializeField]
	private float speed;
	public Weapon weapon;

		
	// Update is called once per frame
	void Update () {
		transform.position = Input.mousePosition;
		if (currentAmount < 100)
		{
			currentAmount += speed * Time.deltaTime;
			TextIndicator.GetComponent<Text>().text = ((int)currentAmount).ToString();

		}
		else
		{
			TextIndicator.GetComponent<Text>().text = "DONE!";
		}
		LoadingBar.GetComponent<Image>().fillAmount = currentAmount / 100;
		
	}
}
