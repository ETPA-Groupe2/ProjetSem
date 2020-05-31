/******************************************************
*       Made by Johann Theron & Anna Deleforge        *  
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


    public GameObject m_LetterS;
    public GameObject m_LetterA;
    public GameObject m_LetterB;
    public GameObject m_LetterC;
    public GameObject m_LetterD;
    public GameObject m_LetterE;

    public GameObject m_tableauFond;

    void Update()
    {
        m_pollutionLevelText.text = "Niveau de pollution : " + m_globalPollution.Value;
    }

    public void FinalRating()
    {
        Debug.Log("ALLO");
        #region CheckPollutionLevel
        if (m_globalPollution.Value >= m_minScoreRateS && m_globalPollution.Value <= m_minScoreRateA - 1f)
        {
            m_rateString = "S";
            m_LetterS.SetActive(true);
            m_tableauFond.SetActive(true);
        }

        if (m_globalPollution.Value >= m_minScoreRateA && m_globalPollution.Value <= m_minScoreRateB - 1f)
        {
            m_rateString = "A";
            m_LetterA.SetActive(true);
            m_tableauFond.SetActive(true);
        }
        if (m_globalPollution.Value >= m_minScoreRateB && m_globalPollution.Value <= m_minScoreRateC - 1f)
        {
            m_rateString = "B";
            m_LetterB.SetActive(true);
            m_tableauFond.SetActive(true);
        }
        if (m_globalPollution.Value >= m_minScoreRateC && m_globalPollution.Value <= m_minScoreRateD - 1f)
        {
            m_rateString = "C";
            m_LetterC.SetActive(true);
            m_tableauFond.SetActive(true);
        }
        if (m_globalPollution.Value >= m_minScoreRateD && m_globalPollution.Value <= m_minScoreRateE - 1f)
        {
            m_rateString = "D";
            m_LetterD.SetActive(true);
            m_tableauFond.SetActive(true);
        }
        if (m_globalPollution.Value >= m_minScoreRateE)
        {
            m_rateString = "E";
            m_LetterE.SetActive(true);
            m_tableauFond.SetActive(true);
        }
        #endregion
    }
}
