using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSoundDestroyer : MonoBehaviour
{
    [SerializeField] DontDestroyMusic m_bool;

    void Start()
    {
        m_bool.m_inGame = true;  
    }

}
