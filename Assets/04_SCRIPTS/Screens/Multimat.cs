using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Multimat : MonoBehaviour
{
    [SerializeField]
    public int CurrentMaterial;

    [SerializeField]
    public Material[] Materials;
    // Use this for initialization

    [Tooltip("Put the Zone detector here")]
    //[SerializeField] CheckCollision m_bool;

    bool m_matHasChanged = false;
    bool m_valueChanged = false;

    void Start()
    {
        Renderer rend = GetComponent<Renderer>();
    }

    void Update()
    {
       /* if (m_bool.m_isTriggered == true)
        {
            Debug.Log("IN MULTIMAT");
            if (CurrentMaterial == Materials.Length && m_matHasChanged == false)
            {
                CurrentMaterial = 0;
            }
            else if (m_valueChanged == false)
            {
                m_matHasChanged = true;
                m_valueChanged = true;
                CurrentMaterial++;
            }

            Material[] currentlyAssignedMaterials = GetComponent<Renderer>().materials;

            currentlyAssignedMaterials[1] = Materials[CurrentMaterial];
            GetComponent<Renderer>().materials = currentlyAssignedMaterials;
        }*/
    }
}
