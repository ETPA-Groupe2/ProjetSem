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
    [SerializeField] private GameObject m_checkPointFX;

    AudioSource m_cpSound;

    private void Start()
    {
        m_cpSound = GetComponent<AudioSource>();
    }
    void OnTriggerEnter(Collider other)
    {
      if (other.gameObject.CompareTag ("Player"))
        {
            m_cpSound.Play(0);
            Debug.Log("CHECKPOINT PASSED");
            CPPersistence.Instance.SetSpawnpoint (gameObject.transform.position);
            Instantiate(m_checkPointFX,transform.position, transform.rotation);
        }
    }
}
