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
    [SerializeField] private s_VarBool m_destroy;
    private GameObject m_sp;

    AudioSource m_completedSound;

    private void Start()
    {
        m_completedSound = GetComponent<AudioSource>();

        m_sp = GameObject.Find("SpawnPoint");
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            m_completedSound.Play(0);
            m_pollutionRate.FinalRating();

            m_destroy.Value = true;
            Invoke("LoadMenu", 5f);
        }
    }

    void LoadMenu()
    {
        Destroy(m_sp);
        SceneManager.LoadScene("Salle2_V1");
    }
}
