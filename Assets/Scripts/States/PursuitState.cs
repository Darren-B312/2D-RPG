using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PursuitState : BaseState
{
    NPCPursuitBehaviour pursuitBehaviour;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        pursuitBehaviour = animator.GetComponent<NPCPursuitBehaviour>();
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(player)
        {
            pursuitBehaviour.PursueTarget(player.transform);
        }

        if(pursuitBehaviour.IsOutOfPursuitRange())
        {
            animator.SetTrigger("Retreat");
        }
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Retreat");
    }
}
