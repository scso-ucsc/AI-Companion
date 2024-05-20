using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] GameObject door;
    void OnTriggerEnter(Collider col){
        door.SendMessage("setP1Trigger", true);
        door.SendMessage("setP2Trigger", true);
        Debug.Log("triggered plate");
    }

    void OnTriggerExit(Collider col) {
        door.SendMessage("setP1Trigger", false);
        door.SendMessage("setP2Trigger", false);
        Debug.Log("detriggered plate");
    }
}
