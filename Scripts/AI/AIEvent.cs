using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AIEvent
{
    Start,
    IdleLongEnough,
    ReachedDestination,
    PlayerSpotted,
    PlayerLost,
    ClosingInOnPlayer,
    FarAwayFromPlayer,
    ReadyToAttackPlayer,
    End
}
