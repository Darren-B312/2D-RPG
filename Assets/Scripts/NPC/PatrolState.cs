using UnityEngine;
using Random = UnityEngine.Random;

public class PatrolState : BaseState
{
    private Vector3 targetPoint;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);

        targetPoint = npc.PatrolPoints[0]; // Go to start point.
        npc.PatrolPauseTimer = npc.PatrolPauseTime; // Set timer.
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(player)
        {
            if (Vector3.Distance(animator.transform.position, player.transform.position) <= npc.AggroRange) // If the player is within aggro range.
            {
                animator.SetTrigger(StateTrigger.Aggro); // Transition to Chase State.
            }
        }

        // TODO: Check if within melee range of player to enter attack state at this point.

        animator.transform.position = Vector3.MoveTowards(animator.transform.position, targetPoint, npc.PatrolMovementSpeed * Time.deltaTime); // Move towards player.

        if(Vector3.Distance(animator.transform.position, targetPoint) <= 0.01f) // If npc is at target point.
        {
            if(npc.PatrolPauseTimer <= 0) // If npc has waited long enough.
            {
                targetPoint = npc.PatrolPoints[Random.Range(0, npc.PatrolPoints.Count)]; // Pick a new random point.
                npc.PatrolPauseTimer = npc.PatrolPauseTime; // Reset timer.
            }
            else
            {
                npc.PatrolPauseTimer -= Time.deltaTime; // Otherwise, decrement timer.
            }
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger(StateTrigger.Aggro);
    }
}
