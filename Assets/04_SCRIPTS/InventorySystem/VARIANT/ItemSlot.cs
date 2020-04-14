public struct ItemSlot
{
    public ItemObject m_item;
    public int m_quantity;

    public ItemSlot(ItemObject p_item, int p_quantity)
    {
        this.m_item = p_item;
        this.m_quantity = p_quantity;
    }

    public static bool operator ==(ItemSlot a, ItemSlot b) {return a.Equals(b);}
    public static bool operator !=(ItemSlot a, ItemSlot b) {return !a.Equals(b);}
}
