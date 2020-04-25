using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Blocks : MonoBehaviour
{
    public GD2Lib.Event m_event;
    public Type m_type;
    public EnumType m_zoneType;

    public float m_pollutionLvl;
}
