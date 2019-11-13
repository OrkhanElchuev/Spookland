using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Public
    public float projectileLifeTime;
    public float projectileSpeed;
    public GameObject explosion;
    public int porjectileDamage;

    private void Start()
    {
        // Call function after a delay
        Invoke("DestroyProjectile", projectileLifeTime);
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
            collision.GetComponent<Enemy>().TakeDamage(porjectileDamage);
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
