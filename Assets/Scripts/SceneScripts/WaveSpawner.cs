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
    public GameObject bossEnemy;
    public Transform bossSpawnPoint;
    public GameObject bossHealthBar;

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
        SpawnEnemies();
    }

    // Handle wave spawning
    private void SpawnEnemies()
    {
        // Check if current wave is over
        if (finishedSpawning == true &&
            GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            finishedSpawning = false;
            // Check if there are more waves left
            if (currentWaveIndex + 1 < waves.Length)
            {
                // Increment the number of wave and Start next wave
                currentWaveIndex++;
                StartCoroutine(StartNextWave(currentWaveIndex));
            }
            else
            {
                // Spawn boss enemy at last wave
                Instantiate(bossEnemy, bossSpawnPoint.position, bossSpawnPoint.rotation);
                // Enable health bar of boss on the bottom of screen
                bossHealthBar.SetActive(true);
            }
        }
    }

    // Start the next wave after a delay
    IEnumerator StartNextWave(int index)
    {
        yield return new WaitForSeconds(periodBetweenWaves);
        StartCoroutine(SpawnWave(index));
    }

    // Spawn a wave
    IEnumerator SpawnWave(int index)
    {
        // Set the current wave value
        currentWave = waves[index];
        // Loop through the required amount of enemies for current wave and instantiate them
        for (int i = 0; i < currentWave.enemyCount; i++)
        {
            // Check if player exists
            if (player == null)
            {
                yield break;
            }
            // Choose a random enemy among the list of enemies provided for current wave
            Enemy randomEnemy = currentWave.enemies[Random.Range(0, currentWave.enemies.Length)];
            // Choose a random spawn point among the list of spawn points provided
            Transform randomSpot = spawnPoints[Random.Range(0, spawnPoints.Length)];
            // Instantiate the enemy in a random location
            Instantiate(randomEnemy, randomSpot.position, randomSpot.rotation);
            // Check if all enemies are killed or not
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
