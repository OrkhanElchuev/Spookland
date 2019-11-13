using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Public
    public Transform playerTransform;
    public float speed;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    private void Start()
    {
        transform.position = playerTransform.position;
    }

    private void Update()
    {
        MovingCamera();
    }

    // Follow the player
    private void MovingCamera()
    {
        // Check if player is alive to avoid Exception
        if (playerTransform != null)
        {
            // Create borders for Camera to not go off the scene
            float clampedX = Mathf.Clamp(playerTransform.position.x, minX, maxX);
            float clampedY = Mathf.Clamp(playerTransform.position.y, minY, maxY);
            // Smoothly moving from one point to another with defined speed
            transform.position = Vector2.Lerp(transform.position, 
            new Vector2(clampedX, clampedY), speed);
        }
    }
}
