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
        if(GD2Lib.Event.TryParseArgs(out Transform block1, out Transform block2, p_params))
        {
            block1.Translate(50f, 0f, 10f);
            block2.Translate(80f, 50f, 10f);

            Debug.Log("Ca marche starff");
        }
        else
        {
            Debug.LogError("Ce ne sont pas les bons paramètres");
        }
    }
}
