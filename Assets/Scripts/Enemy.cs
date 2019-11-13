using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Public
    public int enemyHealth;
    public float enemySpeed;
    public float periodBetweenAttacks;
    public int damageAmount;
    [HideInInspector]
    public Transform player;
    public int pickUpChance;
    public GameObject[] pickUps;

    public virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Handle damage and destroy enemy
    public void TakeDamage(int damageAmount)
    {
        enemyHealth -= damageAmount;
        if (enemyHealth <= 0)
        {
            // Generate a random number between 0 and 100
            int randomNum = Random.Range(0, 101);
            // If random number is less than a chance
            if (randomNum < pickUpChance)
            {
                // Generate random pick up among available pick ups
                GameObject randomPickUp = pickUps[Random.Range(0, pickUps.Length)];
                // Instantiate generated pick up
                Instantiate(randomPickUp, transform.position, transform.rotation);
            }
            // Destroy Enemy object
            Destroy(this.gameObject);
        }
    }
}
