using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private void Update()
    {
        WeaponDirectionFollowingMouse();
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
}
