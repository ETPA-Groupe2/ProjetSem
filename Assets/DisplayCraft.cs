using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GD2Lib;

public class DisplayCraft : MonoBehaviour
{
    [Header("--- THE NUMBER OF RESOURCES IN INVENTORY & PARAMETERS ---")]

    [Header("-- Bomb Parameters -- ", order = 1)]

    [SerializeField] private IntVar m_bombeResourceInt;
    [SerializeField] private Text m_bombText; 
    [SerializeField] private Button m_bombButton;


    [Header("-- Glide Parameters -- ", order = 1)]

    [SerializeField] private IntVar m_glideResourceInt;
    [SerializeField] private Text m_glideText; 
    [SerializeField] private Button m_glideButton;
    

    [Header("-- Generator Parameters -- ", order = 1)]
    [SerializeField] private IntVar m_generatorResourceInt;
    [SerializeField] private Text m_genText; 
    [SerializeField] private Button m_genButton;

    



    private void Start() 
    {
        m_bombeResourceInt.Value = 0;
        m_glideResourceInt.Value = 0;
        m_generatorResourceInt.Value = 0;
    }

    private void Update() 
    {
       m_bombText.text = m_bombeResourceInt.Value+"/2"; 

       m_glideText.text = m_bombeResourceInt.Value+"/4"; 

       m_genText.text = m_bombeResourceInt.Value+"/4"; 

       if(m_bombeResourceInt.Value>=2)
        {
            ColorBlock colors = m_bombButton.colors;
            colors.normalColor = new Color32(204, 255, 206, 255);
            m_bombButton.colors = colors;
        }

        if(m_glideResourceInt.Value>=4)
        {
            ColorBlock colors = m_glideButton.colors;
            colors.normalColor = new Color32(204, 255, 206, 255);
            m_glideButton.colors = colors;
        }

        if(m_generatorResourceInt.Value>=4)
        {
            ColorBlock colors = m_genButton.colors;
            colors.normalColor = new Color32(204, 255, 206, 255);
            m_genButton.colors = colors;
        }
    }
    
}
