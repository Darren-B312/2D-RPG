using UnityEngine;

public class RetreatState : BaseState
{
    private const int RetreatMultiplier = 2;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        behaviour.Combat = false;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Vector3.Distance(animator.transform.position, behaviour.SpawnPoint) <= 0.01f) // If NPC is at spawn point.
        {
            animator.SetTrigger(StateTransitionParameter.HOME); // Transition to Idle State.
        }
        else
        {
            animator.transform.position = Vector3.MoveTowards(animator.transform.position, behaviour.SpawnPoint, behaviour.MovementSpeed * RetreatMultiplier * Time.deltaTime); // Retreat at x times normal movement speed.
        }
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger(StateTransitionParameter.HOME);
    }
}
