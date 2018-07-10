using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{

    public int remainEnemy;
    private int spawnPointSelect;
    public int enemySelect;
    public Transform spawnPosition1;
    public Transform spawnPosition2;
    public Transform spawnPosition3;
    public Transform spawnPosition4;
    public GameObject enemy_normal;
    public GameObject enemy_fast;
    public GameObject enemy_range;
    public GameObject enemy_tanker;
    public bool hatchOpened;

    // Use this for initialization
    void Start()
    {

        hatchOpened = false;
        StartCoroutine(Wave1());
    }

    // Update is called once per frame
    void Update()
    {
        if (hatchOpened == true)
        {
            StartCoroutine(Wave2());
            hatchOpened = false;
        }
    }

    IEnumerator Wave1()
    {
        remainEnemy = 200;


        while (remainEnemy > 0)
        {
            spawnPointSelect = Random.Range(1, 3);

            if (spawnPointSelect == 1)
            {
                enemySelect = Random.Range(1, 5);

                if (enemySelect == 1)
                    Instantiate(enemy_normal, spawnPosition1.transform.position, transform.rotation);

                if (enemySelect == 2)
                    Instantiate(enemy_fast, spawnPosition1.transform.position, transform.rotation);

                if (enemySelect == 3)
                    Instantiate(enemy_range, spawnPosition1.transform.position, transform.rotation);

                if (enemySelect == 4)
                    Instantiate(enemy_tanker, spawnPosition1.transform.position, transform.rotation);
            }

            if (spawnPointSelect == 2)
            {
                enemySelect = Random.Range(1, 5);

                if (enemySelect == 1)
                    Instantiate(enemy_normal, spawnPosition2.transform.position, transform.rotation);

                if (enemySelect == 2)
                    Instantiate(enemy_fast, spawnPosition2.transform.position, transform.rotation);

                if (enemySelect == 3)
                    Instantiate(enemy_range, spawnPosition2.transform.position, transform.rotation);

                if (enemySelect == 4)
                    Instantiate(enemy_tanker, spawnPosition2.transform.position, transform.rotation);
            }

            remainEnemy--;

            yield return new WaitForSeconds(2.5f);
        }
    }

    IEnumerator Wave2()
    {
        remainEnemy = 200;


        while (remainEnemy > 0)
        {
            spawnPointSelect = Random.Range(1, 3);

            if (spawnPointSelect == 1)
            {
                enemySelect = Random.Range(1, 5);

                if (enemySelect == 1)
                    Instantiate(enemy_normal, spawnPosition3.transform.position, transform.rotation);

                if (enemySelect == 2)
                    Instantiate(enemy_fast, spawnPosition3.transform.position, transform.rotation);

                if (enemySelect == 3)
                    Instantiate(enemy_range, spawnPosition3.transform.position, transform.rotation);

                if (enemySelect == 4)
                    Instantiate(enemy_tanker, spawnPosition3.transform.position, transform.rotation);
            }

            if (spawnPointSelect == 2)
            {
                enemySelect = Random.Range(1, 5);

                if (enemySelect == 1)
                    Instantiate(enemy_normal, spawnPosition4.transform.position, transform.rotation);

                if (enemySelect == 2)
                    Instantiate(enemy_fast, spawnPosition4.transform.position, transform.rotation);

                if (enemySelect == 3)
                    Instantiate(enemy_range, spawnPosition4.transform.position, transform.rotation);

                if (enemySelect == 4)
                    Instantiate(enemy_tanker, spawnPosition4.transform.position, transform.rotation);
            }

            remainEnemy--;

            yield return new WaitForSeconds(2.5f);
        }
    }
}
