using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    // Public
    public Weapon weaponToEquip;
    public GameObject pickupEffect;

    // Handle collision 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if colliding object is player
        if (collision.tag == "Player")
        {
            Instantiate(pickupEffect, transform.position, transform.rotation);
            // Equip the new weapon to player
            collision.GetComponent<Player>().ChangeWeapon(weaponToEquip);
            // Destroy weapon on ground
            Destroy(gameObject);
        }
    }
}
