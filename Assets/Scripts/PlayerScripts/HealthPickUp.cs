using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
    // Public
    public int healingAmount;
    public GameObject pickupEffect;
   
    Player playerScript;

    private void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Handle collision of player with health pick up
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if collision object is player
        if (collision.tag == "Player")
        {
            Instantiate(pickupEffect, transform.position, transform.rotation);
            playerScript.IncreaseHealth(healingAmount);
            // Destroy health pick up
            Destroy(gameObject);
        }
    }
}
