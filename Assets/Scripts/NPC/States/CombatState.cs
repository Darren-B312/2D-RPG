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
        // do combat stuff here
        Debug.Log("combat stuff...");
        
        if(Vector3.Distance(animator.transform.position, player.transform.position) > behaviour.AttackRange)
        {
            animator.SetTrigger(StateTrigger.PURSUIT);
        }
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger(StateTrigger.PURSUIT);
    }
}
