using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GD2Lib;

/// <summary>
///  script for increase/decrease area
/// </summary>
public class Zone : MonoBehaviour, IZone
{

    [Header("--- PLAYER'S ZONE SETTINGS ---")]

    [Tooltip("Reference to the Zone GameObject")]
    public GameObject m_sphere;

    [Tooltip("Time at which the zone increase / Decrease")]
    [SerializeField] private float m_timeSpeed;

    ///<summary>New scale of the sphere</summary>
    private Vector3 m_scaleChange;

    ///<summary>Initial scale of the sphere</summary>
    private Vector3 m_initialScale;

    [Header("Script references")]
    //for energy value
    public Energy m_energy;

    [SerializeField] private ZoneSoundManager m_zone;
    [SerializeField] private PlayerAnimationManager m_animManager;
    [SerializeField] private PlayerController m_playerController;
    IEnumerator Lerp;
    IEnumerator LerpBack;

    [HideInInspector]
    [Tooltip("Check if we're triggering the zone")]public bool m_isTrigger = false;
    private bool m_isDead = false;

    [Tooltip("Lerping size of the collider.")] public float m_x, m_y, m_z;

    [SerializeField] private List<GD2Lib.Event> m_event;

    [SerializeField] private List<s_TransformVar> m_vectorCollider;

    private void Start() 
    {
         //We take the initial scale of the sphere
        m_initialScale = m_sphere.transform.localScale;
    }
    

    private void OnTriggerEnter(Collider other) 
    {
        Blocks b = other.GetComponent<Blocks>();
        GlideBlock bg = other.GetComponent<GlideBlock>();
        if(b != null && bg == null)
        {
            for(int i = 0; i<m_event.Count; i++)
            {
                if (b.m_event == m_event[i])
                {
                    m_event[i].Raise();
                }
            }
        }
        else if(bg != null)
        {
            for(int i = 0; i<m_vectorCollider.Count; i++)
            {
                if(bg.m_vectorCollider == m_vectorCollider[i])
                {
                    for(int j = 0; j<m_event.Count; j++)
                    {
                        if (bg.m_event == m_event[j])
                        {
                            m_event[j].Raise(transform.position - m_vectorCollider[i].Value.position);
                        }
                    }
                    
                }
            }
        }
    }


     ///<summaryIt handle the zone activation</summary>
    public void HandleActivation()
    {
        m_isTrigger = true;

        if(m_isDead != true)
        {
            gameObject.SetActive(true);
            m_zone.EnableSound();
            if(m_playerController.m_isMoving == false)
            {
                m_animManager.ZoneAnim();
            }
        }

        if(Lerp != null)
            StopCoroutine(Lerp);
        if(LerpBack != null)
            StopCoroutine(LerpBack);

        Lerp = LerpRoutine();

        StartCoroutine(Lerp);
    }

    ///<summary>It handle the zone deactivation</summary>
    public void HandleDeactivation()
    {
        m_zone.StopZoneSound();
        m_zone.DisableSound();
        if(m_playerController.m_isMoving == false)
        {
            m_animManager.DisableZoneAnim();
        }
        
        m_isTrigger = false;

        if(LerpBack != null)
            StopCoroutine(LerpBack);
        if(Lerp != null)
            StopCoroutine(Lerp);
            
        LerpBack = LerpBackRoutine();

        StartCoroutine(LerpBack);
    }
    
    IEnumerator LerpRoutine()
    {
        m_zone.ZoneSound();
        m_scaleChange = new Vector3(m_x, m_y, m_z);

        while(true)
        {
            m_sphere.transform.localScale = Vector3.Lerp(m_sphere.transform.localScale, m_scaleChange, Time.deltaTime*m_timeSpeed);
           
            if(m_energy.m_energy<0)
            {
                StartCoroutine(LerpBackRoutine());
                yield return false;
            }
            else
            {
                yield return new WaitForEndOfFrame();
            }
        }
    }

    IEnumerator LerpBackRoutine()
    {
        while (true)
        {      
            m_sphere.transform.localScale = Vector3.Lerp(m_sphere.transform.localScale, m_initialScale, Time.deltaTime*m_timeSpeed);    
            if (m_energy.m_energy<=0)
            {
                m_isDead = true;
                gameObject.SetActive(false);
                yield return false;
            }
            else
            {
                yield return new WaitForEndOfFrame();
                gameObject.SetActive(false);
            }
        } 
    }
}
