using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyMusic : MonoBehaviour
{


    public static DontDestroyMusic m_instanceMusic;

    void Awake()
    {
       

        if (m_instanceMusic)
        {
            Destroy(gameObject);  
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            m_instanceMusic = this;
        }
    }
}
