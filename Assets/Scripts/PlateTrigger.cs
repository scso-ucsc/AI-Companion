using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateTrigger : MonoBehaviour
{
    [SerializeField] Material orange;
    [SerializeField] Material green;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameObject.GetComponent <Renderer>().material = green;
            gameObject.tag = "on";
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameObject.GetComponent<Renderer>().material = orange;
            gameObject.tag = "off";
        }
    }
}
