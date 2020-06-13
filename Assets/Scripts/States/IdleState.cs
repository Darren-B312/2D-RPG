using UnityEngine;

public class IdleState : BaseState
{
    private const string trigger = "Aggro";

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        Debug.Log(behaviour.Patrol);
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(behaviour.Patrol)
        {
            animator.SetBool("isPatrol", behaviour.Patrol);
        }

        if (behaviour.Hostile)
        {
            if(Vector3.Distance(animator.transform.position, player.transform.position) <= behaviour.AggroDistance)
            {
                animator.SetTrigger(trigger);
            }
        }
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger(trigger);
    }
}
