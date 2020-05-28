using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TriggerRedScreens : MonoBehaviour
{

    
    public GameObject m_ScreensTrigger;
    public GameObject m_RedLight;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Zone"))
        {
            m_ScreensTrigger.SetActive(true);
            m_RedLight.SetActive(true);

        }
    }
}

