using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToPressurePlate : Node
{
    private UnityEngine.AI.NavMeshAgent agent;
    private CompanionAI ai;

    public GoToPressurePlate(UnityEngine.AI.NavMeshAgent agent, CompanionAI ai)
    {
        this.agent = agent;
        this.ai = ai;
    }

    public override NodeState Evaluate()
    {
        Transform pressurePlateLocation = ai.GetPressurePlateLocation(); //Function in CompanionAI Script
        if(pressurePlateLocation == null){
            return NodeState.FAILURE;
        }
        float distance = Vector3.Distance(pressurePlateLocation.position, agent.transform.position);
        if (distance > .1f)
        {
            agent.isStopped = false;
            agent.SetDestination(pressurePlateLocation.position);
            return NodeState.RUNNING;
        }
        else
        {
            agent.isStopped = true;
            return NodeState.SUCCESS;
        }
    }
}
