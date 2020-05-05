using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GD2Lib;
/// <summary>
/// Manages the detection of the objects with the pressure button
/// </summary>
public class Pressure : MonoBehaviour
{


    [Header("Event")]
    [Tooltip("The event you want to play when the button is pressed")]
    [SerializeField] GD2Lib.Event m_event;
    

    void OnTriggerEnter(Collider other)
    {
        m_event.Raise();
    }

    void OnTriggerExit(Collider other)
    {

    }
}
