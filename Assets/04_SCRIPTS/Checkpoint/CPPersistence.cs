﻿/******************************************************
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
                }
                DontDestroyOnLoad(m_instance.gameObject);
            }
            return m_instance;
        }
}

    [SerializeField] Transform m_spawnpoint;
    private Vector3 m_lastCP = Vector3.zero;
    private GameObject m_sp;

    void Start()
    {
        m_sp = GameObject.Find("SpawnPoint");
        if (m_sp!=null)
        {
            DontDestroyOnLoad(m_sp);
        }   
    }

    public void SetSpawnpoint (Vector3 p_spawnPoint)
    {
        m_lastCP = p_spawnPoint;
        Debug.Log(p_spawnPoint);
    }

    public Vector3 SpawnPoint
    {
        get
        {
            if (m_lastCP != Vector3.zero)
                return m_lastCP;
            if (m_spawnpoint == null)
                return Vector3.zero;
           return m_spawnpoint.position;
        }
    }
}


 
