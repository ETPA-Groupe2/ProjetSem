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
        m_anim.Play("Stop_Run");
    }
    
    public void RunZoneAnim()
    {
        m_anim.Play("Run_Zone");
    }

    public void IdleAnim()
    {
        m_anim.Play("Start_Idle");
    }

    public void StopAnim()
    {
        m_anim.enabled = false;
        m_anim.enabled = true;
    }
}
