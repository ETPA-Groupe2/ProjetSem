using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GD2Lib;

public class PurpleBlock : Blocks, IFire
{
    [SerializeField] private ParticleSystem m_particles;

    // When the block is triggered by another collider
    public void OnTriggerEnter(Collider other)
    {
        Type t = other.gameObject.GetComponent<Type>();
        IFire f = other.GetComponent<IFire>();

        if(t != null)
        {
            // If the collider has a Blue Block tag (checking the identity)
            if(t.m_type == m_zoneType || f != null)
            {
                onTouch();
            }
        }
        
    }

    //Function called when the block is touched
    public void onTouch()
    {
        if(m_event!=null)
            m_event.Raise(m_particles);
    }
}
