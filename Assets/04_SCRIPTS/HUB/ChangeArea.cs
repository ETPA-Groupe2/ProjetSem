using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Manages the switch between all the areas
/// </summary>
public class ChangeArea : MonoBehaviour
{
    [Header("Scenes names")]

    [Tooltip("Name of the Hub scene")]
    [SerializeField] string m_hubScene;

    [Tooltip("Name of the Area 1 scene")]
    [SerializeField] string m_area1Scene;

    [Tooltip("Name of the Area 2 scene")]
    [SerializeField] string m_area2Scene;

    [Tooltip("Name of the Area 3 scene")]
    [SerializeField] string m_area3Scene;

    [Tooltip("Name of Main Menu scene")]
    [SerializeField] string m_menuScene;

    //Loads the area 1
    public void GoToArea1 ()
    {
        SceneManager.LoadScene(m_area1Scene);
    }

    // Loads the area 2
    public void GoToArea2()
    {
        SceneManager.LoadScene(m_area2Scene);
    }

    // Load the area 3
    public void GoToArea3()
    {
        SceneManager.LoadScene(m_area3Scene);
    }

    // Loads the Hub
    public void GoToHUB()
    {
        SceneManager.LoadScene(m_hubScene);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(m_menuScene);
    }
}
