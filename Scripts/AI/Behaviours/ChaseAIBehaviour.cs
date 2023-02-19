using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseAIBehaviour : AIBehaviour
{

    private Animator anim;
    private NavMeshAgent navMeshAgent;

    private Transform self;
    private Transform player;

    public ChaseAIBehaviour(AIAgent aIAgent) : base(aIAgent)
    {
        anim = aIAgent.GetComponent<Animator>();
        navMeshAgent = aIAgent.GetComponent<NavMeshAgent>();

        self = aIAgent.transform;
        player = GameObject.FindGameObjectWithTag("Player").transform;

    }
    public override void Begin()
    {
        anim.SetBool("chase", true);
    }

    public override void End()
    {

        anim.SetBool("chase", false);
    }

    public override void Update()
    {
        if (player != null && !AIUtils.HasVisionOfPlayer(self, player))
        {
            aIAgent.HandleEvent(AIEvent.PlayerLost);
        }
        else if (player != null)
        {
            navMeshAgent.SetDestination(player.position);
        }

        if (navMeshAgent.remainingDistance < Constants.closingInRemainingDistance)
        {
            aIAgent.HandleEvent(AIEvent.ClosingInOnPlayer);
        }
    }
}
