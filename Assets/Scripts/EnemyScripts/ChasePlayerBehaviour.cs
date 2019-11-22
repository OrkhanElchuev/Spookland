using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePlayerBehaviour : StateMachineBehaviour
{
    //Public
    public float speed;

    //Private
    private GameObject player;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Check if palyer exists
        if (player != null)
        {
            // Move boss smoothly towards player (Chasing behaviour)
            animator.transform.position = Vector2.MoveTowards(animator.transform.position, 
            player.transform.position, speed * Time.deltaTime);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }


}
