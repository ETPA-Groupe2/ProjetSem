using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyAmbient : MonoBehaviour
{
    [SerializeField] DontDestroyMusic m_boolean;

    public static DontDestroyAmbient m_instanceAmbient;

    void Awake()
    {
        if (m_instanceAmbient)
        {
            Destroy(gameObject);  
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            m_instanceAmbient = this;
        }
    }
    void Update()
    {
        if(m_boolean.m_inGame == true)
        {
            Destroy(gameObject);
        }
    }
}
