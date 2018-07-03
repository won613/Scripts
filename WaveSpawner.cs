using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {

    public int remainEnemy;
    public int spawnPointSelect;
    public Transform spawnPosition1;
    public Transform spawnPosition2;
    public Transform spawnPosition3;
    public Transform spawnPosition4;
    public GameObject enemy;
    public bool hatchOpened;

    // Use this for initialization
    void Start () {
        hatchOpened = false;
        StartCoroutine(Wave1());
	}
	
	// Update is called once per frame
	void Update () {
		if (hatchOpened == true)
        {
            StartCoroutine(Wave2());
            hatchOpened = false;
        }
	}

    IEnumerator Wave1()
    {
        remainEnemy = 100;
        

        while (remainEnemy > 0)
        {
            spawnPointSelect = Random.Range(1, 3);

            if (spawnPointSelect == 1)
                Instantiate(enemy, spawnPosition1.transform.position, transform.rotation);
            if (spawnPointSelect == 2)
                Instantiate(enemy, spawnPosition2.transform.position, transform.rotation);

            remainEnemy--;

            yield return new WaitForSeconds(2.5f);
        }
    }

    IEnumerator Wave2()
    {
        remainEnemy = 100;


        while (remainEnemy > 0)
        {
            spawnPointSelect = Random.Range(1, 3);

            if (spawnPointSelect == 1)
                Instantiate(enemy, spawnPosition3.transform.position, transform.rotation);
            if (spawnPointSelect == 2)
                Instantiate(enemy, spawnPosition4.transform.position, transform.rotation);

            remainEnemy--;

            yield return new WaitForSeconds(2.5f);
        }
    }
}
