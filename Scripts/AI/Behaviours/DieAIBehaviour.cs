using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DieAIBehaviour : AIBehaviour
{

    private Animator anim;

    public DieAIBehaviour(AIAgent aIAgent) : base(aIAgent)
    {
        anim = aIAgent.GetComponent<Animator>();
    }
    public override void Begin()
    {
        anim.SetTrigger("die");
    }

    public override void End()
    {
    }

    public override void Update()
    {

    }

}
