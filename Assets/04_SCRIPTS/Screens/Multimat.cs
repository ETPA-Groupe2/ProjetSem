using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Multimat : MonoBehaviour
{
    
    [SerializeField]
    public int CurrentMaterial;

    [SerializeField]
    public Material[] Materials;
    
    public GameObject m_ScreensTrigger;



    // Use this for initialization
    void Start()
    {
        Renderer rend = GetComponent<Renderer>();
      

    }

    void Update()
    {
        if (m_ScreensTrigger.activeInHierarchy == true)
        {
            RedScreens();
        }
    }



    void RedScreens()
    {
        

        if (CurrentMaterial == Materials.Length)
        {
            CurrentMaterial = 0;
        }
        else
        {
            CurrentMaterial++;
        }

        Material[] currentlyAssignedMaterials = GetComponent<Renderer>().materials;

        currentlyAssignedMaterials[1] = Materials[CurrentMaterial];
        GetComponent<Renderer>().materials = currentlyAssignedMaterials;
    }
}