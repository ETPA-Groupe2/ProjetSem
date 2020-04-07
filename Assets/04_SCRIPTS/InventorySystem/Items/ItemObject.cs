using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Equipment,
    Ressource,
    Food
}

public abstract class ItemObject : ScriptableObject 
{
    [Tooltip("Texture 2D of the item")]
    public Texture2D m_itemTexture;

    [Tooltip("Type of the item")]
    public ItemType m_type;

    [Tooltip("The sound when the item is picked")]
    public AudioClip m_itemPickedSound;

    [Tooltip("The sound when the item is used")]
    public AudioClip m_itemUsedSound;

    [Tooltip("The description of the item")]
    [TextArea(15, 20)]
    public string m_description;    
}
