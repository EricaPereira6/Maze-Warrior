using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface AIStateMachine
{
    AIState GetNextState(AIState currentState, AIEvent aIEvent);
}
