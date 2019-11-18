using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // Public
    public float playerSpeed;
    public int playerHealth;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public Animator panelHurtEffect;

    // Private
    private Rigidbody2D playerRigidBody;
    private Animator animator;
    private Vector2 movingAmount;
    private int maxHealth = 5;


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

    // Handle damage and destroy player
    public void TakeDamage(int damageAmount)
    {
        playerHealth -= damageAmount;
        UpdateHealthUI(playerHealth);
        panelHurtEffect.SetTrigger("Hurt");
        if (playerHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    // Handle health point modification in UI
    void UpdateHealthUI(int currentHealth)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentHealth)
            {
                // Set current health sprite to full heart
                hearts[i].sprite = fullHeart;
            }
            else
            {
                // Set current health sprite to empty heart
                hearts[i].sprite = emptyHeart;
            }
        }
    }

    // Increment health points of Player
    public void IncreaseHealth(int increaseAmount)
    {
        // Check if health can be increased
        if (playerHealth + increaseAmount > maxHealth)
        {
            // if not then assign maximum health to current health
            playerHealth = maxHealth;
        }
        else
        {
            // Otherwise increment
            playerHealth += increaseAmount;
        }
        UpdateHealthUI(playerHealth);
    }

    // Change the weapon to newly picked one
    public void ChangeWeapon(Weapon weaponToEquip)
    {
        // Destroy currently equipped weapon
        Destroy(GameObject.FindGameObjectWithTag("Weapon"));
        // Equip new weapon
        Instantiate(weaponToEquip, transform.position, transform.rotation, transform);
    }
}
