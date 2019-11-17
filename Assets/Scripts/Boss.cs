using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    // Public
    public int bossHealth;
    public Enemy[] enemies;
    public float spawnOffset;

    // Private
    private int halfHealth;
    private Animator bossAnimator;

    private void Start()
    {
        halfHealth = bossHealth / 2;
        bossAnimator = GetComponent<Animator>();
    }

    // Handle damage and destroy enemy
    public void TakeDamage(int damageAmount)
    {
        bossHealth -= damageAmount;
        if (bossHealth <= 0)
        {
            Destroy(this.gameObject);
        }

        if (bossHealth <= halfHealth)
        {
            bossAnimator.SetTrigger("FromWalkToRun");
        }

        Enemy randomEnemy = enemies[Random.Range(0, enemies.Length)];
        Instantiate(randomEnemy, transform.position + new Vector3(spawnOffset, spawnOffset, 0), transform.rotation);
    }
}
