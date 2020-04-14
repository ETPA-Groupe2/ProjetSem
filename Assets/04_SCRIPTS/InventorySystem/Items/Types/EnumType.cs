using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item Type", menuName = "Inventory System/Item Type/New Item Type")]
public class EnumType : ScriptableObject
{
    //This is used to create the type of an Item for the Designers.

    [Tooltip("The name of the type")]
    public string m_nameType;

    [Tooltip("The description of the type")]
    [TextArea(15, 20)]
    public string m_description;   
}
