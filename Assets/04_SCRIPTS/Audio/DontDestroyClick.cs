/******************************************************
*       Made by Johann Theron                         *  
*                                                     *
/*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyClick : MonoBehaviour
{
    public static DontDestroyClick m_instanceClick;

    void Awake()
    {
        if (m_instanceClick)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            m_instanceClick = this;
        }
    }
}
