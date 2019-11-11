using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float projectileLifeTime;
    public float projectileSpeed;
    public GameObject explosion;

    private void Start()
    {
        // Call function after a delay
        Invoke("DestroyProjectile", projectileLifeTime);
    }

    private void Update()
    {
        MoveProjectile();
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
