using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GD2Lib;

public class Door_anim_script : MonoBehaviour
{
    [SerializeField] private Animator m_anim;
    [SerializeField] GD2Lib.Event m_eventAnim;

    private void OnEnable()
    {
        if (m_eventAnim != null)
            m_eventAnim.Register(PlayAnim);
    }

    private void OnDisable()
    {
        //Unregister the event
        if (m_eventAnim != null)
            m_eventAnim.Unregister(PlayAnim);
    }



    void PlayAnim(GD2Lib.Event p_event, object[] p_params)
    {
        Debug.Log("yakalelo ");
        m_anim.Play("DoorIsOpen");
    }
}
