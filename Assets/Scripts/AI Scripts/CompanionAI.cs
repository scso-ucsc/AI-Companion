﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CompanionAI : MonoBehaviour
{
    [SerializeField] private float chasingRange;
    [SerializeField] private float minChaseDistance; // New serialized field for minimum chase distance
    [SerializeField] private Transform playerTransform;
    [SerializeField] private PressurePlate[] availablePlates;

    private NavMeshAgent agent;
    private Transform pressurePlateLocation;
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
        
        //Creating Nodes for Pressure Plate Interactions
        IsOnPressurePlate isOnPressurePlateNode = new IsOnPressurePlate(availablePlates, playerTransform, this);
        GoToPressurePlate goToPressurePlateNode = new GoToPressurePlate(agent, this);

        Sequence chaseSequence = new Sequence(new List<Node> { chasingRangeNode, chaseNode });
        Sequence pressurePlateSequence = new Sequence(new List<Node> {isOnPressurePlateNode, goToPressurePlateNode});

        topNode = new Selector(new List<Node> {chaseSequence, pressurePlateSequence});
    }

    private void Update()
    {
        topNode.Evaluate();
        if (topNode.nodeState == NodeState.FAILURE)
        {
            agent.isStopped = true;
        }
    }

    public Transform GetPressurePlateLocation(){
        return pressurePlateLocation;
    }
}