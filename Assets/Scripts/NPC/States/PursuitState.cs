using UnityEngine;

public class PursuitState : BaseState
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(behaviour.Player.activeSelf) // If Player is active.
        {
            if (Vector3.Distance(animator.transform.position, behaviour.Player.transform.position) <= behaviour.AttackRange) // If Player is within NPC attack range.
            {
                animator.SetTrigger(StateTransitionParameter.ATTACK); // Transition to Attack State.
            }
            else
            {
                animator.transform.position = Vector3.MoveTowards(animator.transform.position, behaviour.Player.transform.position, behaviour.MovementSpeed * Time.deltaTime); // Else move towards Player.
            }
        }
        else
        {
            animator.SetTrigger(StateTransitionParameter.RETREAT); // Else transition to Retreat State.
        }

        if (Vector3.Distance(animator.transform.position, behaviour.SpawnPoint) >= behaviour.PursuitMaxDistance) // If NPC is beyond pursuit distance.
        {
            animator.SetTrigger(StateTransitionParameter.RETREAT); // Transition to Retreat State.
        }
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger(StateTransitionParameter.RETREAT);
        animator.ResetTrigger(StateTransitionParameter.ATTACK);
    }
}
