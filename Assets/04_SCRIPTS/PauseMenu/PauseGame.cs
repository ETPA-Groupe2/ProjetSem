/******************************************************
*       Made by Johann Theron                         *  
*                                                     *
/*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    [Header("Buttons")]
    [Tooltip("Please put the back to hub button here")]
    [SerializeField] GameObject m_BackToHUBButton;
    [Tooltip("Please put the resume button here")]
    [SerializeField] GameObject m_ResumeGameButton;
    [Tooltip("Name of the HUB scene")]
    [SerializeField] string m_HUBScene;
    [SerializeField] GameObject m_menuFond;

    void Start()
    {
        m_BackToHUBButton.SetActive(false);
        m_ResumeGameButton.SetActive(false);
        m_menuFond.SetActive(false);

        if(Time.timeScale != 1f)
        {
            Time.timeScale = 1f;
        }
        
    }

    public void BackOnClick()
    {
        SceneManager.LoadScene(m_HUBScene);
    }

    public void ResumeOnClick()
    {
        Time.timeScale = 1f;
        m_BackToHUBButton.SetActive(false);
        m_ResumeGameButton.SetActive(false);
        m_menuFond.SetActive(false);
    }

    public void TogglePause()
    {
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
            Debug.Log("GAME NOT PAUSED");
            m_BackToHUBButton.SetActive(false);
            m_ResumeGameButton.SetActive(false);
            m_menuFond.SetActive(false);
        }
        else
        {
            Time.timeScale = 0f;
            Debug.Log("GAME PAUSED");
            m_BackToHUBButton.SetActive(true);
            m_ResumeGameButton.SetActive(true);
            m_menuFond.SetActive(true);
        }
    }
}
