using UnityEngine;

public abstract class BaseState : StateMachineBehaviour
{
    protected NPCBehaviourController behaviour;
    protected GameObject npc;
    protected GameObject player;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        behaviour = animator.GetComponent<NPCBehaviourController>();
        npc = animator.gameObject;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
