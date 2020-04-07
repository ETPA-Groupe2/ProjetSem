using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public s_InventoryObject m_inventory;

    private void OnTriggerEnter(Collider other) 
    {
        var item = other.GetComponent<Item>();

        if(item)
        {
            m_inventory.AddItem(item.m_item, 1);
            Destroy(other.gameObject);
        }
    }
}
