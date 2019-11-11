using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float playerSpeed;
    private Vector2 movingAmount;
    private Rigidbody2D playerRigidBody;
    private Animator animator;

    private void Start()
    {
        AssigningComponents();
    }

    // This function is called every frame
    private void Update()
    {
        MovementConfigurations();
    }

    // This function is called every fixed framerate frame
    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        // Move player frame rate independently
        playerRigidBody.MovePosition(playerRigidBody.position + movingAmount * Time.fixedDeltaTime);
    }

    // Setting movement speed and keyboard inputs
    private void MovementConfigurations()
    {
        Vector2 movementInput = new Vector2(Input.GetAxisRaw("Horizontal"),
        Input.GetAxisRaw("Vertical"));
        // .normalized is used to avoid Increased speed while moving diagonally
        movingAmount = movementInput.normalized * playerSpeed;
        // If player is moving execute running animation
        if (movementInput != Vector2.zero)
        {
            animator.SetBool("IsRunning", true);
        }
        else
        {
            animator.SetBool("IsRunning", false);
        }
    }

    // Assign relevant components
    private void AssigningComponents()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

}
