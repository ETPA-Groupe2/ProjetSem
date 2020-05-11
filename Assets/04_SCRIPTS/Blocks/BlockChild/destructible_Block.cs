using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GD2Lib;

public class destructible_Block : Blocks
{
    [SerializeField] private Animator m_anim;
    [SerializeField] private GameObject m_Ressources;

    public override void handleReaction(GD2Lib.Event p_event, object[] p_params)
    {
       
        m_anim.Play("cube_destroy");
        Debug.Log("yakalelo yakalelo");
        Instantiate(m_Ressources, transform.position, transform.rotation);
        if(TryGetComponent<Collider>(out Collider myCollider))
        {
            myCollider.enabled = false;
        }
    }

}
