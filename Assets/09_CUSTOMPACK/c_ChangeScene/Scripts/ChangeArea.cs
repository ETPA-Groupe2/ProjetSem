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
    [SerializeField] string m_HUBScene;

    [Tooltip("Name of the Area 1 scene")]
    [SerializeField] string m_Area1Scene;

    [Tooltip("Name of the Area 2 scene")]
    [SerializeField] string m_Area2Scene;

    [Tooltip("Name of the Area 3 scene")]
    [SerializeField] string m_Area3Scene;

    //Loads the area 1
    public void GoToArea1 ()
    {
        SceneManager.LoadScene(m_Area1Scene);
    }

    // Loads the area 2
    public void GoToArea2()
    {
        SceneManager.LoadScene(m_Area2Scene);
    }

    // Load the area 3
    public void GoToArea3()
    {
        SceneManager.LoadScene(m_Area3Scene);
    }

    // Loads the Hub
    public void GoToHUB()
    {
        SceneManager.LoadScene(m_HUBScene);
    }
}
