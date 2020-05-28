/******************************************************
*       Made by Johann Theron                         *  
*                                                     *
/*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPPersistence : MonoBehaviour
{
    static CPPersistence m_instance;
    public static CPPersistence Instance { get
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<CPPersistence>();
                if (m_instance == null)
                {
                    GameObject gameObj = new GameObject();
                    m_instance = gameObj.AddComponent<CPPersistence>();

                    DontDestroyOnLoad(m_instance.gameObject);
                }
               
            }
            return m_instance;
        }
}

    private GameObject m_sp;

    [Tooltip("Put here the player transform")]
    [SerializeField] Transform m_player;

    [Tooltip("Put here the navmesh gameObject")]
    [SerializeField] GameObject m_navmesh;

    void Start()
    {
        m_sp = GameObject.Find("SpawnPoint");
        if (m_sp!=null)
        {
            DontDestroyOnLoad(m_sp);
        }   

        Invoke("EnableNavMesh", 0.1f);
        m_player.transform.position = SpawnPoint;
    }

    public void SetSpawnpoint (Vector3 p_spawnPoint)
    {
        m_sp.transform.position = p_spawnPoint;
        Debug.Log(p_spawnPoint);
    }

    public Vector3 SpawnPoint
    {
        get
        {
           return m_sp.transform.position;
        }
    }

    void EnableNavMesh()
    {
        m_navmesh.SetActive(true);
    }
}


 
