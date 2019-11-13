using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    // Public
    public float projectileSpeed;
    public int damage;

    // Private
    private Player playerScript;
    private Vector2 targetPosition;

    private void Start()
    {
        // Initial assignments
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        targetPosition = playerScript.transform.position;
    }

    private void Update()
    {
        MoveProjectile();
    }

    // Handle the movement of projectile
    private void MoveProjectile()
    {
        // Check the distance between projectile and player
        if (Vector2.Distance(transform.position, targetPosition) > 0.2f)
        {
            // If distance between projectile and player is (> 0.2) continue moving towards player
            transform.position = Vector2.MoveTowards(transform.position, targetPosition,
             projectileSpeed * Time.deltaTime);
        }
        else
        {
            // Otherwise destroy projectile 
            Destroy(gameObject);
        }
    }

    // Handle projectile collision
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if projectile collided with player
        if (collision.tag == "Player")
        {
            playerScript.TakeDamage(damage);
            // Destroy projectile
            Destroy(gameObject);
        }
    }
}
