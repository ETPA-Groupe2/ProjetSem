using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBlock : Blocks, IObstacle
{
    [Header("--- OBSTACLE MOVING PARAMETERS ---")]
    
    [Tooltip("Check if we move on the Z axis")] 
    [SerializeField] private bool m_zAxis;

    [Tooltip("Check if we move on the X axis")] 
    [SerializeField] private bool m_xAxis;

    [Tooltip("The direction given by the gliding block")] 
    [SerializeField] private Vector3 m_dir;

    [Tooltip("The speed of the block")] 
    [SerializeField] private float m_speed;

    public Vector3 onPush(Vector3 v)
    {
        m_dir = v;

        if(m_dir.z >= 0.9f)
        {
            m_zAxis = true;
        }
        else if(m_dir.z <= -0.9f)
        {
            m_zAxis = true;
        }

        if(m_dir.x <= -0.9f)
        {
            m_xAxis = true;
            m_dir.x = -m_dir.x;
        }
        else if(m_dir.x >= 0.9f)
        {
            m_xAxis = true;
            m_dir.x = -m_dir.x;
        }

        return m_dir;
    }

    private void Update() 
    {
        if(m_zAxis)
        {
            transform.Translate(0, 0, m_dir.z*m_speed*Time.deltaTime);
        }
        if(m_xAxis)
        {
            transform.Translate(m_dir.x*m_speed*Time.deltaTime, 0, 0);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Zone") && !other.gameObject.CompareTag("Ground") && !other.gameObject.CompareTag("Gliding"))
        {
            transform.Translate(Vector3.zero);
            m_xAxis = false;
            m_zAxis = false;
        }
    }
}
