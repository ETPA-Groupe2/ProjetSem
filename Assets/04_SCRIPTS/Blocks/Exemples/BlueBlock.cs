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


    public override void handleReaction(GD2Lib.Event p_event, object[] p_params)
    {
        // The block is thrown in the air by this vector
        m_blueBlockTR.AddForce((transform.position + new Vector3(0,0,-1)) * m_force); 
        Debug.Log("Ca marche woula");
    }
    
}
