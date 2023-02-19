using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIBehaviour
{
    protected AIAgent aIAgent;

    public AIBehaviour(AIAgent aIAgent)
    {
        this.aIAgent = aIAgent;
    }

    public abstract void Begin();

    public abstract void End();

    public abstract void Update();

}
