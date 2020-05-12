using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerButton : MonoBehaviour
{
    [Tooltip("Set the player spawnpoint position")]
    public Vector3 m_lastCheckpoint;
    [SerializeField] Transform m_player;
   
    [Tooltip("Put the player here")]
    [SerializeField] public PlayerController m_stopNavMesh;

    public void RequestReload()
    {
        m_stopNavMesh.m_loadCheckpoint = true;
        m_player.transform.position = m_lastCheckpoint;
        m_stopNavMesh.m_agent.destination = m_lastCheckpoint;
        Invoke("BoolCheckpoint", 0.1f);
    }

    void BoolCheckpoint()
    {
        m_stopNavMesh.m_loadCheckpoint = false;
    }
}
