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
    [Tooltip("GameObject prefab of the item")]
    public GameObject prefab;

    [Tooltip("Type of the item")]
    public ItemType type;

    [TextArea(15, 20)]
    public string Description;    
}
