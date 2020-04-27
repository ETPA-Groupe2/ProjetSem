/******************************************************
*       Made by Iohannes Mboumba                      *  
*                                                     *
/*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Blocks : MonoBehaviour
{
    [Tooltip("Needs a reference to the event it's going to have")]
    public GD2Lib.Event m_event;

    [Tooltip("Needs a reference to it's type (the script Type should be on the object as well as this one)")]
    public Type m_type;

    [Tooltip("Needs a reference to the Zone enumType (it's the scriptable object type for the zone)")]
    public EnumType m_zoneType;

    [Tooltip("Utterly useless, thank you Anna.")]
    [SerializeField] private float m_pollutionLvl;
}
