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
    [Header("Buttons references")]
    [Tooltip("Put the back to hub button here")]
    [SerializeField] GameObject m_backToHUBButton;
    [Tooltip("Put the resume button here")]
    [SerializeField] GameObject m_resumeGameButton;
    [Tooltip("Put the reload checkpoint button here")]
    [SerializeField] GameObject m_reloadCPButton;
    [Header("Other references")]
    [Tooltip("Name of the HUB scene")]
    [SerializeField] string m_menuScene;
    [SerializeField] GameObject m_menuFond;

    void Start()
    {
        m_backToHUBButton.SetActive(false);
        m_resumeGameButton.SetActive(false);
        m_reloadCPButton.SetActive(false);
        m_menuFond.SetActive(false);

        if(Time.timeScale != 1f)
        {
            Time.timeScale = 1f;
        }
        
    }

    public void BackOnClick()
    {
        SceneManager.LoadScene(m_menuScene);
    }

    public void ResumeOnClick()
    {
        Time.timeScale = 1f;
        m_backToHUBButton.SetActive(false);
        m_resumeGameButton.SetActive(false);
        m_reloadCPButton.SetActive(false);
        m_menuFond.SetActive(false);
    }

    public void TogglePause()
    {
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
            Debug.Log("GAME NOT PAUSED");
            m_backToHUBButton.SetActive(false);
            m_resumeGameButton.SetActive(false);
            m_reloadCPButton.SetActive(false);
            m_menuFond.SetActive(false);
        }
        else
        {
            Time.timeScale = 0f;
            Debug.Log("GAME PAUSED");
            m_backToHUBButton.SetActive(true);
            m_resumeGameButton.SetActive(true);
            m_reloadCPButton.SetActive(true);
            m_menuFond.SetActive(true);
        }
    }
}
