using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Civillian_Panic : StateMachineBehaviour
{
    Transform player;
    Rigidbody2D rb2d;
    float panicDistance;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb2d = animator.GetComponent<Rigidbody2D>();
        panicDistance = animator.GetComponent<CivilianScript>().panicRadius;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("Im paniking");
        //if player out of range, unpanic
        if(Vector2.Distance(player.position, rb2d.position)>=panicDistance)
        {
            animator.SetTrigger("UnPanic");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("UnPanic");
    }


}
