using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleBlock : MonoBehaviour, IBlock2
{
    // When the block is triggered by another collider
    public void OnTriggerEnter(Collider other)
    {
        // If the collider has a Blue Block tag (checking the identity)
        if(other.tag == "Zone")
        {
            //It calls the function
            onTouch();
        }
    }

    //Function called when the block is touched
    public void onTouch()
    {
        //Changes the block color
        this.gameObject.GetComponent<Renderer>().material.color = Color.yellow;
    }
}
