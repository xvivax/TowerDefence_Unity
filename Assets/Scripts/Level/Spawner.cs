using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour {

    public static int enemyAmount;
    public static bool isLevelEnd;

    public Text timer;
    public float timeBetweenWaves;

    public EnemyTemplate[] target;

    private int waveIndex;
    private float startTimeBetweenWaves;

    private void Start()
    {
        enemyAmount = 0;
        isLevelEnd = false;

        waveIndex = -1;
        startTimeBetweenWaves = timeBetweenWaves;

        if (target.Length <= 0)
        {
            Debug.LogError("Array is not set up!");
            return;
        }

        if (startTimeBetweenWaves <= 0)
        {
            Debug.LogError("Time between waves is not set up!");
            return;
        }
    }

    private void Update()
    {
        if (enemyAmount > 0)
        {
            return;
        }

        if (GameManager.isGamePaused)
        {
            return;
        }

        if (waveIndex + 1 == target.Length)
        {
            isLevelEnd = true;   
            return;
        }

        TimeElapsedChecker();
    }


    private void TimeElapsedChecker()
    {
        if (timeBetweenWaves <= 0)
        {
            StartCoroutine(SpawnWave());
            timeBetweenWaves = startTimeBetweenWaves;

            return;
        }

        timeBetweenWaves -= Time.deltaTime;
        timeBetweenWaves = Mathf.Clamp(timeBetweenWaves, 0, Mathf.Infinity);

        timer.text = string.Format("{0:00.00} sec", timeBetweenWaves);
    }

    private IEnumerator SpawnWave()
    {
        Stats.wave++;
        //For many different enemies
        waveIndex++;

        EnemyTemplate temp = target[waveIndex];

        enemyAmount = temp.count;

        for (int i = 0; i < temp.count; i++)
        {
            while (GameManager.isGamePaused)
            {
                yield return null;
            }

            SpawnEnemy(temp.enemy);
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, enemy.transform.position, Quaternion.identity);
    }

    public int GetEnemyWorth()
    {
        return target[waveIndex].worth;
    }

}
