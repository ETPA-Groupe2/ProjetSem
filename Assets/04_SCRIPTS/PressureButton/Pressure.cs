/******************************************************
*       Made by Johann Theron                         *  
*                                                     *
/*****************************************************/

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
    [SerializeField] GD2Lib.Event Event;
    [SerializeField] GameObject m_camDisable;
    

    void OnTriggerEnter(Collider other)
    {
       
        if (!other.gameObject.CompareTag("Player") && !other.gameObject.CompareTag("Zone") && !other.gameObject.CompareTag("Ground"))
        {
            Event.Raise();
            m_camDisable.SetActive(false);
        }
    }

}
