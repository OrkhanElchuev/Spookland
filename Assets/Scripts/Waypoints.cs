using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoints : StateMachineBehaviour
{
    // Public 
    public float speed;

    // Private
    private GameObject[] waypoints;
    int randomPoint;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        waypoints = GameObject.FindGameObjectsWithTag("Waypoints");
        // Generate random value among the existing waypoints
        randomPoint = Random.Range(0, waypoints.Length);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Move towards random existing waypoint
        animator.transform.position = Vector2.MoveTowards(animator.transform.position,
         waypoints[randomPoint].transform.position, speed * Time.deltaTime);
        // Regenerate random point among waypoints if enemy is initially in the position of generated waypoint
        if (Vector2.Distance(animator.transform.position, waypoints[randomPoint].transform.position) < 0.1f)
        {
            randomPoint = Random.Range(0, waypoints.Length);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
