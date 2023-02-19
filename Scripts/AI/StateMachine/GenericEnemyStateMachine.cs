using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericEnemyStateMachine : AIStateMachine
{
    public AIState GetNextState(AIState currentState, AIEvent aIEvent)
    {
        if (aIEvent == AIEvent.Start)
        {
            return AIState.Idle;
        }

        if (aIEvent == AIEvent.PlayerSpotted)
        {
            return AIState.Chase;
        }

        if (aIEvent == AIEvent.PlayerLost)
        {
            return AIState.Idle;
        }

        if (aIEvent == AIEvent.ClosingInOnPlayer)
        {
            return AIState.Attack;
        }
        if (aIEvent == AIEvent.FarAwayFromPlayer)
        {
            return AIState.Chase;
        }

        if (currentState == AIState.Idle)
        {
            if (aIEvent == AIEvent.IdleLongEnough)
            {
                return AIState.Patrol;
            }
        }

        if (currentState == AIState.Patrol)
        {
            if (aIEvent == AIEvent.ReachedDestination)
            {
                return AIState.Idle;
            }
        }

        if (aIEvent == AIEvent.End)
        {
            return AIState.Die;
        }

        return AIState.Idle;

    }
}
