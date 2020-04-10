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
    [SerializeField]GameObject m_sphere;
    // slowdown time
    private float m_timeScale = 0.5f;
    //increase scale's sphere
    private Vector3 m_scaleChange;
    // decrease scale's sphere
    private Vector3 m_scaleDown;
    //limit increase/decrease scale of the sphere
    private float m_sphereRad = 0.0f;
    //for energy value
    public Energy m_energy;

 
   
   
    void Start()
    {
        // call the collider
        m_collider = GetComponent<SphereCollider>();
        // value of vector
        m_scaleChange = new Vector3(2f, 2f, 2f);
        m_scaleDown = new Vector3(-2f, -2f, -2f);
    }


    void FixedUpdate()
    {
        //value for fix time
        float progress = 0;
        //increase scale of sphere
        if(m_collider.isTrigger == true && m_sphereRad<=8f && m_energy.m_energy>0)
        {
            Debug.Log("increasing");
         //increment m_sphereRad for limit increase scale sphere
            m_sphereRad++;
            m_sphere.transform.localScale += m_scaleChange;
           //slowing time of increase/decrease
            progress += Time.deltaTime * m_timeScale;
            
        }
        //decrease scale of sphere
        if (m_collider.isTrigger == false && m_sphereRad >= 0.0f || m_energy.m_energy<=0)
        {
        //fix decrease scale value
            if(m_sphere.transform.localScale.x >= 2f && m_sphere.transform.localScale.y >= 2f && m_sphere.transform.localScale.z >= 2f)
            {
                Debug.Log("reducing");
        //decrement for reset value of m_sphereRad
                m_sphereRad--;
                m_sphere.transform.localScale += m_scaleDown;
            }
        }
    }
}
