/******************************************************
*       Made by Iohannes Mboumba                      *  
*                                                     *
/*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Consumable Type", menuName = "Inventory System/Item Type/Consumable")]
public class s_Consumable : s_EnumType
{
    [Tooltip("Amount of modification dealt to the overall state.")]
    [Range(0f, 100f)]
    [SerializeField] private float m_statModifier = 5f;

    [Tooltip("Check if the item has been used.")]
    [SerializeField] private bool m_hasUse = false;
}
