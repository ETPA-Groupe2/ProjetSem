using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBlock : MonoBehaviour, IBlock1
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
        // If this block is trigger by the zone, it calls this function
        if (other.tag == "Zone")
        {
            //function called when touched  
            onTouch();
        }
    }

    public void onTouch()
    {
        // The block is thrown in the air by this vector
        m_blueBlockTR.AddForce((transform.position + new Vector3(0,0,-1)) * m_force);

    }
}
