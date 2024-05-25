using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence : Node
{
    protected List<Node> nodes = new List<Node>(); //List of nodes to represent the tree

    public Sequence(List<Node> nodes)
    {
        this.nodes = nodes; //Sequence of nodes to check
    }
    public override NodeState Evaluate()
    {
        bool isAnyNodeRunning = false; //To prevent node child from breaking
        foreach (var node in nodes)
        {
            switch (node.Evaluate())
            {
                case NodeState.RUNNING:
                    isAnyNodeRunning = true;
                    break;
                case NodeState.SUCCESS:
                    break;
                case NodeState.FAILURE:
                    _nodeState = NodeState.FAILURE;
                    return _nodeState;
                default:
                    break;
            }
        }
        _nodeState = isAnyNodeRunning ? NodeState.RUNNING : NodeState.SUCCESS; //Asking if any child is running
        return _nodeState;
    }
}
