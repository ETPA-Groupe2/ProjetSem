using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimTurbines : MonoBehaviour
{

    [SerializeField] private Animator m_anim;
  
    void Start()
    {
        m_anim.Play("TurbinesOn");
    }
}
