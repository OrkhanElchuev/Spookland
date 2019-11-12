using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterEnemy : Enemy
{
    public float stopDistance;
    public float attackSpeed;
    private float attackPeriod;

    private void Update()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        // Check if player exists
        if (player != null)
        {
            // Check the distance between enemy and player
            if (Vector2.Distance(transform.position, player.position) > stopDistance)
            {
                // Smoothly move towards player if distance is too far for attacking
                transform.position = Vector2.MoveTowards(transform.position,
                 player.position, enemySpeed * Time.deltaTime);
            }
            else
            {
                if (Time.time >= attackPeriod)
                {
                    // Attack the player if distance allows to do so
                    StartCoroutine(Attack());
                    attackPeriod = Time.time + periodBetweenAttacks;
                }
            }
        }
    }

    // Handle enemy attack
    IEnumerator Attack()
    {
        // Deal damage
        player.GetComponent<Player>().TakeDamage(damageAmount);
        // Assign positions
        Vector2 originalPosition = transform.position;
        Vector2 targetPosition = player.position;

        float percent = 0;
        while (percent <= 1)
        {
            percent += Time.deltaTime * attackSpeed;
            float formula = (-Mathf.Pow(percent, 2) + percent) * 4;
            // Move swiftly towards player 
            transform.position = Vector2.Lerp(originalPosition, targetPosition, formula);
            yield return null;
        }
    }
}
