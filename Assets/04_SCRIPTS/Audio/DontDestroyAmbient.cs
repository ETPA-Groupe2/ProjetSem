using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyAmbient : MonoBehaviour
{
    [SerializeField] DontDestroyMusic m_bool;

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
        Debug.Log(m_bool.m_inGame);
        if(m_bool.m_inGame == true)
        {
            Destroy(gameObject);
        }
    }
}
