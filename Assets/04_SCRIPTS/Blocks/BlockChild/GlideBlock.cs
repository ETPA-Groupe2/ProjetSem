using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GD2Lib;

public class GlideBlock : Blocks
{
    [Header("--- GLIDING BLOCK MOVING PARAMETERS ---")]

    [Tooltip("The transform position of the GlideBlock. It should be a Transform Var scriptable object")]
    [SerializeField] public s_TransformVar m_vectorCollider;

    [Tooltip("Check if we move on the Z axis")] 
    [SerializeField] private bool m_zAxis;

    [Tooltip("Check if we move on the X axis")] 
    [SerializeField] private bool m_xAxis;

    [Tooltip("The speed of the block")] 
    [SerializeField] private float m_speed;

    ///<summary>The direction of the block, given by the position of the zone</summary>
    private Vector3 m_dir;

    void Start()
    {
        m_vectorCollider.Value = transform;
    }

    public override void handleReaction(GD2Lib.Event p_event, object[] p_params)
    {
        Debug.Log("Yakalelo");
        if (GD2Lib.Event.TryParseArgs(out Vector3 dir, p_params))
        {
            m_dir = dir.normalized;
            if(m_dir.z >= 0.7f)
            {
                m_zAxis = true;
               // m_dir.z = -m_dir.z;
            }
            else if(m_dir.z <= -0.7f)
            {
                m_zAxis = true;
               // m_dir.z = -m_dir.z;
            }

            if(m_dir.x <= -0.7f)
            {
                m_xAxis = true;
            }
            else if(m_dir.x >= 0.7f)
            {
                m_xAxis = true;
            }
        }
    }

    void Update()
    {
        if(m_zAxis)
        {
            transform.Translate(m_dir.z * m_speed * Time.deltaTime, 0,0 );
            Debug.Log("allo");
        }
        if(m_xAxis)
        {
            transform.Translate(0, 0,-m_dir.x * m_speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
       
        IObstacle o = other.GetComponent<IObstacle>();

        if(o != null)
        {
            o.onPush(m_dir);
            transform.Translate(Vector3.zero);
            m_xAxis = false;
            m_zAxis = false;
        }

        else if (!other.gameObject.CompareTag("Zone") && !other.gameObject.CompareTag("Ground") && !other.gameObject.CompareTag("Player"))
        {
            
            transform.Translate(Vector3.zero);
            m_xAxis = false;
            m_zAxis = false;
        }
    }

}
