using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleAIBehaviour : AIBehaviour
{
    private Transform self;
    private Transform player;

    public IdleAIBehaviour(AIAgent aIAgent) : base(aIAgent)
    {

        self = aIAgent.transform;
        player = GameObject.FindGameObjectWithTag("Player").transform;

    }

    public override void Begin()
    {
        aIAgent.StartCoroutine(IdleRoutine());
    }

    public override void End()
    {
        
    }

    public override void Update()
    {
        if (player != null && AIUtils.HasVisionOfPlayer(self, player))
        {
            aIAgent.HandleEvent(AIEvent.PlayerSpotted);
        }
    }

    IEnumerator IdleRoutine()
    {
        yield return new WaitForSeconds(3);

        aIAgent.HandleEvent(AIEvent.IdleLongEnough);
    }
}
