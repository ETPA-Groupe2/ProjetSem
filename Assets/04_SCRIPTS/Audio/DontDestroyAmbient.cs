/******************************************************
*       Made by Johann Theron                         *  
*                                                     *
/*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyAmbient : MonoBehaviour
{
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
}
