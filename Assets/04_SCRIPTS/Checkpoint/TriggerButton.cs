/******************************************************
*       Made by Johann Theron                         *  
*                                                     *
/*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerButton : MonoBehaviour
{
    /*[Tooltip("Put here the player transform")]
    [SerializeField] Transform m_player;
    [Tooltip("Put here the navmesh gameObject")]*/

    public void RequestReload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}