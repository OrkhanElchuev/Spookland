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

    // Set random target position for summoner to settle 
    private void SetRandomTargetPos()
    {
        // Generate random X and Y positions within play ground
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        // Assign target position to generated values
        targetPosition = new Vector2(randomX, randomY);
    }

    private void Update()
    {
      
    }

    public void SummonCreature()
    {
        if (player != null)
        {
            Instantiate(creatureToSummon, transform.position, transform.rotation);
        }
    }

    // Handle enemy attack
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
