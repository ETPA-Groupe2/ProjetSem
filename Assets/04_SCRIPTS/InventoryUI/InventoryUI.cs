/******************************************************
*       Made by Iohannes Mboumba                      *  
*                                                     *
/*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Unity.UIElements.Runtime;

public class InventoryUI : PanelRenderer
{

    #region Variables

    [Header("--- INVENTORY UI SETTINGS ---")]

    [Tooltip("Needs the Inventory Scriptable Object.")]
    [SerializeField] private s_InventoryObject m_inventory; 

    [Tooltip("This is the list of Items in the Inventory")]
    [SerializeField] private List<InventorySlot> m_items;

    [Tooltip("Needs the VarBool Scriptable Object attached to the player.")]
    [SerializeField] private VarBool m_hasTaken;

    ///<summary>This is the inventory container UI window</summary>
    private VisualElement m_container;

    ///<summary>This is the list of slots in the UI window</summary>
    private List<VisualElement> m_child;
    
    #endregion

    private new void OnEnable() 
    {
        base.OnEnable();
        m_hasTaken.onValueChange += DisplayItems;
    }

    private new void OnDisable() 
    {
        base.OnDisable();
        m_hasTaken.onValueChange -= DisplayItems;
    }

    public new void Start() 
    {
        //Implementation of the start method for the UXML file and Stylesheet
        base.Start();

        //We take the list of items in the inventory
        m_items = m_inventory.m_container;

        //We take the container window of the UI Inventory window
        m_container = visualTree.Q("Slot-Container", "slotMenu");

        //We give to the list child all the slots that are in the container window
        m_child = new List<VisualElement>();
        foreach(VisualElement child in m_container.Children())
        {
            m_child.Add(child);
        }
    }

    ///<summary>Method to display the inventory items in their slots</summary>
    private void DisplayItems(bool p_hasTaken)
    {
        //We check if the player has taken an item
        if(p_hasTaken)
        {
            //We loop through the iventory items and give the corresponding item texture to the corresponding slot
            VisualElement ve;
            for(int i = 0; i < m_items.Count; i++)
            {
                ve = m_child[i];
                ve.style.backgroundImage = m_items[i].m_item.m_itemTexture;
                Debug.Log(m_items[i].m_item.m_itemTexture);
                //m_itemImage.image = m_items[i].m_item.m_itemTexture;
            }

        }
        
    }
}
