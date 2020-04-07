using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment Object", menuName = "Inventory System/Items/Equipment")]
public class s_EquipmentObject : ItemObject
{
    public float m_radiusModifier;
    public enum EquipmentRadiusType
    {
        Default,
        Blue, 
        Red,
        White
    }
    
    public EquipmentRadiusType radiusType;
    public void Awake() 
    {
        type = ItemType.Equipment;
        radiusType = EquipmentRadiusType.Default;
    }
}
