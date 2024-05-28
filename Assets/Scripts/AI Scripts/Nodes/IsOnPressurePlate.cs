using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//really this class is the "Find Cover" class
public class IsOnPressurePlate : Node //Inheriting from Node Class
{
    private PlateTrigger[] availablePlates; //Uses the PlateTrigger script in the Scripts folder
    private Transform target;
    private CompanionAI ai;

    //Constructor
    public IsOnPressurePlate(PlateTrigger[] availablePlates, CompanionAI ai){
        //(PlateTrigger[] availablePlates, Transform target, CompanionAI ai)
        this.availablePlates = availablePlates;
        //this.target = target;
        this.ai = ai;
    }

    public override NodeState Evaluate(){
        //throw new System.NotImplementedException(); //This line indicates that this method has no implementation and therefore provides no functionality
        Transform pressurePlateLocation = findPressurePlateLocation();
        ai.setPressurePlateLocation(pressurePlateLocation);
        return pressurePlateLocation != null ? NodeState.SUCCESS : NodeState.FAILURE; //Return SUCCESS if pressurePlateLocation is found, FAILURE if not
    }

    private Transform findPressurePlateLocation(){
        // if(ai.GetPressurePlateLocation() != null){ //This function prevents AI Companion from switching to another pressurePlate should the player move
        //     //if(CheckIfSpotIsValid(ai.GetPressurePlateLocation())){ //UNCOMMENT THIS WHEN CheckIfSpotIsValid() is made
        //         return ai.GetPressurePlateLocation();
        //     //}
        // }
        Transform pressurePlateLocation = null;
        //FIND PRESSURE PLATE TO GO TO...
        foreach(PlateTrigger pressurePlate in availablePlates){
            if(pressurePlate.tag == "on"){
                pressurePlateLocation = pressurePlate.getPartnerPlateTransform();
            }
        }
        return pressurePlateLocation;
    }
}
