using UnityEngine;

public class PatrolState : BaseState
{
    private const string trigger = "Aggro";
    private Vector3 target;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        target = behaviour.PatrolPoints[0];
        behaviour.PatrolPauseTimer = behaviour.PatrolPauseTime;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (behaviour.Hostile)
        {
            if (Vector3.Distance(animator.transform.position, player.transform.position) <= behaviour.AggroDistance)
            {
                animator.SetTrigger(trigger);
            }
        }

        if (Vector3.Distance(animator.transform.position, target) <= 0.01f) // If npc is at target point.
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

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger(trigger);
    }
}
