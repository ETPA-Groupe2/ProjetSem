using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "New Transform Var", menuName = "ProjectLib/New Transform Var")]
public class s_TransformVar : ScriptableObject
{
    private Transform m_value;
    public Transform Value
    {
        get{return m_value;}
        set{m_value = value; if(onValueChange != null) onValueChange(m_value);}
    }

    public Action<Transform> onValueChange;
}
