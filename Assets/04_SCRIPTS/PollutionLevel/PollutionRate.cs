/******************************************************
*       Made by Johann Theron                         *  
*                                                     *
/*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PollutionRate : MonoBehaviour
{
    [Tooltip("Insert the text you want to display the pollution level")]
    public Text m_pollutionLevelText;

    [Tooltip("Put the GlobalPollution float var")]
    [SerializeField] s_VarFloat m_globalPollution;

    [Header("Minimal Pollution levels of the intervals")]

    [Tooltip("Minimal pollution level to be in the S Rate interval")]
    [SerializeField] private float m_minScoreRateS;
    [Tooltip("Minimal pollution level to be in the A+ Rate interval")]
    [SerializeField] private float m_minScoreRateAPlus;
    [Tooltip("Minimal pollution level to be in the A Rate interval")]
    [SerializeField] private float m_minScoreRateA;
    [Tooltip("Minimal pollution level to be in the B Rate interval")]
    [SerializeField] private float m_minScoreRateB;
    [Tooltip("Minimal pollution level to be in the C Rate interval")]
    [SerializeField] private float m_minScoreRateC;
    [Tooltip("Minimal pollution level to be in the D Rate interval")]
    [SerializeField] private float m_minScoreRateD;
    [Tooltip("Minimal pollution level to be in the E Rate interval")]
    [SerializeField] private float m_minScoreRateE;

    [HideInInspector]
    public string m_rateString;

    void Update()
    {
        m_pollutionLevelText.text = "Niveau de pollution : " + m_globalPollution.Value;
    }

    public void FinalRating()
    {
        #region CheckPollutionLevel
        if (m_globalPollution.Value >= m_minScoreRateS && m_globalPollution.Value <= m_minScoreRateAPlus-1f)
        {
            m_rateString = "S";
        }
        if (m_globalPollution.Value >= m_minScoreRateAPlus && m_globalPollution.Value <= m_minScoreRateA-1f)
        {
            m_rateString = "A+";
        }
        if (m_globalPollution.Value >= m_minScoreRateA && m_globalPollution.Value <= m_minScoreRateB-1f)
        {
            m_rateString = "A";
        }
        if (m_globalPollution.Value >= m_minScoreRateB && m_globalPollution.Value <= m_minScoreRateC-1f)
        {
            m_rateString = "B";
        }
        if (m_globalPollution.Value >= m_minScoreRateC  && m_globalPollution.Value <= m_minScoreRateD-1f)
        {
            m_rateString = "C";
        }
        if (m_globalPollution.Value >= m_minScoreRateD && m_globalPollution.Value <= m_minScoreRateE-1f)
        {
            m_rateString = "D";
        }
        if (m_globalPollution.Value >= m_minScoreRateE)
        {
            m_rateString = "E";
        }
        #endregion
    }
}
