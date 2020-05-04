using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GD2Lib;

public class RedBlock : Blocks
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
            if(nearbyObject.TryGetComponent<Animator>(out Animator anim))
            {
                anim.Play("explosion_anim");
            }
        }

        Destroy(gameObject);
        m_exploded = true;

    }

}
