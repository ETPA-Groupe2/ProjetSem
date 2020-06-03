/******************************************************
*       Made by Johann Theron                         *  
*                                                     *
/*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSoundDestroyer : MonoBehaviour
{
    private GameObject[] m_menu;

void Start()
    {
        m_menu = new GameObject[3];

        m_menu = GameObject.FindGameObjectsWithTag("Menu");

        if (m_menu != null)
        {
            for (int i = 0; i < m_menu.Length; i++)
            {
                Destroy(m_menu[i].gameObject);
            }
        }
    }
}
