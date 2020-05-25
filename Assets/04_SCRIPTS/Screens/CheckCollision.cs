using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollision : MonoBehaviour
{
    [HideInInspector]
    public bool m_isTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Zone"))
        {
            m_isTriggered = true;
            Debug.Log("TRIGGERED");
        }
    }
}
