/******************************************************
*       Made by Iohannes Mboumba                      *  
*                                                     *
/*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Craft Recipe", menuName = "Craft System/Craft Recipe")]
public class s_CraftObject : ScriptableObject
{
    public GameObject m_prefab;
    public s_EnumType[] m_types;
}
