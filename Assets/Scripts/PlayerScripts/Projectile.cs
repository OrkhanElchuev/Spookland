using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Public
    public float projectileLifeTime;
    public float projectileSpeed;
    public int projectileDamage;
    public GameObject projectileSoundEffect;
    public GameObject explosion;
    public GameObject shootingEffect;

    private void Start()
    {
        // Call function after a delay
        Invoke("DestroyProjectile", projectileLifeTime);
        // Play the shooting sound effect when projectile is created
        Instantiate(projectileSoundEffect, transform.position, transform.rotation);
        // Instantiate a particle effect each time player shoots
        Instantiate(shootingEffect, transform.position, transform.rotation);
    }

    private void Update()
    {
        MoveProjectile();
    }

    // Handle collision with objects
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if item of collision is enemy
        if (collision.tag == "Enemy")
        {
            // Deal damage to enemy
            collision.GetComponent<Enemy>().TakeDamage(projectileDamage);
            DestroyProjectile();
        }
        // Check if item of collision is boss enemy
        if (collision.tag == "Boss")
        {
            collision.GetComponent<Boss>().TakeDamage(projectileDamage);
            DestroyProjectile();
        }
    }

    private void MoveProjectile()
    {
        // Move projectile frame rate independently 
        transform.Translate(Vector2.up * projectileSpeed * Time.deltaTime);
    }

    private void DestroyProjectile()
    {
        // Spawn explosion effect
        Instantiate(explosion, transform.position, Quaternion.identity);
        // Destroy projectile
        Destroy(gameObject);
    }
}
