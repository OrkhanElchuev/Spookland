using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Public
    public GameObject projectile;
    public Transform shootingPoint;
    public float periodBetweenShots;

    // Private
    private float shootingTime;

    private void Update()
    {
        WeaponDirectionFollowingMouse();
        Shooting();
    }

    // Adjust weapon direction to mouse
    private void WeaponDirectionFollowingMouse()
    {
        // Assign the direction of weapon to relevant value with respect to the mouse's position
        Vector2 weaponDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        // The angle the weapon must rotate around to face the cursor
        float angle = Mathf.Atan2(weaponDirection.y, weaponDirection.x) * Mathf.Rad2Deg;
        // Convert angle to Unity rotation 
        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        // Apply the rotation to weapon 
        transform.rotation = rotation;
    }

    // Handle shooting
    private void Shooting()
    {
        // Check if Left mouse button is pressed
        if (Input.GetMouseButton(0))
        {
            // Check if current time in game is higher than shooting time(Can we shoot?)
            if (Time.time >= shootingTime)
            {
                // Create a projectile
                Instantiate(projectile, shootingPoint.position, transform.rotation);
                shootingTime = Time.time + periodBetweenShots;
            }
        }
    }
}
