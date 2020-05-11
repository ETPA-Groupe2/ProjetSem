/******************************************************
*       Made by Iohannes Mboumba                      *  
*                                                     *
/*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "New Item Object", menuName = "Inventory System/Item/New Item")]
public class s_ItemObject : ScriptableObject 
{
    [Tooltip("Texture 2D of the item")]
    public Texture2D m_itemTexture;

    [Tooltip("Type of the item")]
    public s_EnumType m_type;

    [Tooltip("The sound when the item is picked")]
    public AudioClip m_itemPickedSound;

    [Tooltip("The sound when the item is used")]
    public AudioClip m_itemUsedSound;

    [Tooltip("The name of the item")]
    public string m_name;

    [Tooltip("The description of the item")]
    [TextArea(15, 20)]
    public string m_description;    
}