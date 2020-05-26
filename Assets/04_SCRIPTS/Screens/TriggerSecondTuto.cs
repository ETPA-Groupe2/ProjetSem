using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TriggerSecondTuto : MonoBehaviour
{

    public bool m_isTriggered = false;
    public GameObject m_SecondDialogue;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            m_isTriggered = true;
            Debug.Log(m_isTriggered);
            m_SecondDialogue.SetActive(true);

        }
    }
}




