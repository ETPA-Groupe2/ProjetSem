using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item Object", menuName = "Inventory System/Item/New Item")]
public class ItemObject : ScriptableObject 
{
    [Tooltip("Texture 2D of the item")]
    public Sprite m_itemTexture;

    [Tooltip("Type of the item")]
    public EnumType m_type;

    [Tooltip("The sound when the item is picked")]
    public AudioClip m_itemPickedSound;

    [Tooltip("The sound when the item is used")]
    public AudioClip m_itemUsedSound;

    [Tooltip("The name of the item")]
    public string m_name;

    [Tooltip("The description of the item")]
    [TextArea(15, 20)]
    public string m_description;    

    [Min(0)]private int m_sellPrice = 1;
    [Min(1)]private int m_maxStack = 1;
    
    public int SellPrice => m_sellPrice;

    public int MaxStack => m_maxStack;
}