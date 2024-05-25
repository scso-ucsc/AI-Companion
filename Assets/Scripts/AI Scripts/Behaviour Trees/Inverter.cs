using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inverter : Node //This code inverts the demands of different nodes in a tree; this prevents the need to write a brand new node
{
	protected Node node;

	public Inverter(Node node)
	{
		this.node = node;
	}
	public override NodeState Evaluate()
	{
		switch (node.Evaluate())
		{
			case NodeState.RUNNING:
				_nodeState = NodeState.RUNNING;
				
				break;
			case NodeState.SUCCESS:
				_nodeState = NodeState.FAILURE;
				break;
			case NodeState.FAILURE:
				_nodeState = NodeState.SUCCESS;
				break;
			default:
				break;
		}
		return _nodeState;
	}
}
