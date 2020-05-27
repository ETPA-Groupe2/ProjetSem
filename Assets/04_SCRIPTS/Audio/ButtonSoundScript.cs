using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSoundScript : MonoBehaviour
{
    GameObject m_audioObject;

    public void PlaySound()
    {
        m_audioObject = GameObject.Find("ClickSound");
        m_audioObject.GetComponent<AudioSource>().Play();
    }
}

