using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : BaseState
{
    NPCIdleBehaviour idleBehaviour;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        idleBehaviour = animator.GetComponent<NPCIdleBehaviour>();
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (idleBehaviour.Hostile)
        {
            if (idleBehaviour.IsTargetInAggroDistance(player.transform))
            {
                animator.SetTrigger("Aggro");
            }
        }
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Aggro");
    }
}
