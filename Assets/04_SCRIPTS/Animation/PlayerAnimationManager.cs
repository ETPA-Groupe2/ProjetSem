/******************************************************
*       Made by Johann Theron                         *  
*                                                     *
/*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{
    [Tooltip("Put the GameObject to animate here")]
    [SerializeField] private Animator m_anim;

   public void ZoneAnim()
    {
        m_anim.Play("Enable_Zone");
    }

     public void DisableZoneAnim()
    {
        m_anim.Play("Disable_Zone");
    }

    public void RunAnim()
    {
        m_anim.Play("Start_Run");
    }

    public void StopRunAnim()
    {
        if (m_anim.GetCurrentAnimatorStateInfo(0).IsName("Run"))
            m_anim.Play("Stop_Run");
    }

    //int m_speedHash = Animator.StringToHash("Speed");
    public void IdleAnim()
    {   
        if(m_anim.GetCurrentAnimatorStateInfo(0).IsName("Stop_Run"))
        m_anim.Play("Start_Idle");
        //Set anim
        //m_anim.SetFloat(m_speedHash, 2f);
    }

    public void StopAnim()
    {
        m_anim.enabled = false;
        m_anim.enabled = true;
    }
}
