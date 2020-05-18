using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GD2Lib;

public class destructible_Block : Blocks
{
    [SerializeField] private Animator m_anim;
    [SerializeField] private GameObject m_Ressources;

    AudioSource m_destroySound;

    void Start()
    {
        m_destroySound = GetComponent<AudioSource>();
    }
    public override void handleReaction(GD2Lib.Event p_event, object[] p_params)
    {
        m_destroySound.Play(0);
        m_anim.Play("cube_destroy");
        Instantiate(m_Ressources, transform.position, transform.rotation);
        if(TryGetComponent<Collider>(out Collider myCollider))
        {
            myCollider.enabled = false;
        }
    }

}
