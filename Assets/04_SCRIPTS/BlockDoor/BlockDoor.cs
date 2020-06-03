/******************************************************
*       Made by Johann Theron                         *  
*                                                     *
/*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDoor : MonoBehaviour
{
    [Tooltip("Put the Door_anim_script here")]
    [SerializeField] Door_anim_script m_door;

    [Tooltip("Put the GameObject to animate here")]
    [SerializeField] private Animator m_anim;

    bool m_canClose = true;

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Glide"))
        {
            m_canClose = false;
            Debug.Log("CANT CLOSE");
        }   
    }

    void OnTriggerExit(Collider other)
    {

        if (other.gameObject.CompareTag("Glide"))
        {
            m_canClose = true;
            Debug.Log("CAN CLOSE");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown("o"))
        {
            m_anim.Play("DoorOpen");
        }

        if (Input.GetKeyDown("c") && m_canClose == true)
        {
            m_anim.Play("DoorClose");
        }

        if (m_canClose == true && m_door.m_noButtonEnabled == false)
        {
            m_anim.Play("DoorClose");
        }
    }
}
