using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleBlock : MonoBehaviour, IBlock2
{
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "BlueBlock")
        {
            onTouch();
        }
    }

    public void onTouch()
    {
        this.gameObject.GetComponent<Renderer>().material.color = Color.yellow;
    }
}
