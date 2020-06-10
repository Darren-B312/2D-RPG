using System;
using UnityEngine;

public static class StateTrigger
{
    public const string Aggro = "Aggro";
}

[RequireComponent(typeof(NPCBehaviourController))]
public abstract class BaseState : StateMachineBehaviour
{
    protected NPCBehaviourController npc;
    protected GameObject player;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        npc = animator.GetComponent<NPCBehaviourController>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    override public  void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
