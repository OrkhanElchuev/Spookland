using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int enemyHealth;
    public float enemySpeed;
    public float periodBetweenAttacks;
    public int damageAmount;
    [HideInInspector]
    public Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Handle damage and destroy enemy
    public void TakeDamage(int damageAmount)
    {
        enemyHealth -= damageAmount;
        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
