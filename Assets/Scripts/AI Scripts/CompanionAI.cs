using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CompanionAI : MonoBehaviour
{
    [SerializeField] private float chasingRange;
    [SerializeField] private float minChaseDistance; // New serialized field for minimum chase distance
    [SerializeField] private Transform playerTransform;

    private NavMeshAgent agent;
    private Node topNode;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        ConstructBehaviourTree();
    }

    private void ConstructBehaviourTree()
    {
        ChaseNode chaseNode = new ChaseNode(playerTransform, agent, this, minChaseDistance); // Pass the minimum distance
        RangeNode chasingRangeNode = new RangeNode(chasingRange, playerTransform, transform);

        Sequence chaseSequence = new Sequence(new List<Node> { chasingRangeNode, chaseNode });

        topNode = chaseSequence;
    }

    private void Update()
    {
        topNode.Evaluate();
        if (topNode.nodeState == NodeState.FAILURE)
        {
            agent.isStopped = true;
        }
    }
}