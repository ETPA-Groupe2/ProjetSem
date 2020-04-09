using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HotBarItem : ScriptableObject
{
    [Header("Basic Info")]
    [SerializeField] private string m_name = "New Hotbar Item Name";
    [SerializeField] private Sprite m_icon = null;

    public string Name => m_name;
    public abstract string ColouredName {get;}

    public Sprite Icon => m_icon;

    public abstract string GetInfoDisplayText();
}
