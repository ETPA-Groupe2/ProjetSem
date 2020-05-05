using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerButton : MonoBehaviour
{
    [Tooltip("Please set the player spawn position")]
    public Vector3 m_lastCheckpoint;
    [SerializeField] Transform m_player;

    public void RequestReload()
    {
        m_player.transform.position = m_lastCheckpoint;
    }
}
