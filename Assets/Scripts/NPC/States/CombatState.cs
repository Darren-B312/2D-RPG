using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatState : BaseState
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(behaviour.Player.activeSelf) // If Player is active.
        {
            Debug.Log("do combat stuff here...");

            if (Vector3.Distance(animator.transform.position, behaviour.Player.transform.position) > behaviour.AttackRange) // If Player is beyond NPC attack range.
            {
                animator.SetTrigger(StateTransitionParameter.PURSUIT); // Transition to Pursuit State.
            }
        }
        else
        {
            animator.SetTrigger(StateTransitionParameter.RETREAT); // Else transition to Retreat State.
        }
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger(StateTransitionParameter.PURSUIT);
        animator.ResetTrigger(StateTransitionParameter.RETREAT);
    }
}
