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
    [Tooltip("Put here the player transform")]
    [SerializeField] Transform m_player;
    [Tooltip("Put here the navmesh gameObject")]
    [SerializeField] GameObject m_navmesh;

    void Start()
    {  
        m_player.transform.position = CPPersistence.Instance.SpawnPoint;
        Debug.Log(CPPersistence.Instance.SpawnPoint);

        Invoke("EnableNavMesh", 0.1f);
    }

    void EnableNavMesh()
    {
        m_navmesh.SetActive(true);
    }
    public void RequestReload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}