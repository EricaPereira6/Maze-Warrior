using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AttackAIBehaviour : AIBehaviour
{

    private Animator anim;
    private NavMeshAgent navMeshAgent;

    private Transform self;
    private Transform player;

    private bool canAttack;

    public AttackAIBehaviour(AIAgent aIAgent) : base(aIAgent)
    {
        anim = aIAgent.GetComponent<Animator>();
        navMeshAgent = aIAgent.GetComponent<NavMeshAgent>();

        self = aIAgent.transform;
        player = GameObject.FindGameObjectWithTag("Player").transform;

        canAttack = true;

    }
    public override void Begin()
    {
       
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

            
        if (navMeshAgent.remainingDistance >= Constants.farAwayRemainingDistance)
        {
            aIAgent.HandleEvent(AIEvent.FarAwayFromPlayer);
        }
        else if (navMeshAgent.remainingDistance < Constants.attackRemainingDistance)
        {
                
            if (canAttack)
            {
                anim.SetTrigger("attack");
                aIAgent.StartCoroutine(AttackCooldown());
            }
            if (Physics.Raycast(aIAgent.gameObject.transform.position, aIAgent.gameObject.transform.forward, out RaycastHit hit, 2))
            {
                if (!hit.collider.gameObject.transform.Equals(player))
                {
                    navMeshAgent.SetDestination(player.position);
                }
            }else
            {
                navMeshAgent.SetDestination(player.position);
            }

        }
        else
        {
            navMeshAgent.SetDestination(player.position - self.forward * Constants.spaceBetween);
            anim.SetBool("chase", true);
        }
        
    }

    IEnumerator AttackCooldown()
    {
        canAttack = false;

        yield return new WaitForSeconds(Constants.secondsBeforeNextAttack);

        canAttack = true;
    }

}
