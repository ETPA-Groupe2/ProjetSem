/******************************************************
*       Made by Johann Theron                         *  
*                                                     *
/*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneSoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource m_EnableZoneSound;
    [SerializeField] private AudioSource m_DisableZoneSound;
    [SerializeField] private AudioSource m_ZoneSound;

    public void EnableSound()
    {
        m_EnableZoneSound.Play(0);
    }

    public void DisableSound()
    {
        m_DisableZoneSound.Play(0);
    }

    public void ZoneSound()
    {
        m_ZoneSound.Play(0);
    }

    public void StopZoneSound()
    {
        m_ZoneSound.Stop();
    }
}
