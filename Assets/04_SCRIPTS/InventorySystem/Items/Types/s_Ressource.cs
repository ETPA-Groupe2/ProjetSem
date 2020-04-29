/******************************************************
*       Made by Iohannes Mboumba                      *  
*                                                     *
/*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ressource Type", menuName = "Inventory System/Item Type/Ressources")]
public class s_Ressource : s_EnumType
{
   [Tooltip("The drop percentage of the ressource.")]
   [Range(0f, 100f)]
   [SerializeField] private float m_dropPercentage = 100f;

   [Tooltip("The rarity of the ressource.")]
   [SerializeField] private s_EnumType m_rarity;
}
