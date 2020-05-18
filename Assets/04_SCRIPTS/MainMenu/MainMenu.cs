/******************************************************
*       Made by Johann Theron                         *  
*                                                     *
/*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Header("Scenes Management")]
    [Tooltip("Please write the HUB scene name")]
    [SerializeField] string m_HUBScene;

    [Header("Display Management")]
    [Tooltip("Put here the play button")]
    [SerializeField] GameObject m_playButton;
    [Tooltip("Put here the credits screen button")]
    [SerializeField] GameObject m_creditsButton;
    [Tooltip("Put here the quit game button")]
    [SerializeField] GameObject m_quitButton;
    [Tooltip("Put here the text box you want to display the credits")]
    [SerializeField] GameObject m_creditsText;
    [Tooltip("Put here the return to main menu button of the credits screen")]
    [SerializeField] GameObject m_creditsBackButton;


    void Start()
    {
        m_creditsText.SetActive(false);
        m_creditsBackButton.SetActive(false);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(m_HUBScene);
    }

    public void DisplayCredits()
    {
        m_creditsText.SetActive(true);
        m_creditsBackButton.SetActive(true);
        m_playButton.SetActive(false);
        m_creditsButton.SetActive(false);
        m_quitButton.SetActive(false);
    }

    public void GoBackToMain()
    {
        m_creditsText.SetActive(false);
        m_creditsBackButton.SetActive(false);
        m_playButton.SetActive(true);
        m_creditsButton.SetActive(true);
        m_quitButton.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
