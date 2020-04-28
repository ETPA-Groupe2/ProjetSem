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

    [Tooltip("Needs a reference to the types it's suppose to check")]
    public List<s_EnumType> m_types;

    [Tooltip("Needs a reference to it's particle system")]
    public ParticleSystem m_particles;

    [Tooltip("Check if it have the correct type")]
    public bool hasType = false;

    [Tooltip("Utterly useless, thank you Anna.")]
    [SerializeField] private float m_pollutionLvl;

    public virtual void CheckType(s_EnumType p_type)
    {
        for(int i = 0; i<m_types.Count; i++)
        {
            if(m_types[i] == p_type)
            {
                hasType = true;
            }
        }

        if(hasType)
        {
            if(m_event!=null)
                m_event.Raise(m_particles);
        }
    }
}
