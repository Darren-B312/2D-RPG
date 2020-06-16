using UnityEngine;

public class IdleState : BaseState
{
    private Vector3 target; // The current target point in the NPC patrol.

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        target = behaviour.PatrolPoints[0];
        behaviour.PatrolPauseTimer = 0;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (behaviour.Patrol) // If NPC is flagged as patrol.
        {
            if (Vector3.Distance(animator.transform.position, target) <= 0.01f) // If NPC is at target patrol point.
            {
                if (behaviour.PatrolPauseTimer <= 0) // If npc has waited long enough.
                {
                    target = behaviour.PatrolPoints[Random.Range(0, behaviour.PatrolPoints.Count)]; // Pick a new random point.
                    behaviour.PatrolPauseTimer = behaviour.PatrolPauseTime; // Reset timer.
                }
                else
                {
                    behaviour.PatrolPauseTimer -= Time.deltaTime; // Otherwise, decrement timer.
                }
            }

            animator.transform.position = Vector3.MoveTowards(animator.transform.position, target, behaviour.MovementSpeed * Time.deltaTime); // Move towards target.
        }

        if(behaviour.Player.activeSelf) // If Player is active.
        {
            if(behaviour.Hostile) // If NPC is hostile.
            {
                if (Vector3.Distance(animator.transform.position, behaviour.Player.transform.position) <= behaviour.AggroDistance) // If Player is in NPC aggro range.
                {
                    animator.SetTrigger(StateTransitionParameter.AGGRO); // Transition to Pursuit State.
                }
            }
            else if(behaviour.Combat) // If NPC is in combat.
            {
                animator.SetTrigger(StateTransitionParameter.AGGRO); // Transition to Pursuit State.
            }
        }
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger(StateTransitionParameter.AGGRO);
    }
}
