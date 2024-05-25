using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsOnPressurePlate : Node //Inheriting from Node Class
{
    private PressurePlate[] availablePlates; //Uses the PressurePlate script in the Scripts folder
    private Transform target;
    private CompanionAI ai;

    //Constructor
    public IsOnPressurePlate(PressurePlate[] availablePlates, Transform target, CompanionAI ai){
        this.availablePlates = availablePlates;
        this.target = target;
        this.ai = ai;
    }

    public override NodeState Evaluate(){
        //throw new System.NotImplementedException(); //This line indicates that this method has no implementation and therefore provides no functionality
        Transform pressurePlateLocation = findPressurePlateLocation();
        return pressurePlateLocation != null ? NodeState.SUCCESS : NodeState.FAILURE; //Return SUCCESS if pressurePlateLocation is found, FAILURE if not
    }

    private Transform findPressurePlateLocation(){
        if(ai.GetPressurePlateLocation() != null){ //This function prevents AI Companion from switching to another pressurePlate should the player move
            //if(CheckIfSpotIsValid(ai.GetPressurePlateLocation())){ //UNCOMMENT THIS WHEN CheckIfSpotIsValid() is made
                return ai.GetPressurePlateLocation();
            //}
        }
        Transform pressurePlateLocation = null;
        //FIND PRESSURE PLATE TO GO TO...
        return pressurePlateLocation;
    }
}
