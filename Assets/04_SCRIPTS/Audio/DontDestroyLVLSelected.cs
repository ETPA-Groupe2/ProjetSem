using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyLVLSelected : MonoBehaviour
{
    public static DontDestroyLVLSelected m_instanceLVLSelected;

    void Awake()
    {
        if (m_instanceLVLSelected)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            m_instanceLVLSelected = this;
        }
    }
}
