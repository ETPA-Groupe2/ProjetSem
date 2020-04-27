/******************************************************
*       Made by Iohannes Mboumba                      *  
*                                                     *
/*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GD2Lib;

public class ChainReaction : MonoBehaviour
{
    [Tooltip("Needs reference to it's event scriptable object")]
    [SerializeField] private GD2Lib.Event m_event;

    private void OnEnable() 
    {
        //Register the event
        if(m_event != null)
            m_event.Register(HandleReaction);
    }

    private void OnDisable()
    {
        //Unregister the event
        if(m_event != null)
            m_event.Unregister(HandleReaction);
    }

    ///<summary>Method for registered to the event</summary>
    private void HandleReaction(GD2Lib.Event p_event, object[] p_params)
    {
        //We check if what we gave to the method as parameters are of the type we want
        if(GD2Lib.Event.TryParseArgs(out ParticleSystem p_system, p_params))
        {
            p_system.Play();

            Debug.Log("Ca marche starff");
        }
        //If not, we let you know
        else
        {
            Debug.LogError("Ce ne sont pas les bons paramètres");
        }
    }
}
