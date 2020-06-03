/******************************************************
*       Made by Romain Poussier                       *  
*                                                     *
/*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dissolve_Effect : MonoBehaviour
{

    [SerializeField] Material[] m_mat;
    [SerializeField] Animator m_anim;
    private Renderer m_rend;

    
    void Start()
    {
        m_rend = GetComponent<Renderer>();
        m_rend.enabled = true;
        m_rend.sharedMaterial = m_mat[0];
    }

    void Update()
    {
        if(this.m_anim.GetCurrentAnimatorStateInfo(0).IsName("explosion_anim"))
        {
            m_rend.sharedMaterial = m_mat[1];
            Invoke("destroyGO", 3f);
        }
    }

    public void destroyGO()
    {
        Destroy(gameObject);
    }
}
