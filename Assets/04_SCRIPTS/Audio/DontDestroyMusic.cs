using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyMusic : MonoBehaviour
{
    [HideInInspector]
    public bool m_inGame = false;

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
    void Update()
    {
        if(m_inGame == true)
        {
            Destroy(gameObject);
        }
    }
}
