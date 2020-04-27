/******************************************************
*       Made by Pauline Barbet & Iohannes Mboumba     *  
*                                                     *
/*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public Camera m_cam;
    public UnityEngine.AI.NavMeshAgent m_agent;

    public s_InventoryObject m_inventory;

    public VarBool m_hasTaken;

    private void Start()
    {
        m_agent = GetComponent<NavMeshAgent>();
        m_hasTaken.Value = false;
    }

    private void FollowNavMesh()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 10000))
            {
                Debug.Log("WALKING THERE");
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
