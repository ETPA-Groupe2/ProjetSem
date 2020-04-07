using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ressource Object", menuName = "Inventory System/Items/Ressource")]
public class s_Ressource : ItemObject
{
   public void Awake() 
   {
       type = ItemType.Ressource;
   }
}
