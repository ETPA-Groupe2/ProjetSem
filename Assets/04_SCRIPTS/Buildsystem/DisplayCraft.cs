using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayCraft : MonoBehaviour
{
    [Header("--- BUILD ON PARAMETER ---")]

    [SerializeField] private s_VarBool m_buildModeOn;

    [Header("-- Bomb Parameters -- ", order = 1)]

    [SerializeField] private s_IntVar m_bombeResourceInt;
    [SerializeField] private Text m_bombText; 
    [SerializeField] private Button m_bombButton;
    [SerializeField] private s_VarBool m_canBuildBomb;


    [Header("-- Glide Parameters -- ", order = 1)]

    [SerializeField] private s_IntVar m_glideResourceInt;
    [SerializeField] private Text m_glideText; 
    [SerializeField] private Button m_glideButton;
    [SerializeField] private s_VarBool m_canBuildGlide;
    

    [Header("-- Generator Parameters -- ", order = 1)]
    [SerializeField] private s_IntVar m_generatorResourceInt;
    [SerializeField] private Text m_genText; 
    [SerializeField] private Button m_genButton;
    [SerializeField] private s_VarBool m_canBuildGen;



    private void Start() 
    {
        m_bombeResourceInt.Value = 0;
        m_glideResourceInt.Value = 0;
        m_generatorResourceInt.Value = 0;
    }

    private void Update() 
    {
       m_bombText.text = m_bombeResourceInt.Value+"/2"; 

       m_glideText.text = m_glideResourceInt.Value+"/4"; 

       m_genText.text = m_generatorResourceInt.Value+"/4"; 

       if(m_bombeResourceInt.Value>=2 && m_buildModeOn.m_value == false)
        {
            ColorBlock colors = m_bombButton.colors;
            colors.normalColor = new Color32(204, 255, 206, 255);
            m_bombButton.colors = colors;
            m_bombButton.interactable = true;
            m_canBuildBomb.Value = true;
        }
        else if(m_buildModeOn.m_value == true)
        {
            m_bombButton.interactable = false;
        }
        else
        {
            m_bombButton.interactable = false;
            m_canBuildBomb.Value = false;
        }

        if(m_glideResourceInt.Value>=4)
        {
            ColorBlock colors = m_glideButton.colors;
            colors.normalColor = new Color32(204, 255, 206, 255);
            m_glideButton.colors = colors;
            m_glideButton.interactable = true;
            m_canBuildGlide.Value = true;
        }
        else
        {
            m_glideButton.interactable = false;
            m_canBuildGlide.Value = false;
        }

        if(m_generatorResourceInt.Value>=4)
        {
            ColorBlock colors = m_genButton.colors;
            colors.normalColor = new Color32(204, 255, 206, 255);
            m_genButton.colors = colors;
            m_genButton.interactable = true;
            m_canBuildGen.Value = true;
        }
        else
        {
            m_genButton.interactable = false;
            m_canBuildGen.Value = false;
        }
    }
    
}
