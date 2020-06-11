using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState : StateMachineBehaviour
{
    protected GameObject npc;
    protected GameObject player;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Debug.Log("OnStateEnter: BaseState");
        npc = animator.gameObject;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Debug.Log("OnStateUpdate: BaseState");
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Debug.Log("OnStateUpdate: BaseState");
    }
}
