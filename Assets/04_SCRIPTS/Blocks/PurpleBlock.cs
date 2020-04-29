/******************************************************
*       Made by Pauline Barbet & Iohannes Mboumba     *  
*                                                     *
/*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GD2Lib;

public class PurpleBlock : Blocks, IFire
{
    // When the block is triggered by another collider
    public void OnTriggerEnter(Collider other)
    {
        IFire f = other.GetComponent<IFire>();

        // If the collider has a Blue Block tag (checking the identity)
        if(f != null)
        {
            f.onTouch();
        }
    }
    
    //Function called when the block is touched
    public void onTouch()
    {
        if(m_event!=null)
            m_event.Raise();
    }

}
