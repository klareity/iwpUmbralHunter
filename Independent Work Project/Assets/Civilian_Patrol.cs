using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Civilian_Patrol : StateMachineBehaviour
{
    Transform player;
    Rigidbody2D rb2d;
    float minX;
    float maxX;
    Vector3 InitialPos;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb2d = animator.GetComponent<Rigidbody2D>();

        minX = animator.GetComponent<CivilianScript>().minX;
        maxX = animator.GetComponent<CivilianScript>().maxX;
        InitialPos = animator.GetComponent<CivilianScript>().InitialPosition;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(rb2d.position.x > InitialPos.x + maxX || animator.GetComponent<CivilianScript>().isRight == false)
        {
            Vector2 Lefttarget = new Vector2(InitialPos.x - minX, rb2d.position.y);
        }
       
        else if(rb2d.position.x < InitialPos.x - minX || animator.GetComponent<CivilianScript>().isRight == true)
        {
            Vector2 Righttarget = new Vector2(InitialPos.x + maxX, rb2d.position.y);
        }
        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }


}
