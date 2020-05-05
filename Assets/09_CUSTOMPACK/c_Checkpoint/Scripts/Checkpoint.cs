using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    [SerializeField] private TriggerButton m_triggerButton;

    private void Start()
    {
        //m_triggerButton = GameObject.Find("TriggerButton").GetComponent<TriggerButton>();
    }

    void OnTriggerEnter(Collider other)
    {
      if (other.gameObject.CompareTag ("Player"))
        {
            m_triggerButton.m_lastCheckpoint = gameObject.transform.position;
        }
    }
}
