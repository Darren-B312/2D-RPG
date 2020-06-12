using UnityEngine;

public class PursuitState : BaseState
{
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
            animator.SetTrigger("Retreat");
        }
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Retreat");
    }
}
