/******************************************************
*       Made by Iohannes Mboumba                      *  
*                                                     *
/*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory Object", menuName = "Inventory System/Inventory")]
public class s_InventoryObject : ScriptableObject
{
    public List<InventorySlot> m_container = new List<InventorySlot>();

   public void AddItem(s_ItemObject p_item, int p_amount)
    {
        bool hasItem = false;
        for(int i = 0; i<m_container.Count; i++)
        {
            if(m_container[i].m_item == p_item)
            {
                m_container[i].AddAmount(p_amount);
                hasItem = true; 
                break;
            }
        }
        
        if(!hasItem)
        {
            m_container.Add(new InventorySlot(p_item, p_amount));
        }
    }
}

[System.Serializable]
public class InventorySlot
{
    public s_ItemObject m_item;
    public int m_amount;
    public InventorySlot(s_ItemObject p_item, int p_amount)
    {
        m_item = p_item;
        m_amount = p_amount;
    }
    public void AddAmount(int p_value)
    {
        m_amount += p_value;
    }
}
