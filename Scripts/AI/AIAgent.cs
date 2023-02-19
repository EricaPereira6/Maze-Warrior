using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIAgent : MonoBehaviour
{
    public abstract void HandleEvent(AIEvent aIEvent);
}
