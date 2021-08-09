using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Civilian_Patrol : StateMachineBehaviour
{
    Transform player;
    Rigidbody2D rb2d;
    float panicDistance;
    List<Vector2> waypointList;
    Vector2 CurrentWaypoint;

    public float speed = 3.5f;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb2d = animator.GetComponent<Rigidbody2D>();
        panicDistance = animator.GetComponent<CivilianScript>().panicRadius;
        waypointList = animator.GetComponent<CivilianScript>().Waypoints;
        CurrentWaypoint = waypointList[0];
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Debug.Log("1." + CurrentWaypoint);
        
        //if civ is <= 0.1 to waypoint[0], target is changed from waypoint[0] to waypoint[1]
        if((CurrentWaypoint - rb2d.position).magnitude <= 0.01f)
        {
            if(CurrentWaypoint == waypointList[0])
            {
                CurrentWaypoint = waypointList[1];
            }
            else
            {
                CurrentWaypoint = waypointList[0];
            }
        }

        //Debug.Log("2." + CurrentWaypoint);

        Vector2 newPos = Vector2.MoveTowards(rb2d.position, CurrentWaypoint, speed * Time.fixedDeltaTime);
        rb2d.MovePosition(newPos);

        //if player is <= distance, set trigger panic.
        //Vector2 tempV2 = new Vector2(player.position.x, player.position.y);
        //if((tempV2 - rb2d.position).magnitude <= panicDistance)
        //{
        //    //set trigger
        //}

        if(Vector2.Distance(player.position,rb2d.position) <= panicDistance)
        {
            animator.SetTrigger("Spooked");
        }
        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Spooked");
    }


}
