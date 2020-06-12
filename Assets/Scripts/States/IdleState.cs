using UnityEngine;

public class IdleState : BaseState
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (behaviour.Hostile)
        {
            if(Vector3.Distance(animator.transform.position, player.transform.position) <= behaviour.AggroDistance)
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
