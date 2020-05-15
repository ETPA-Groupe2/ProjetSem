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

    [Header("Display management")]
    [Tooltip("Put here the text box in which you want to display the final rating")]
    [SerializeField] private Text m_textDisplayer;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            m_pollutionRate.FinalRating();
            m_textDisplayer.text = "Vous êtes du rang " + m_pollutionRate.m_rateString + " !";
            Invoke("LoadEndScene", 4f);
        }
    }

    //Temporary
    void LoadEndScene()
    {
        SceneManager.LoadScene("End");
    }
}
