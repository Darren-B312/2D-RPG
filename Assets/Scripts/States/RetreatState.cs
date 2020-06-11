using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetreatState : BaseState
{
    NPCRetreatBehaviour retreatBehaviour;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        retreatBehaviour = animator.GetComponent<NPCRetreatBehaviour>();
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (retreatBehaviour.IsHome())
        {
            animator.SetTrigger("Home");
        }
        else
        {
            retreatBehaviour.Retreat();
        }
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Home");
    }
}
