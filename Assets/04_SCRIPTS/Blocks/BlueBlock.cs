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

    /// The force applied to the block
    [SerializeField] private float m_force;


    public void OnTriggerEnter(Collider other)
    {
        IFire f = other.GetComponent<IFire>();

        //It it touches something that have fire, it'll burn lol
        if(f != null)
        {
           if(m_event!=null)
            m_event.Raise(m_particles);
        } 
    }

    public override void CheckType(s_EnumType p_type)
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
            // The block is thrown in the air by this vector
            m_blueBlockTR.AddForce((transform.position + new Vector3(0,0,-1)) * m_force);
        }
    }
    
}
