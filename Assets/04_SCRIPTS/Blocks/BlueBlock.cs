/******************************************************
*       Made by Pauline Barbet & Iohannes Mboumba     *  
*                                                     *
/*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GD2Lib;
public class BlueBlock : Blocks
{
    /// Rigidbody of the BlueBlock 
    [SerializeField] private Rigidbody m_blueBlockTR;

    [SerializeField] private ParticleSystem m_particles;

    /// The force applied to the block
    [SerializeField] private float m_force;


    public void OnTriggerEnter(Collider other)
    {
        Type t = other.gameObject.GetComponent<Type>();
        IFire f = other.GetComponent<IFire>();

        // If this block is trigger by the zone, it calls this function
        if(t != null)
        {
            if(t.m_type == m_zoneType)
            {
                // The block is thrown in the air by this vector
                m_blueBlockTR.AddForce((transform.position + new Vector3(0,0,-1)) * m_force);
            }
        }

        //It it touches something that have fire, it'll burn lol
        if(f != null)
        {
           if(m_event!=null)
            m_event.Raise(m_particles);
        }
       
    }
}
