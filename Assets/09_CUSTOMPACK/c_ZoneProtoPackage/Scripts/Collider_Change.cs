using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GD2Lib;

/// <summary>
///  script for increase/decrease area
/// </summary>
public class Collider_Change : MonoBehaviour, IZone
{

    [Header("--- PLAYER'S ZONE SETTINGS ---")]

    [Tooltip("Reference to the Zone GameObject")]
    public GameObject m_sphere;

    [Tooltip("Time at which the zone increase / Decrease")]
    [SerializeField]private float m_timeSpeed;

    ///<summary>New scale of the sphere</summary>
    private Vector3 m_scaleChange;

    ///<summary>Initial scale of the sphere</summary>
    private Vector3 m_initialScale;

    //for energy value
    public Energy m_energy;
    
    IEnumerator Lerp;
    IEnumerator LerpBack;

    [Tooltip("Check if we're triggering the zone")]public bool m_isTrigger = false;

    [Tooltip("Lerping size of the collider.")] public float m_x, m_y, m_z;

    [SerializeField] private List<GD2Lib.Event> m_event;

    private void Start() 
    {
         //We take the initial scale of the sphere
        m_initialScale = m_sphere.transform.localScale;
    }
    

    private void OnTriggerEnter(Collider other) 
    {
        Blocks b = other.GetComponent<Blocks>();
        if(b != null)
        {
            for(int i = 0; i<m_event.Count; i++)
            {
                if(b.m_event == m_event[i])
                {
                    m_event[i].Raise();
                }
            }
        }
    }

     ///<summaryIt handle the zone activation</summary>
    public void HandleActivation()
    {
        m_isTrigger = true;

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
        m_scaleChange = new Vector3(m_x, m_y, m_z);

        while(true)
        {
            m_sphere.transform.localScale = Vector3.Lerp(m_sphere.transform.localScale, m_scaleChange, Time.deltaTime*m_timeSpeed);

            if(m_energy.m_energy>0)
            {
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
       while(true)
        {
            m_sphere.transform.localScale = Vector3.Lerp(m_sphere.transform.localScale, m_initialScale, Time.deltaTime*m_timeSpeed);

            if(m_energy.m_energy<=0)
            {
                yield return false;
            }
            else
            {
                yield return new WaitForEndOfFrame();
            }
        } 
    }
}
