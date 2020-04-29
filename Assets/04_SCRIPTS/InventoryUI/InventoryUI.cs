/******************************************************
*       Made by Iohannes Mboumba                      *  
*                                                     *
/*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Unity.UIElements.Runtime;
using PointerType = UnityEngine.UIElements.PointerType;

public class InventoryUI : PanelRenderer
{

    #region Variables

    [Header("--- INVENTORY UI SETTINGS ---")]

    [Tooltip("Needs the Inventory Scriptable Object")]
    [SerializeField] private s_InventoryObject m_inventory; 

    [Tooltip("This is the list of Items in the Inventory")]
    [SerializeField] private List<InventorySlot> m_items;

    [Tooltip("Needs the VarBool Scriptable Object attached to the player")]
    [SerializeField] private s_VarBool m_hasTaken;

    ///<summary>This is the inventory container UI window</summary>
    private VisualElement m_container;

    private VisualElement m_invMenu;

    private VisualElement m_craftMenu;

    ///<summary>This is the list of slots in the UI window</summary>
    private List<VisualElement> m_child;

    private List<VisualElement> m_childOfChilds;

    [Header("--- CRAFT UI SETTINGS ---")]

    [Tooltip("List of craftable items")]
    public s_ItemObject[] m_itemsCraftable = new s_ItemObject[2];
    
    [Tooltip("List of craft recipes")]
    public List<s_CraftObject> m_recipes;

    ///<summary>The start position of the container</summary>
    private List<Vector2> m_startPosition;

    ///<summary>The start position of the pointer</summary>
    private List<Vector2> m_pointerStartPosition;

    private VisualElement m_gameField;
    
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

    private static readonly int s_maxFingers = PointerId.maxPointers - PointerId.touchPointerIdBase;
    public new void Start() 
    {
        //Implementation of the start method for the UXML file and Stylesheet
        base.Start();

        //We take the list of items in the inventory
        m_items = m_inventory.m_container;

        //We take the container window of the UI Inventory window
        m_container = visualTree.Q("Slot-Container", "slotMenu");
        m_invMenu = visualTree.Q("Inventory-Container", "menu");
        m_craftMenu = visualTree.Q("Craft-Container", "menu");
        m_gameField = visualTree.Q("Inventory-Menu", "gameField");

        //We give to the list child all the slots that are in the container window
        m_child = new List<VisualElement>();

        foreach(VisualElement child in m_container.Children())
        {
            m_child.Add(child);
        }

        m_startPosition = new List<Vector2>();
        m_pointerStartPosition = new List<Vector2>();

        for (var i = 0; i < s_maxFingers; i++)
        {
            m_startPosition.Add(Vector2.zero);
            m_pointerStartPosition.Add(Vector2.zero);
        }

        visualTree.Query("Slot", "Slot").ForEach(e => { e.RegisterCallback<PointerDownEvent>(OnPointerDown); });
        visualTree.Query("Slot", "Slot").ForEach(e => { e.RegisterCallback<PointerMoveEvent>(OnPointerMove); });
        visualTree.Query("Slot", "Slot").ForEach(e => { e.RegisterCallback<PointerUpEvent>(OnPointerUp); });
        visualTree.Query("Button", "buttonInv").ForEach(e => { e.RegisterCallback<PointerDownEvent>(OnClickDisplay);});
        visualTree.Query("QuitButton", "quitButton").ForEach(e => { e.RegisterCallback<PointerDownEvent>(OnClickRemove);});

    }

    ///<summary>Method to display the inventory items in their slots</summary>
    private void DisplayItems(bool p_hasTaken)
    {
        //We check if the player has taken an item
        if(p_hasTaken)
        {
            //We loop through the iventory items and give the corresponding item texture to the corresponding slot
            VisualElement ve;
            //VisualElement ve2;
            for(int i = 0; i < m_items.Count; i++)
            {
                ve = m_child[i];
                //ve2 = ve.Children();
                ve.style.backgroundImage = m_items[i].m_item.m_itemTexture;
                Debug.Log(m_items[i].m_item.m_itemTexture);
                //m_itemImage.image = m_items[i].m_item.m_itemTexture;
            }

        }
        
    }

    private void OnClickDisplay(PointerDownEvent evt)
    {
        if (evt.pointerType != PointerType.touch)
        {
            return;
        }

        if (evt.currentTarget == evt.target)
        {
            Debug.Log("That's the inventory button");
           if(m_invMenu.resolvedStyle.visibility == Visibility.Hidden && m_craftMenu.resolvedStyle.visibility == Visibility.Hidden)
           {
               m_invMenu.style.visibility = Visibility.Visible;
               m_craftMenu.style.visibility = Visibility.Visible;
           }
        }
    }

    private void OnClickRemove(PointerDownEvent evt)
    {
        if (evt.pointerType != PointerType.touch)
        {
            return;
        }

        if (evt.currentTarget == evt.target)
        {
            Debug.Log("That's the red button");
           if(m_invMenu.resolvedStyle.visibility == Visibility.Visible && m_craftMenu.resolvedStyle.visibility == Visibility.Visible)
           {
               m_invMenu.style.visibility = Visibility.Hidden;
               m_craftMenu.style.visibility = Visibility.Hidden;
           }
        }
    }


     private void OnPointerDown(PointerDownEvent evt)
    {
        if (evt.pointerType != PointerType.touch)
        {
            return;
        }

        if (evt.currentTarget == evt.target)
        {
            evt.target.CapturePointer(evt.pointerId);
            
            VisualElement ve = evt.target as VisualElement;

            var fingerIndex = evt.pointerId - PointerId.touchPointerIdBase;
            m_startPosition[fingerIndex] = new Vector2(ve.resolvedStyle.left, ve.resolvedStyle.top);
            m_pointerStartPosition[fingerIndex] = evt.position;
        }    
    }
    
    private void OnPointerMove(PointerMoveEvent evt)
    {
        if (evt.target.HasPointerCapture(evt.pointerId))
        {
            Debug.Assert(evt.currentTarget == evt.target);
            
            VisualElement ve = evt.target as VisualElement;
            
            Vector2 bounds = new Vector2(m_gameField.resolvedStyle.width, m_gameField.resolvedStyle.height);
            bounds -= new Vector2(ve.resolvedStyle.width, ve.resolvedStyle.height);
            
            var fingerIndex = evt.pointerId - PointerId.touchPointerIdBase;
            Vector2 p = m_startPosition[fingerIndex] + new Vector2(evt.position.x, evt.position.y) - m_pointerStartPosition[fingerIndex];
            p = Vector2.Max(p, Vector2.zero);
            p = Vector2.Min(p, bounds);
            ve.style.left = p.x;
            ve.style.top = p.y;
        }
    }
    
    private void OnPointerUp(PointerUpEvent evt)
    {
        if (evt.target.HasPointerCapture(evt.pointerId))
        {
            Debug.Assert(evt.currentTarget == evt.target);

            VisualElement ve = evt.target as VisualElement;
            ve.RemoveFromClassList("active");
            
            evt.target.ReleasePointer(evt.pointerId);
        }    
    }
}
