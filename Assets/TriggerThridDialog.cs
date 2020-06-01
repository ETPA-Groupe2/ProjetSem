using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// made by Anna Deleforge //

public class TriggerThridDialog : MonoBehaviour
{

    public bool m_isTriggered = false;
    public GameObject m_ThirdDialogue;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            m_isTriggered = true;
            Debug.Log(m_isTriggered);
            m_ThirdDialogue.SetActive(true);

        }
    }
}




