using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Handles the energy behaviour
/// </summary>
public class Energy : MonoBehaviour
{
    [Header("Energy attributes")]
    [Tooltip("The base quantity of energy")]
    [SerializeField] public float m_energy = 100f;
    [Tooltip("The maximum quantity of energy")]
    [SerializeField] private float m_maxEnergy = 100f;
    [Tooltip("The minimum quantity of energy")]
    [SerializeField] private float m_minEnergy = 0f;


    [Header("Display attributes")]
    [Tooltip ("Text in which you want to display the energy quantity")]
    [SerializeField] private Text m_displayEnergy;

    // Booleans to check if the energy is at max or min
    private bool m_maxReached = true;
    private bool m_minReached = false;

    private float m_timer = 0f;
    [Header("Timer properties")]
    [Tooltip("Time between each change of values of the energy")]
    [SerializeField] private float m_waitTime=0.1f;
    [Header("Sphere properties")]
    [Tooltip("Collider of the sphere")]
    [SerializeField] private Collider_Change m_collider;



    void Update()
    {
        //Displays the energy
        m_displayEnergy.text = "ENERGY: " + m_energy + "/100";

        //Increases the size of the sphere
        if (m_collider.m_isTrigger == true && m_minReached == false)
        {
            m_timer += Time.deltaTime;
            if (m_timer > m_waitTime)
            {
                m_timer = m_timer - m_waitTime;
                m_energy--;
            }
        }

        /*//Reduces the size of the sphere
        if (m_collider.m_isTrigger == false && m_maxReached == false)
        {
            m_timer += Time.deltaTime;
            if (m_timer > m_waitTime)
            {
                m_timer = m_timer - m_waitTime;
                m_energy++;
            }
        }*/

        #region EnergyBooleans
        //Booleans to check if the energy is at minimum or maximum
        if(m_energy>=100f)
        {
            m_maxReached = true;
        }
        else
        {
            m_maxReached = false;
        }

        if(m_energy<=0f)
        {
            m_minReached = true;
        }
        else
        {
            m_minReached = false;
        }
        #endregion EnergyBooleans
    }
}
