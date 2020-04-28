using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  script for increase/decrease area
/// </summary>
public class Collider_Change : MonoBehaviour
{
    //Sphere collider for the trigger button
    SphereCollider m_collider;
    public GameObject m_sphere;
    // slowdown time
    [SerializeField]private float m_timeSpeed;
    //increase scale's sphere
    [SerializeField] private Vector3 m_scaleChange;
    // decrease scale's sphere
    [SerializeField] private Vector3 m_initialScale;
    //limit increase/decrease scale of the sphere
    [SerializeField] private float m_sphereRad = 0.0f;

    [SerializeField] private s_EnumType m_zoneType;
    //for energy value
    public Energy m_energy;

    IEnumerator Lerp;
    IEnumerator LerpBack;

    [Tooltip("Check if we're triggering the zone")]public bool m_isTrigger = false;

    [Tooltip("Scaling of the collider.")] public float m_x, m_y, m_z;




    void Start()
    {
        // call the collider
        m_collider = GetComponent<SphereCollider>();
        m_initialScale = transform.localScale;
    }


    public void OnTrigger()
    {
        m_isTrigger = true;

        if(Lerp != null)
            StopCoroutine(Lerp);
        if(LerpBack != null)
            StopCoroutine(LerpBack);

        Lerp = LerpRoutine();

        StartCoroutine(Lerp);
    }

    public void OffTrigger()
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


    private void OnTriggerEnter(Collider other) 
    {
        Blocks type = other.GetComponent<Blocks>();

        if(type)
        {
            type.CheckType(m_zoneType);
        }
    }

}
