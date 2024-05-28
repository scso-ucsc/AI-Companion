using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateTrigger : MonoBehaviour
{
    [SerializeField] Material orange;
    [SerializeField] Material green;
    [SerializeField] GameObject partner_plate;

    void Awake()
    {
        PlayerPrefs.SetInt("PlayerOnPlate", 0);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Companion")
        {
            gameObject.GetComponent <Renderer>().material = green;
            gameObject.tag = "on";

            if (collision.gameObject.tag == "Player")
            {
                PlayerPrefs.SetInt("PlayerOnPlate", 1);
            }
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Companion")
        {
            gameObject.GetComponent<Renderer>().material = orange;
            gameObject.tag = "off";

            if (collision.gameObject.tag == "Player")
            {
                PlayerPrefs.SetInt("PlayerOnPlate", 0);
            }
        }
    }

    public Transform getPartnerPlateTransform(){
        return partner_plate.transform;
    }
}
