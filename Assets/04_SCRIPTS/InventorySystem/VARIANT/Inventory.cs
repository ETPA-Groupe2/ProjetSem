using UnityEngine;
using System;


public class Inventory : ScriptableObject, ItemContainer
{
    [SerializeField] private ItemSlot[] m_itemSlots = new ItemSlot[20];

    public Action onItemsUpdated = delegate {};

    public ItemSlot AddItem(ItemSlot p_itemSlot)
    {
        for(int i = 0; i < m_itemSlots.Length; i++)
        {
            if(m_itemSlots[i].m_item != null)
            {
                if(m_itemSlots[i].m_item == p_itemSlot.m_item)
                {
                    int slotRemainingSpace = m_itemSlots[i].m_item.MaxStack - m_itemSlots[i].m_quantity;

                    if(p_itemSlot.m_quantity <= slotRemainingSpace)
                    {
                        m_itemSlots[i].m_quantity += p_itemSlot.m_quantity;

                        p_itemSlot.m_quantity = 0;
                        
                        //DELEGATE FOR THE UI
                        onItemsUpdated.Invoke();

                        return p_itemSlot;
                    }
                    else if(slotRemainingSpace > 0)
                    {
                        m_itemSlots[i].m_quantity += slotRemainingSpace;

                        p_itemSlot.m_quantity -= slotRemainingSpace;
                    } 
                }
            }
        }

        for(int i = 0; i < m_itemSlots.Length; i++)
        {
            if(m_itemSlots[i].m_item == null)
            {
                if(p_itemSlot.m_quantity <= p_itemSlot.m_item.MaxStack)
                {
                    m_itemSlots[i] = p_itemSlot;

                    p_itemSlot.m_quantity = 0;

                    //DELEGATE FOR THE UI
                    onItemsUpdated.Invoke();

                    return p_itemSlot;
                }
                else
                {
                    m_itemSlots[i] = new ItemSlot(p_itemSlot.m_item, p_itemSlot.m_item.MaxStack);

                    p_itemSlot.m_quantity -= p_itemSlot.m_item.MaxStack;
                }
            }
        }

        //DELEGATE FOR THE UI
        onItemsUpdated.Invoke();

        return p_itemSlot;
    }

    public int GetTotalQuantity(ItemObject p_item)
    {
        int totalCount = 0;

        foreach(ItemSlot itemSlot in m_itemSlots)
        {
            if(itemSlot.m_item == null) {continue;}
            if(itemSlot.m_item != p_item) {continue;}

            totalCount+= itemSlot.m_quantity;
        }

        return totalCount;
    }

    public bool HasItem(ItemObject p_item)
    {
        foreach(ItemSlot itemSlot in m_itemSlots)
        {
            if(itemSlot.m_item == null) {continue;}
            if(itemSlot.m_item != p_item) {continue;}

            return true;
        }

        return false;
    }

    public void RemoveAt(int p_slotIndex)
    {
        if(p_slotIndex <0 || p_slotIndex > m_itemSlots.Length - 1) {return;}

        m_itemSlots[p_slotIndex] = new ItemSlot();

        //DELEGATE FOR THE UI
        onItemsUpdated.Invoke();
    }

    public void RemoveItem(ItemSlot p_itemSlot)
    {
        for(int i = 0; i < m_itemSlots.Length; i++)
        {
            if(m_itemSlots[i].m_item != null)
            {
                if(m_itemSlots[i].m_item == p_itemSlot.m_item)
                {
                    if(m_itemSlots[i].m_quantity < p_itemSlot.m_quantity)
                    {
                        p_itemSlot.m_quantity -= m_itemSlots[i].m_quantity;

                        m_itemSlots[i] = new ItemSlot();
                    }
                    else
                    {
                        m_itemSlots[i].m_quantity -= p_itemSlot.m_quantity;

                        if(m_itemSlots[i].m_quantity == 0)
                        {
                            m_itemSlots[i] = new ItemSlot();

                            //DELEGATE FOR THE UI
                            onItemsUpdated.Invoke();

                            return;
                        }
                    }
                }
            }
        }
    }

    public void Swap(int p_indexOne, int p_indexTwo)
    {
        ItemSlot firstSlot = m_itemSlots[p_indexOne];
        ItemSlot secondSlot = m_itemSlots[p_indexTwo];

        if(firstSlot == secondSlot) {return;}

        if(secondSlot.m_item != null)
        {
            if(firstSlot.m_item == secondSlot.m_item)
            {
                int secondSlotRemainingSpace = secondSlot.m_item.MaxStack - secondSlot.m_quantity;

                if(firstSlot.m_quantity <= secondSlotRemainingSpace)
                {
                    m_itemSlots[p_indexTwo].m_quantity += firstSlot.m_quantity;

                    m_itemSlots[p_indexOne] = new ItemSlot();

                    //DELEGATE FOR THE UI
                    onItemsUpdated.Invoke();

                    return;
                }
            }
        }

        m_itemSlots[p_indexOne] = secondSlot;
        m_itemSlots[p_indexTwo] = firstSlot;

        //DELEGATE FOR THE UI
        onItemsUpdated.Invoke();

    }

}
