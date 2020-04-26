using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Unity.UIElements.Runtime;

public class InventoryUI : PanelRenderer
{
    [SerializeField] private s_InventoryObject m_inventory; 
    [SerializeField] private List<InventorySlot> m_items;
    private VisualElement m_Container;
    private Image m_itemImage;

    public new void Start() 
    {
        base.Start();
        m_items = m_inventory.m_container;
        m_Container = visualTree.Q("Slot-Container", "slotMenu");
    }

    private void DisplayItems()
    {
        VisualElement ve;
        for(int i = 1; i < m_Container.childCount+1; i++)
        {
            if(m_Container.ElementAt(i) != null && m_items[i].m_item != null)
            {
                ve = m_Container.ElementAt(i);
                ve.Add(m_itemImage);
                m_itemImage.image = m_items[i].m_item.m_itemTexture;
                Debug.Log(m_items[i].m_item.m_itemTexture);
            }
        }
    }

    public new void Update()
    {
        base.Update();
        DisplayItems();
    }
}
