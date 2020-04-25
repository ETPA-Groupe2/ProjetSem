using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GD2Lib;
public class BlueBlock : Blocks, IBlock1
{
    /// Rigidbody of the BlueBlock
    [SerializeField]
    public Rigidbody m_blueBlockTR;

    
    /// The force applied to the block
    [SerializeField]
    public float m_force;

    private void Start()
    {
        //Get the component of the blue block
        m_blueBlockTR.GetComponent<Rigidbody>();
       
    }

    public void OnTriggerEnter(Collider other)
    {
        Type t = other.gameObject.GetComponent<Type>();

        // If this block is trigger by the zone, it calls this function
        if(t != null)
        {
            if(t.m_type == m_zoneType)
            {
                onTouch();
            }
        }
       
    }

    public void onTouch()
    {
        // The block is thrown in the air by this vector
        m_blueBlockTR.AddForce((transform.position + new Vector3(0,0,-1)) * m_force);

    }
}
