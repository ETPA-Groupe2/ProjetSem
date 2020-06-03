/******************************************************
*       Made by Johann Theron                         *  
*                                                     *
/*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSoundScript : MonoBehaviour
{
    [Tooltip("Audio object for the clic sound")]
    GameObject m_audioObject;

    public void PlaySound()
    {
        m_audioObject = GameObject.Find("ClickSound");
    }
}

