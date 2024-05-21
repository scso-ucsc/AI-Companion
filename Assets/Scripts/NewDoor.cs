using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewDoor : MonoBehaviour
{
    [SerializeField] GameObject door;
    [SerializeField] GameObject P1;
    [SerializeField] GameObject P2;
    [SerializeField] bool isClosed = true;

    // Update is called once per frame
    void Update()
    {
        if (P1.tag == "on" && P2.tag == "on" && isClosed)
        {
            door.transform.position += new Vector3(0, 3, 0);
            isClosed = false;
        }
        if (!isClosed && (P1.tag == "off" || P2.tag == "off"))
        {
            door.transform.position -= new Vector3(0, 3, 0);
            isClosed = true;
        }
    }
}
