using UnityEngine;

public class ChaseState : BaseState
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(player)
        {
            if (Vector3.Distance(animator.transform.position, player.transform.position) > npc.AggroRange) // If player is out of npc aggro range.
            {
                animator.SetTrigger(StateTrigger.Aggro); // Transition to Patrol State
            }

            animator.transform.position = Vector3.MoveTowards(animator.transform.position, player.transform.position, npc.ChaseMovementSpeed * Time.deltaTime); // Move towards player.
        }
        else
        {
            animator.SetTrigger(StateTrigger.Aggro);
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger(StateTrigger.Aggro);
    }
}
