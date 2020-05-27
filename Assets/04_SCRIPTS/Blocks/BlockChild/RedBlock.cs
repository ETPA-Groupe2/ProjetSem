
/******************************************************
*       Made by Iohannes Mboumba & Romain Poussier    *  
*                                                     *
/*****************************************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GD2Lib;

public class RedBlock : Blocks , IExplosion
{

    /// <summary>
    /// script for bomb bloc reaction
    /// </summary>
    
        // Fx explosion of Bomb bloc
    [SerializeField] GameObject m_explosionFx;
   
        //check if the explosion took place
    private bool m_exploded = false;
        // radius of the explosion 
    [SerializeField] private float m_blastRadius = 5f;

    [SerializeField] private float TimeBeforeExplosion = 3f;

    [Tooltip("Put the GlobalPollution float var")]
    [SerializeField] s_VarFloat m_globalPollution;

    [SerializeField] AudioSource m_explosionSound;
    [SerializeField] AudioSource m_beepSound;

    [SerializeField] private MeshRenderer m_meshRenderer;

    [SerializeField] private Animator m_anim;

    GameObject m_fx;

    bool m_soundAlreadyPlayed;

   

    public override void handleReaction(GD2Lib.Event p_event, object[] p_params)
    {
            // call void explosion with a delay of 3s
            m_anim.Play("BombColorChange");
            PlaySoundBeep();
            Invoke("Explosion", TimeBeforeExplosion);
            Invoke("PlaySoundExplosion", TimeBeforeExplosion - 0.1f);     
    }

    void PlaySoundExplosion()
    {
        //Plays the explosion sound
        m_explosionSound.Play(0);
    }

    void PlaySoundBeep ()
    {
        if (m_soundAlreadyPlayed == false)
        {
            m_beepSound.Play(0);
            m_soundAlreadyPlayed = true;
        }
    }
    public void Explosion()
    {
        // Increases the pollution level
        m_globalPollution.Value += m_pollutionLvl;
        //call fx explosion on the position of the cube 
        m_fx = Instantiate(m_explosionFx, transform.position, transform.rotation);
        //call animation and explosion of each game object in the blast radius 
        Collider[] colliders = Physics.OverlapSphere(transform.position, m_blastRadius);
        foreach (Collider nearbyObject in colliders)
        {
        //chain reaction of explosion 
            IExplosion e = nearbyObject.GetComponent<IExplosion>();

            if (nearbyObject.TryGetComponent<Animator>(out Animator anim))
            {
                anim.Play("explosion_anim");
            }
            if(e != null)
            {
                e.onTouch();
            }
        }
        //Disable the mesh
        m_meshRenderer.enabled = false;
        //Destroy the object once the sound is played
        Invoke("DestroyObject", 1f);
        m_exploded = true;  
    }

    void DestroyObject()
    {
        Destroy(m_fx);
        Destroy(gameObject);
    }

    public void onTouch()
    {
        if (m_event != null)
            m_event.Raise();
    }

}
