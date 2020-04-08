using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBlock : MonoBehaviour, IBlock1
{
    [SerializeField]
    public Rigidbody m_blueBlockTR;

    [SerializeField]
    public float m_force;

    private void Start()
    {
        m_blueBlockTR.GetComponent<Rigidbody>();
       
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PurpleBlock")
        {
            onTouch();
        }
    }

    public void onTouch()
    {
        m_blueBlockTR.AddForce((transform.position + new Vector3(0,0,-1)) * m_force);
    }
}
