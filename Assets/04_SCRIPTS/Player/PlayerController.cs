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
    [Header("--- THE PLAYER'S PARAMETERS ---")]

    public Camera m_cam;
    public UnityEngine.AI.NavMeshAgent m_agent;

    public s_InventoryObject m_inventory;

    public s_VarBool m_hasTaken;

    [Header("--- THE NUMBER OF RESOURCES IN INVENTORY ---")]

    [Tooltip("This is the number for the bomb resources")]
    public s_IntVar m_bombeResource;

    [Tooltip("This is the number for the glide resources")]
    public s_IntVar m_glideResource;

    [Tooltip("This is the number for the generator resources")]
    public s_IntVar m_generatorResource;

    [SerializeField] private s_VarBool m_canBuild;

    [SerializeField] private LayerMask m_movingLayer;

    public bool m_loadCheckpoint = false;

    Vector3 m_oldPos;

    [HideInInspector]
    public bool m_isMoving = false;
    private PlayerAnimationManager m_animManager;


    private void Start()
    {
        m_agent = GetComponent<NavMeshAgent>();
        m_hasTaken.Value = false;
        m_animManager = GetComponent<PlayerAnimationManager>();
    }

    public void FollowNavMesh()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(m_cam.ScreenPointToRay(Input.mousePosition), out hit, 1000f))
            {
                m_agent.destination = hit.point;
            }
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        var item = other.GetComponent<Item>();

        if(item)
        {
            m_inventory.AddItem(item.m_item);
            Destroy(other.gameObject);
            m_hasTaken.Value = true;
        }

        if(other.TryGetComponent<IBombResource>(out IBombResource bomb))
        {
            m_bombeResource.Value++;
            Destroy(other.gameObject);
        }

        else if(other.TryGetComponent<IGlideResource>(out IGlideResource glide))
        {
            m_glideResource.Value++;
            Destroy(other.gameObject);
        }

        else if(other.TryGetComponent<IGeneratorResources>(out IGeneratorResources generator))
        {
            m_generatorResource.Value++;
            Destroy(other.gameObject);
        }
    }

    private void Update()
    {
        if(m_canBuild.Value == false && m_loadCheckpoint == false)
        {
            FollowNavMesh();
        }

        if(m_oldPos != transform.position)
        {   
            if(m_isMoving == false)
            {
                m_animManager.RunAnim();
            }
            m_isMoving = true;       
        }
        else
        {
            m_animManager.StopRunAnim();
            m_isMoving = false;
        }
        m_oldPos = transform.position;
        Debug.Log(m_isMoving);
    }
}
