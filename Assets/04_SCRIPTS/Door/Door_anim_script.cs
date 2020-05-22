﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GD2Lib;

public class Door_anim_script : MonoBehaviour
{
    [Tooltip("Put the GameObject to animate here")]
    [SerializeField] private Animator m_anim;
    [SerializeField] GD2Lib.Event m_eventAnim;

    [HideInInspector]
    public bool m_noButtonEnabled = false;

    private void OnEnable()
    {
        if (m_eventAnim != null)
            m_eventAnim.Register(PlayAnim);
            m_noButtonEnabled = true;
    }

    private void OnDisable()
    {
        //Unregister the event
        if (m_eventAnim != null)
            m_eventAnim.Unregister(PlayAnim);
            m_noButtonEnabled = false;
    }



    void PlayAnim(GD2Lib.Event p_event, object[] p_params)
    {
        m_anim.Play("DoorIsOpen");
    }
}
