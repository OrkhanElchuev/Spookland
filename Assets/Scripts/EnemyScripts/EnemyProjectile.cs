using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    // Public
    public float projectileSpeed;
    public int damage;
    public GameObject destroyEffect;

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
        if ((Vector2)transform.position == targetPosition)
        {
            Instantiate(destroyEffect, transform.position, Quaternion.identity);
            // Destroy projectile
            Destroy(gameObject);
        } 
        else 
        {
            // If distance between projectile and player is not equal continue moving towards player
            transform.position = Vector2.MoveTowards(transform.position, targetPosition,
             projectileSpeed * Time.deltaTime);
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
