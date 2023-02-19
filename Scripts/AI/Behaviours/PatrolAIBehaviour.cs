using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolAIBehaviour : AIBehaviour
{

    private Animator anim;
    private NavMeshAgent navMeshAgent;

    private Transform self;
    private Transform player;

    private Transform[] patrolPoints;
    private int patrolIndex = -1;

    public PatrolAIBehaviour(AIAgent aIAgent, Transform[] patrolPoints) : base(aIAgent)
    {
        anim = aIAgent.GetComponent<Animator>();
        navMeshAgent = aIAgent.GetComponent<NavMeshAgent>();
        this.patrolPoints = patrolPoints;

        self = aIAgent.transform;
        player = GameObject.FindGameObjectWithTag("Player").transform;


    }
    public override void Begin()
    {
        anim.SetBool("patrol", true);
        NextPatrolPoint();
    }

    public override void End()
    {
        anim.SetBool("patrol", false);
    }

    public override void Update()
    {
        if (player != null && AIUtils.HasVisionOfPlayer(self, player))
        {
            aIAgent.HandleEvent(AIEvent.PlayerSpotted);
        }


        if (navMeshAgent.remainingDistance < Constants.patrolRemainingDistance)
        {
            aIAgent.HandleEvent(AIEvent.ReachedDestination);
        }
    }


    private void NextPatrolPoint()
    {

        patrolIndex++;

        patrolIndex %= patrolPoints.Length;

        navMeshAgent.SetDestination(patrolPoints[patrolIndex].position);
    }
}
