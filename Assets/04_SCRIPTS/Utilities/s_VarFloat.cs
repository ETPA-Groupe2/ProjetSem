using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "New Float Var", menuName = "ProjectLib/New Float Var")]
public class s_VarFloat : ScriptableObject
{
    public float m_value;
    public float Value
    {
        get { return m_value; }
        set { m_value = value; if (onValueChange != null) onValueChange(m_value); }
    }

    public Action<float> onValueChange;
}

