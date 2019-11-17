using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    // Public
    public int bossHealth;
    public Enemy[] enemies;
    public float spawnOffset;
    public int bossDamage;


    // Private
    private int halfHealth;
    private Animator bossAnimator;

    private void Start()
    {
        halfHealth = bossHealth / 2;
        bossAnimator = GetComponent<Animator>();
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

    // Handle damage
    public void TakeDamage(int damageAmount)
    { 
        bossHealth -= damageAmount;
        if (bossHealth <= 0)
        {
            Destroy(this.gameObject);
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
