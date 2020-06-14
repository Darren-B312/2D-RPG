using UnityEngine;

public class PursuitState : BaseState
{
    private const string retreatTrigger = "Retreat";
    private const string attackTrigger = "Attack";

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(player)
        {
            animator.transform.position = Vector3.MoveTowards(animator.transform.position, player.transform.position, behaviour.MovementSpeed * Time.deltaTime);
        }

        if(Vector3.Distance(animator.transform.position, behaviour.SpawnPoint) >= behaviour.PursuitMaxDistance)
        {
            animator.SetTrigger(retreatTrigger);
        }

        if(Vector3.Distance(animator.transform.position, player.transform.position) <= behaviour.AttackRange)
        {
            animator.SetTrigger(attackTrigger);
        }
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger(retreatTrigger);
        animator.ResetTrigger(attackTrigger);
    }
}
