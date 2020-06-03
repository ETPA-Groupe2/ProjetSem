/******************************************************
*       Made by Anna Delforge                         *  
*                                                     *
/*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FourthDialog : MonoBehaviour
{

    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;

    public GameObject m_continueButton;
    public GameObject m_zoneButton;
    public GameObject m_energyText;
    public GameObject m_ImageFond;
    public GameObject m_Player;
    public GameObject m_DialogueManager;
    public GameObject m_CraftBombButton;
    public GameObject m_bombText;
    public GameObject m_TableaudesScores;

    [SerializeField] s_VarBool m_cpDialogue4;

    void Start()
    {
        if (m_cpDialogue4.Value == true)
        {
            StartCoroutine(Type());
            m_zoneButton.SetActive(false);
            m_energyText.SetActive(false);
            m_ImageFond.SetActive(true);
            m_Player.SetActive(false);
            m_CraftBombButton.SetActive(false);
            m_bombText.SetActive(false);
        }
        else if (m_cpDialogue4.Value == false)
        {
            m_ImageFond.SetActive(false);
            m_continueButton.SetActive(false);
            m_CraftBombButton.SetActive(true);
            m_bombText.SetActive(true);
        }

    }

    private void Update()
    {
        if (textDisplay.text == sentences[index])
        {
            m_continueButton.SetActive(true);
        }
    }


    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {
        m_continueButton.SetActive(false);

        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }

        else
        {
            textDisplay.text = "";
            m_continueButton.SetActive(false);

            m_energyText.SetActive(false);
            m_ImageFond.SetActive(false);
            
            m_DialogueManager.SetActive(false);

            m_TableaudesScores.SetActive(true);
            m_cpDialogue4.Value = false;


        }
    }
}
