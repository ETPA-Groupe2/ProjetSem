/******************************************************
*       Made by Iohannes Mboumba                      *  
*                                                     *
/*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "New Bool Var", menuName = "ProjectLib/New Bool Var")]
public class VarBool : ScriptableObject
{
    private bool m_value;
    public bool Value
    {
        get{return m_value;}
        set{m_value = value; if(onValueChange != null) onValueChange(m_value);}
    }

    public Action<bool> onValueChange;
}
