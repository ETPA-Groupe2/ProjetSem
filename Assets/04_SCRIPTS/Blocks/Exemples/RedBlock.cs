using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GD2Lib;

public class RedBlock : Blocks , IExplosion
{
    [SerializeField] GameObject m_explosionFx;
    private bool m_exploded = false;
    [SerializeField]private float m_blastRadius = 5f;


    

    public override void handleReaction(GD2Lib.Event p_event, object[] p_params)
    {

        Invoke("Explosion", 3f);
        
    }

    public void Explosion()
    {
        Instantiate(m_explosionFx, transform.position, transform.rotation);
        Collider[] colliders = Physics.OverlapSphere(transform.position, m_blastRadius);
        foreach (Collider nearbyObject in colliders)
        {
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

        Destroy(gameObject);
        m_exploded = true;

    }

    public void onTouch()
    {
        if (m_event != null)
            m_event.Raise();
    }

}
