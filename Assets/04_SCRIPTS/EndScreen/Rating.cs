﻿/******************************************************
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

    [Header("Display management")]
    [Tooltip("Put here the text box in which you want to display the final rating")]
    [SerializeField] private Text m_textDisplayer;

    AudioSource m_completedSound;

    private void Start()
    {
        m_completedSound = GetComponent<AudioSource>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("test");
            m_completedSound.Play(0);
            m_pollutionRate.FinalRating();
            m_textDisplayer.text = "Niveau terminé ! Vous êtes du rang " + m_pollutionRate.m_rateString + " !";
            Invoke("LoadLevel2", 5f);
        }
    }

    //Temporary
    void LoadLevel2()
    {
        SceneManager.LoadScene("Salle2_V1");
    }
}
