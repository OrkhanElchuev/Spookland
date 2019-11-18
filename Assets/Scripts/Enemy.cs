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
    public int weaponPickUpChance;
    public int healthPickUpChance;
    public GameObject[] pickUps;
    public GameObject healthPickUp;
    public GameObject deathEffect;

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
            InstantiateWeaponPickUp();
            InstantiateHealthPickUp();
            // Execute death particle effect
            Instantiate(deathEffect, transform.position, transform.rotation);
            // Destroy Enemy object
            Destroy(this.gameObject);
        }
    }

    private void InstantiateWeaponPickUp()
    {
        // Generate a random number between 0 and 100
        int randomWeapon = Random.Range(0, 101);
        // If random number is less than a chance
        if (randomWeapon < weaponPickUpChance)
        {
            // Generate random pick up among available pick ups
            GameObject randomPickUp = pickUps[Random.Range(0, pickUps.Length)];
            // Instantiate generated pick up
            Instantiate(randomPickUp, transform.position, transform.rotation);
        }
    }

    private void InstantiateHealthPickUp()
    {
        // Generate a random number between 0 and 100
        int randomHealth = Random.Range(0, 101);
        // If random number is less than a chance
        if (randomHealth < healthPickUpChance)
        {
            // Instantiate health pick up
            Instantiate(healthPickUp, transform.position, transform.rotation);
        }
    }
}
