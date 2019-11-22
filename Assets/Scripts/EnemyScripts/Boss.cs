using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    // Public
    public int bossHealth;
    public Enemy[] enemies;
    public float spawnOffset;
    public int bossDamage;
    public GameObject bloodEffect;
    public GameObject deathEffect;

    // Private
    private int halfHealth;
    private Animator bossAnimator;
    private Slider bossHealthBar;
    private SceneFadeTransition sceneFadeTransition;

    private void Start()
    {
        halfHealth = bossHealth / 2;
        bossAnimator = GetComponent<Animator>();
        HandleBossHealthBar();
        sceneFadeTransition = FindObjectOfType<SceneFadeTransition>();
    }

    // Handle the configurations of Boss health bar
    private void HandleBossHealthBar()
    {
        bossHealthBar = FindObjectOfType<Slider>();
        // Set the max value to Boss health
        bossHealthBar.maxValue = bossHealth;
        // set the initial value to Boss health
        bossHealthBar.value = bossHealth;
    }

    // Handle collision of boss with player
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // In case of colliding with player deal damage
        if (collision.tag == "Player")
        {
            collision.GetComponent<Player>().TakeDamage(bossDamage);
        }
    }

    // Execute death particle effect and create a blood on the game field
    private void HandleBossDeathEffects()
    {
        Instantiate(bloodEffect, transform.position, transform.rotation);
        Instantiate(deathEffect, transform.position, transform.rotation);
    }

    // Handle damage
    public void TakeDamage(int damageAmount)
    {
        bossHealth -= damageAmount;
        // Update health bar each time damage is taken
        bossHealthBar.value = bossHealth;
        if (bossHealth <= 0)
        {
            HandleBossDeathEffects();
            Destroy(this.gameObject);
            // Hide the health bar when the boss is dead
            bossHealthBar.gameObject.SetActive(false);
            // When final boss is dead, load Game Won scene
            sceneFadeTransition.LoadScene("GameWon");
        }
        // In case of reaching half health points trigger chasing behaviour
        if (bossHealth <= halfHealth)
        {
            bossAnimator.SetTrigger("FromWalkToRun");
        }

        // Choose random enemy
        Enemy randomEnemy = enemies[Random.Range(0, enemies.Length)];
        // Instantiate enemy away from boss using offset
        Instantiate(randomEnemy, transform.position + new Vector3(spawnOffset, spawnOffset, 0), transform.rotation);
    }
}
