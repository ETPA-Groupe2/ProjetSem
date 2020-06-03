/******************************************************
*       Made by Romain Poussier                       *  
*                                                     *
/*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GD2Lib;

public class Spawn_Cube : MonoBehaviour
{

    [SerializeField] GameObject m_cube;
    [SerializeField] GD2Lib.Event m_eventSpawn;

    // Update is called once per frame
    private void OnEnable()
    {
        if (m_eventSpawn != null)
            m_eventSpawn.Register(SpawnCube);
    }

    private void OnDisable()
    {
        //Unregister the event
        if (m_eventSpawn != null)
            m_eventSpawn.Unregister(SpawnCube);
    }

    void SpawnCube(GD2Lib.Event p_event, object[] p_params)
    {
        
        Instantiate(m_cube, transform.position, transform.rotation);
    }
}
