using UnityEngine;

public abstract class BaseState : StateMachineBehaviour
{
    protected NPCBehaviourController behaviour;
    protected GameObject npc;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        behaviour = animator.GetComponent<NPCBehaviourController>();
        npc = animator.gameObject;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
