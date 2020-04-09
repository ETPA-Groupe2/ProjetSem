public interface ItemContainer
{
    ItemSlot AddItem(ItemSlot p_itemSlot);
    void RemoveItem(ItemSlot p_itemSlot);
    void RemoveAt(int p_slotIndex);
    void Swap(int p_indexOne, int p_indexTwo);
    bool HasItem(InventoryItem p_item);
    int GetTotalQuantity(InventoryItem p_item);
}
