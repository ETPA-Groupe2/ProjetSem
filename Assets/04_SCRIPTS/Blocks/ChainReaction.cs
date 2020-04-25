using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GD2Lib;

public class ChainReaction : MonoBehaviour
{
    [SerializeField] private GD2Lib.Event m_event;

    private void OnEnable() 
    {
        if(m_event != null)
            m_event.Register(HandleReaction);
    }

    private void OnDisable()
    {
        if(m_event != null)
            m_event.Unregister(HandleReaction);
    }

    private void HandleReaction(GD2Lib.Event p_event, object[] p_params)
    {
        if(GD2Lib.Event.TryParseArgs(out ParticleSystem p_system, p_params))
        {
            p_system.Play();

            Debug.Log("Ca marche starff");
        }
        else
        {
            Debug.LogError("Ce ne sont pas les bons paramètres");
        }
    }
}
