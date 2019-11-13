using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : Enemy
{
    // Public
    public float stopDistance;
    public Transform shotPoint;
    public GameObject flyingEnemyProjectile;

    // Private
    private float attackPeriod;
    private Animator flyingEnemyAnimation;

    // Override the Start from Enemy script
    public override void Start()
    {
        // Call Start function from Enemy script
        base.Start();
        flyingEnemyAnimation = GetComponent<Animator>();
    }

    private void Update()
    {
        if (player != null)
        {
            if (Vector2.Distance(transform.position, player.position) > stopDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, enemySpeed * Time.deltaTime);
            }

            if (Time.time >= attackPeriod)
            {
                attackPeriod = Time.time + periodBetweenAttacks;
                flyingEnemyAnimation.SetTrigger("Attack");
            }
        }
    }

    public void FlyingEnemyAttack()
    {
        // Assign the direction of enemy to player's position
        Vector2 enemyShootingDirection = player.position - shotPoint.position;
        // The angle the enemy must rotate around to face the player
        float angle = Mathf.Atan2(enemyShootingDirection.y, enemyShootingDirection.x) * Mathf.Rad2Deg;
        // Convert angle to Unity rotation 
        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        // Apply the rotation to shooting point 
        shotPoint.rotation = rotation;
        // Create a projectile
        Instantiate(flyingEnemyProjectile, shotPoint.position, shotPoint.rotation);
    }
}
