using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyMenu : MonoBehaviour
{
    
    void Start()
    {
        DontDestroyOnLoad(gameObject);  
    }

    void Update()
    {
        if(GameObject.Find("MusicMenu") != null && GameObject.Find("AmbientMenu") !=null)
        {
            Destroy();
        }
    }

    public void Destroy()
    {
        Destroy(gameObject); 
    }
}
