using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayLevelSelected : MonoBehaviour
{
    GameObject m_audioObject;

    public void PlaySound()
    {
        m_audioObject = GameObject.Find("LVLSelected");
        m_audioObject.GetComponent<AudioSource>().Play();
    }
}
