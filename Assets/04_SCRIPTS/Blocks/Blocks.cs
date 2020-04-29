/******************************************************
*       Made by Iohannes Mboumba                      *  
*                                                     *
/*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Blocks : MonoBehaviour
{
    [Tooltip("Needs a reference to the event it's going to have")]
    public GD2Lib.Event m_event;

    [Tooltip("Needs a reference to it's particle system")]
    [SerializeField] protected ParticleSystem m_particles;

    [Tooltip("Utterly useless, thank you Anna.")]
    [SerializeField] protected float m_pollutionLvl;
    
    private void OnEnable() 
    {
        if(m_event != null)
            m_event.Register(handleReaction);
    }

    private void OnDisable() 
    {
        //Unregister the event
        if(m_event != null)
            m_event.Unregister(handleReaction);
    }

    public  virtual void handleReaction(GD2Lib.Event p_event, object[] p_params)
    {
        m_particles.Play();
        Debug.Log("Ca marche starff");
    }
}
