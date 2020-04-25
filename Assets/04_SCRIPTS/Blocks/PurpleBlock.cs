using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GD2Lib;

public class PurpleBlock : Blocks, IBlock2
{
    // When the block is triggered by another collider
    public void OnTriggerEnter(Collider other)
    {
        Type t = other.gameObject.GetComponent<Type>();

        if(t != null)
        {
            // If the collider has a Blue Block tag (checking the identity)
            if(t.m_type == m_type.m_type)
            {
                if(m_event!=null)
                    m_event.Raise(transform, other.transform);

                 onTouch();
            }
        }
        
    }

    //Function called when the block is touched
    public void onTouch()
    {
        Debug.Log("What happened?!");   
    }
}
