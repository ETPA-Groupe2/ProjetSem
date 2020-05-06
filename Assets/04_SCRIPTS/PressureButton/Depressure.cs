using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GD2Lib;

public class Depressure : MonoBehaviour
{
    [Header("Event")]
    [Tooltip("The event you want to play when the button is pressed")]
    [SerializeField] GD2Lib.Event Event;


    void OnTriggerExit(Collider other)
    {

        if (!other.gameObject.CompareTag("Player"))
        {
            Event.Raise();
        }
    }

}
