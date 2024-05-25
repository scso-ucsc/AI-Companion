using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour //This script should be implemented onto the pressure plate game objects
{
    //Refer to this tutorial: https://youtu.be/F-3nxJ2ANXg?t=1135
    [SerializeField] private Transform[] pressurePlateSpots;

    public Transform[] getPressurePlateSpots(){
        return pressurePlateSpots;
    }
}
