using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ninja : AIAgent
{

    private Animator anim;
    private NavMeshAgent agent;
    private CapsuleCollider capsule;
    private Vector3 originalCapsuleCenter;

    public Transform[] patrolPoints;

    private Rigidbody rg;

    private AIState currentState;
    private AIBehaviour currentBehaviour;
    private AIStateMachine stateMachine;
    private Dictionary<AIState, AIBehaviour> behaviours;

    private NinjaLifeSystem lifeSystem;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();

        capsule = GetComponent<CapsuleCollider>();
        originalCapsuleCenter = capsule.center;

        lifeSystem = GetComponent<NinjaLifeSystem>();

        behaviours = new Dictionary<AIState, AIBehaviour>();

        behaviours.Add(AIState.Idle, new IdleAIBehaviour(this));
        behaviours.Add(AIState.Patrol, new PatrolAIBehaviour(this, patrolPoints));
        behaviours.Add(AIState.Chase, new ChaseAIBehaviour(this));
        behaviours.Add(AIState.Attack, new AttackAIBehaviour(this));
        behaviours.Add(AIState.Die, new DieAIBehaviour(this));

        stateMachine = new GenericEnemyStateMachine();

        rg = GetComponent<Rigidbody>();

        HandleEvent(AIEvent.Start);

    }

    public void EndLife()
    {
        HandleEvent(AIEvent.End);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentBehaviour != null)
        {
            if (lifeSystem.IsDead())
            {
                HandleEvent(AIEvent.End);
            }
            else
            {
                currentBehaviour.Update();
            }
        }

        if (currentState == AIState.Die && rg != null && !rg.isKinematic)
        {
            rg.isKinematic = true;
            capsule.height = 0;
            capsule.isTrigger = true;
        }

        float height = anim.GetFloat("ninja_capsule_height");

        capsule.center = originalCapsuleCenter - (Vector3.up * (height * Constants.deathHeightOffset));

    }

    public override void HandleEvent(AIEvent aIEvent)
    {
        if (currentBehaviour != null)
        {
            behaviours[currentState].End();
        }
        if (anim.GetBool("chase"))
        {
            anim.SetBool("chase", false);
        }

        currentState = stateMachine.GetNextState(currentState, aIEvent);

        currentBehaviour = behaviours[currentState];

        currentBehaviour.Begin();

    }


    private void OnAnimatorMove()
    {
        // updates the agent' speed (the green cylinder position) with the ongoing animation
        agent.speed = (anim.deltaPosition / Mathf.Max(Time.deltaTime, 0.01f)).magnitude;
    }

}
