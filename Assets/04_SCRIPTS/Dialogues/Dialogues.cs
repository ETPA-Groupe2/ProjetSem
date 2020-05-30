using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogues : MonoBehaviour
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
    public GameObject m_DialogManager;

    [SerializeField] s_VarBool m_cpDialogue;

   
    void Start()
    {
        if (m_cpDialogue.Value == true)
        {
            StartCoroutine(Type());
            m_zoneButton.SetActive(false);
            m_energyText.SetActive(false);
            m_ImageFond.SetActive(true);
            m_Player.SetActive(false);
        }
        else if(m_cpDialogue.Value == false)
        {
            m_ImageFond.SetActive(false);
            m_continueButton.SetActive(false);
        }
    }

    private void Update()
    {
        if(textDisplay.text == sentences[index] && m_cpDialogue.Value == true)
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

        if(index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }

        else
        {
            textDisplay.text = "";
            m_continueButton.SetActive(false);
            m_zoneButton.SetActive(true);
            m_energyText.SetActive(true);
            m_ImageFond.SetActive(false);
            m_Player.SetActive(true);
            m_DialogManager.SetActive(false);
            m_cpDialogue.Value = false;

        }
    }
}
