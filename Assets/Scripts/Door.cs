using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    //GameObject pressurePlate_1;
    //GameObject pressurePlate2;
    [SerializeField] GameObject door;

    [SerializeField] bool p1Press;
    [SerializeField] bool p2Press;
    [SerializeField] bool isClosed = true;

    void Update(){
        if(p1Press && p2Press && isClosed){
            door.transform.position += new Vector3(0, 3, 0);
            isClosed = false;
        }
        if(!isClosed && (!p1Press || !p2Press)){
            door.transform.position -= new Vector3(0, 3, 0);
            isClosed = true;
        }
    }

    void setP1Trigger(bool toggle){
        p1Press = toggle;
        Debug.Log("set p1Trigger");
    }

    void setP2Trigger(bool toggle){
        p2Press = toggle;
        Debug.Log("set p2Trigger");
    }
}
