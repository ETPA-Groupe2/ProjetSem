using UnityEngine;

public abstract class InventoryItem : HotBarItem
{
    [Header("Item Data")]
    [Min(0)]private int m_sellPrice = 1;
    [Min(1)]private int m_maxStack = 1;

    public override string ColouredName
    {
        get{return Name;}
    }

    public int SellPrice => m_sellPrice;

    public int MaxStack => m_maxStack;
}
