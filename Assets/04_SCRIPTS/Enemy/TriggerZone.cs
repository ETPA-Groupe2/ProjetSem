using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    [SerializeField]
    private int m_attack;

    [SerializeField]
    public int m_attackMax;

    [SerializeField]
    public GameObject m_ennemi;

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Zone")
        {
            m_ennemi.gameObject.GetComponent<Renderer>().material.color = Color.green;
            if(m_attack <= m_attackMax)
            {
                m_attack += 50;
            }
        }
        
        Debug.Log(m_attack);
    }

}
