using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [System.Serializable] // To see wave structure inside of Unity
    public class Wave
    {
        public Enemy[] enemies;
        public int enemyCount;
        public float periodBetweenSpawns;
    }

    // Public
    public Wave[] waves;
    public Transform[] spawnPoints;
    public float periodBetweenWaves;

    // Private
    private Wave currentWave;
    private int currentWaveIndex;
    private Transform player;
    private bool finishedSpawning;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(StartNextWave(currentWaveIndex));
    }

    private void Update()
    {
        if (finishedSpawning == true && 
        GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            finishedSpawning = false;
            if (currentWaveIndex + 1 < waves.Length)
            {
                currentWaveIndex++;
                StartCoroutine(StartNextWave(currentWaveIndex));
            }
            else
            {
                // Temporary for testing purposes
                Debug.Log("Game FInished!");
            }
        }
    }

    IEnumerator StartNextWave(int index)
    {
        yield return new WaitForSeconds(periodBetweenWaves);
        StartCoroutine(SpawnWave(index));
    }

    IEnumerator SpawnWave(int index)
    {
        currentWave = waves[index];

        for (int i = 0; i < currentWave.enemyCount; i++)
        {
            if (player == null)
            {
                yield break;
            }

            Enemy randomEnemy = currentWave.enemies[Random.Range(0, currentWave.enemies.Length)];
            Transform randomSpot = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(randomEnemy, randomSpot.position, randomSpot.rotation);

            if (i == currentWave.enemyCount - 1)
            {
                finishedSpawning = true;
            }
            else
            {
                finishedSpawning = false;
            }
            yield return new WaitForSeconds(currentWave.periodBetweenSpawns);
        }
    }

}
