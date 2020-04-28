/******************************************************
*       Made by Iohannes Mboumba                      *  
*                                                     *
/*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipement Type", menuName = "Inventory System/Item Type/Equipement")]
public class s_Equipement : s_EnumType
{
    [Tooltip("Amount of modification dealt to the overall state.")]
    [Range(0f, 100f)]
    public float m_statModifier = 5f;

    [Tooltip("Check if the item has been equiped.")]
    public bool m_hasEquip = false;
}
