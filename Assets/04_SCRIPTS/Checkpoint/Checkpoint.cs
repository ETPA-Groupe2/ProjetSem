/******************************************************
*       Made by Johann Theron                         *  
*                                                     *
/*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [Header("Button reference")]
    [Tooltip("Put here the button you want to use to reload the last checkpoint")]
    [SerializeField] private TriggerButton m_triggerButton;

    void OnTriggerEnter(Collider other)
    {
      if (other.gameObject.CompareTag ("Player"))
        {
            Debug.Log("CHECKPOINT PASSED");
            CPPersistence.Instance.SetSpawnpoint (gameObject.transform.position);
        }
    }
}
