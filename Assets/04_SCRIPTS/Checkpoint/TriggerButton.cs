using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerButton : MonoBehaviour
{
    [SerializeField] Transform m_player;
   //[SerializeField] GameObject m_navmesh;

    void Start()
    {  
        m_player.transform.position = CPPersistence.Instance.SpawnPoint;
        Debug.Log(CPPersistence.Instance.SpawnPoint);
        //m_navmesh.SetActive(false);
        //Invoke("EnableNavMesh", 0.1f);
    }

   /* void EnableNavMesh()
    {
        m_navmesh.SetActive(true);
    }*/
    public void RequestReload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}