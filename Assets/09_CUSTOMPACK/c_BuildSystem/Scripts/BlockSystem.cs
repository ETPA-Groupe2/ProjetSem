using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSystem : MonoBehaviour {

    [SerializeField]
    private BlockType[] allBlockTypes;
    
    //Utilisation d'une biblio pour ranger les blocks//
    //ça leurs assigne un ID pour les différencier//
    //ATTENTION :: il faut le using System pour utiliser les biblio//
    
    [HideInInspector]
    public Dictionary<int, Block> allBlocks = new Dictionary<int, Block>();

    private void Awake()
    {
        for (int i = 0; i < allBlockTypes.Length; i++)
        {
            //Mets les blocks dans la biblio//
            
            BlockType newBlockType = allBlockTypes[i];
            
            //créer un nouveau block//
            
            Block newBlock = new Block(i, newBlockType.blockName, newBlockType.blockMat);
            allBlocks[i] = newBlock;      
        }
    }
}

public class Block
{
    public int blockID;
    public string blockName;
    public Material blockMaterial;

    public Block (int id, string name, Material mat)
    {
        blockID = id;
        blockName = name;
        blockMaterial = mat;
    }
}

[Serializable]
public struct BlockType
{
    public string blockName;
    public Material blockMat;
}