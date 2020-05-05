using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IntVar", menuName = "ProjectLib/New IntVar")]
public class s_IntVar : ScriptableObject 
{
    [NonSerialized] private int m_value;

    public int Value
    {
        get{return m_value;}
        set{m_value = value;}
    }
}