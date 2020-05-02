/******************************************************
*       Made by Pauline Barbet & Iohannes Mboumba     *  
*                                                     *
/*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    private PlayerController m_controllers;
    public Camera m_cam;
    public UnityEngine.AI.NavMeshAgent m_agent;

    public s_InventoryObject m_inventory;

    public s_VarBool m_hasTaken;

    private void Start()
    {
        m_agent = GetComponent<NavMeshAgent>();
        m_hasTaken.Value = false;
    }

    public void FollowNavMesh()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 1000f))
            {
                Debug.Log(hit.collider);
                m_agent.destination = hit.point;
            }
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        var item = other.GetComponent<Item>();

        if(item)
        {
            m_inventory.AddItem(item.m_item, 1);
            Destroy(other.gameObject);
            m_hasTaken.Value = true;
        }
    }

    private void Update()
    {
        FollowNavMesh();
    }
}
