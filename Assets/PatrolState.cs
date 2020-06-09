using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : StateMachineBehaviour
{
    Vector3 a;
    Vector3 b;
    int target = 0;

    float speed = 2;

    GameObject player;
    float distance;


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("OnStateEnter: Patrol");
        a = animator.transform.position;
        b = new Vector3(5f, 5f);
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("OnStateUpdate: Patrol");

        distance = Vector2.Distance(player.transform.position, animator.transform.position);


        if (distance <= 5)
        {
            Debug.Log("TOO CLOSE!");
            // change to chase state
            animator.SetTrigger("Proximity");
            
        }

        if (target == 0)
        {
            animator.transform.position = Vector2.MoveTowards(animator.transform.position, b, speed * Time.deltaTime);
        }
        else if (target == 1)
        {
            animator.transform.position = Vector2.MoveTowards(animator.transform.position, a, speed * Time.deltaTime);
        }


        if (animator.transform.position == b)
        {
            Debug.Log("At B!");
            target = 1;
        }
        else if (animator.transform.position == a)
        {
            Debug.Log("At A!");
            target = 0;
        }


    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("OnStateExit: Patrol");
        animator.ResetTrigger("Proximity");

    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
