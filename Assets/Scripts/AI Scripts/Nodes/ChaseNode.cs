using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseNode : Node
{
    private Transform target;
    private NavMeshAgent agent;
    private CompanionAI ai;
    private float minDistance; // New minimum distance

    public ChaseNode(Transform target, NavMeshAgent agent, CompanionAI ai, float minDistance)
    {
        this.target = target;
        this.agent = agent;
        this.ai = ai;
        this.minDistance = minDistance; // Initialize the minimum distance
    }

    public override NodeState Evaluate()
    {
        float distance = Vector3.Distance(target.position, agent.transform.position);
        if (distance > minDistance) // Use the minimum distance
        {
            agent.isStopped = false;
            agent.SetDestination(target.position);
            return NodeState.RUNNING;
        }
        else
        {
            agent.isStopped = true;
            return NodeState.SUCCESS;
        }
    }
}
