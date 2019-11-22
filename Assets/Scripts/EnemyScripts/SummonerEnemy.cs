using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonerEnemy : Enemy
{
    // Public variables
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public float periodBetweenSummons;
    public Enemy creatureToSummon;
    public float attackSpeed;
    public float stopDistance;

    // Private variables
    private float attackPeriod;
    private float summonPeriod;
    private Animator summonerAnimation;
    private Vector2 targetPosition;

    // Override the Start from Enemy script
    public override void Start()
    {
        // Call Start function from Enemy script
        base.Start();
        SetRandomTargetPos();
        summonerAnimation = GetComponent<Animator>();
    }

    private void Update()
    {
        // Check if player exists
        if (player != null)
        {
            MoveSummoner();
            AttackingDistance();
        }
    }

    // Set random target position for summoner to settle 
    private void SetRandomTargetPos()
    {
        // Generate random X and Y positions within play ground
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        // Assign target position to generated values
        targetPosition = new Vector2(randomX, randomY);
    }

    // Handle summoner movement
    private void MoveSummoner()
    {
        // Check the distance between current position and generated target position
        if (Vector2.Distance(transform.position, targetPosition) > 0.5f)
        {
            // If distance is big enough smoothly move towards target position
            transform.position = Vector2.MoveTowards(transform.position,
            targetPosition, enemySpeed * Time.deltaTime);
            // Execute running animation
            summonerAnimation.SetBool("IsRunning", true);
        }
        else
        {
            // If distance is smaller than 0.5 stop running animation
            summonerAnimation.SetBool("IsRunning", false);
            // Check if game time allows to summon a creature
            if (Time.time >= summonPeriod)
            {
                summonPeriod = Time.time + periodBetweenSummons;
                // Execute summoning animation
                summonerAnimation.SetTrigger("Summon");
            }
        }
    }

    // Handle attack distance 
    private void AttackingDistance()
    {
        // Check the distance between summoner and player
        if (Vector2.Distance(transform.position, player.position) < stopDistance)
        {
            if (Time.time >= attackPeriod)
            {
                attackPeriod = Time.time + periodBetweenAttacks;
                // Attack the player if distance allows to do so
                StartCoroutine(Attack());
            }
        }
    }

    // Summon enemy creature
    public void SummonCreature()
    {
        // Check if player exists
        if (player != null)
        {
            // Create creature in position of Summoner
            Instantiate(creatureToSummon, transform.position, transform.rotation);
        }
    }

    // Handle summoner attack 
    IEnumerator Attack()
    {
        // Deal damage
        player.GetComponent<Player>().TakeDamage(damageAmount);
        // Assign positions
        Vector2 originalPosition = transform.position;
        Vector2 targetPosition = player.position;

        float percent = 0;
        while (percent <= 1)
        {
            percent += Time.deltaTime * attackSpeed;
            float formula = (-Mathf.Pow(percent, 2) + percent) * 4;
            // Move swiftly towards player 
            transform.position = Vector2.Lerp(originalPosition, targetPosition, formula);
            yield return null;
        }
    }
}
