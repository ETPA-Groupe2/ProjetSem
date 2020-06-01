/******************************************************
*       Made by Johann Theron                         *  
*                                                     *
/*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// This class manages the final rate display
/// </summary>
public class Rating : MonoBehaviour
{
    [Header("Script management")]
    [Tooltip("Put the PollutionRate script here")]
    [SerializeField] private PollutionRate m_pollutionRate;

    AudioSource m_completedSound;

    private void Start()
    {
        m_completedSound = GetComponent<AudioSource>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            m_completedSound.Play(0);
            m_pollutionRate.FinalRating();
 
            Invoke("LoadMenu", 5f);
        }
    }

    void LoadMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
