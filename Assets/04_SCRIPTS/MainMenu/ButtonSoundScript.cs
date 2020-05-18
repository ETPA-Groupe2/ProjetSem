﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSoundScript : MonoBehaviour
{
    public GameObject m_audioObject;

    public void PlaySound()
    {
        m_audioObject.GetComponent<AudioSource>().Play();
    }
}
