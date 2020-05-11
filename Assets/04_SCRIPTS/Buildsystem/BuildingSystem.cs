using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BuildingSystem : MonoBehaviour
{
    
    //PlayerCamera, faudra changer le nom par celui de la vraie Camera//
    [Header("--- UI PARAMETERS ---")]
    [SerializeField] private s_VarBool m_canBuild;

    [Space]

    [Header("--- BOMB UI PARAMETERS ---")] 
    [SerializeField] private s_VarBool m_canBuildBomb;
    [SerializeField] private s_IntVar m_bombeResourceInt;
    
    [Header("--- GLIDE UI PARAMETERS ---")] 
    [SerializeField] private s_VarBool m_canBuildGlide;
    [SerializeField] private s_IntVar m_glideResourceInt;

    [Header("--- GENERATOR UI PARAMETERS ---")] 
    [SerializeField] private s_VarBool m_canBuildGen;
    [SerializeField] private s_IntVar m_generatorResourceInt;

    [Space]

    [Header("--- BUILDER PARAMETERS ---")]

    [SerializeField]
    private Camera m_playerCamera;

    private bool m_buildModeOn = false;

    [SerializeField]
    private LayerMask buildableSurfacesLayer;

    private GameObject m_currentTemplateBlock;

    [SerializeField]
    [Tooltip("Prefab du bloc de prévisualisation")]
    private GameObject m_blockTemplatePrefab;
    [SerializeField]
    private GameObject[] m_blockPrefab;

    [SerializeField]
    private Material m_templateMaterial;

    [SerializeField] private Transform m_playerTrans;

    [SerializeField] private Vector3 m_blockTrans;

    [SerializeField] private float m_posBlockOffset;

    private bool m_bomb = false;
    private bool m_glide = false;
    private bool m_gen = false;


       
    //BuildMode ON/OFF en appuyant sur "e"//

    private void Update()
    {

    // Attention le raycast ici gère les distance d'affichage en gros //
    // Pour que le joueur puisse construire de plus loin, changer le buildPosHit //
    // L'idée avec les screenpointtoray c'est que le raycast se lance depuis le milieu de l ecran    tout le temps, mais ça suggère que la camera suive le joueur quoi //

        if (m_buildModeOn)
        {
            m_canBuild.Value = true;
            if(Input.GetMouseButton(0))
            {
                RaycastHit buildPosHit;

                if (Physics.Raycast(m_playerCamera.ScreenPointToRay(Input.mousePosition), out buildPosHit, 1000, buildableSurfacesLayer))
                {
                    if (m_canBuild.Value && m_bomb)
                    { 
                        PlaceBomb(buildPosHit.point);
                        m_bomb = false;
                        m_buildModeOn = false;
                    }
                    else if(m_canBuild.Value && m_glide)
                    {
                        PlaceGlide(buildPosHit.point);
                        m_glide = false;
                        m_buildModeOn = false;
                    }
                    else if(m_canBuild.Value && m_gen)
                    {
                        PlaceGen(buildPosHit.point);
                        m_gen = false;
                        m_buildModeOn = false;
                    }
                } 
            }
        
        }
        else
        {
            m_canBuild.Value = false;
        }
           

        if (!m_buildModeOn && m_currentTemplateBlock != null)
        {
            Destroy(m_currentTemplateBlock.gameObject);
            m_canBuild.Value = false;
        }
           
    }

    #region HANDLING SYSTEM FOR BLOCKS

    ///<summary>This is to activate the build mode</summary>
    public void HandleBuildBomb()
    {
        if(m_canBuildBomb.Value)
        {
            m_buildModeOn = true;
            m_bomb = true;
            m_blockTrans = new Vector3(m_playerTrans.position.x, m_playerTrans.position.y, m_playerTrans.position.z-m_posBlockOffset);

            //Vector3 m_pointerPoint = Input.mousePosition;
            m_currentTemplateBlock = Instantiate(m_blockTemplatePrefab, m_blockTrans, Quaternion.identity);
            m_currentTemplateBlock.GetComponent<MeshRenderer>().material = m_templateMaterial;
        }
        
    }

    public void HandleBuildGlide()
    {
        if(m_canBuildGlide.Value)
        {
            m_buildModeOn = true;
            m_glide = true;
            m_blockTrans = new Vector3(m_playerTrans.position.x, m_playerTrans.position.y, m_playerTrans.position.z-m_posBlockOffset);

            //Vector3 m_pointerPoint = Input.mousePosition;
            m_currentTemplateBlock = Instantiate(m_blockTemplatePrefab, m_blockTrans, Quaternion.identity);
            m_currentTemplateBlock.GetComponent<MeshRenderer>().material = m_templateMaterial;
        }
    }

    public void HandleBuildGen()
    {
        if(m_canBuildGen.Value)
        {
            m_buildModeOn = true;
            m_gen = true;
            m_blockTrans = new Vector3(m_playerTrans.position.x, m_playerTrans.position.y, m_playerTrans.position.z-m_posBlockOffset);

            //Vector3 m_pointerPoint = Input.mousePosition;
            m_currentTemplateBlock = Instantiate(m_blockTemplatePrefab, m_blockTrans, Quaternion.identity);
            m_currentTemplateBlock.GetComponent<MeshRenderer>().material = m_templateMaterial;
        }  
    }

    #endregion

    #region INSTANTIATE BLOCKS

    // Créer les block en fonction de ceux stockés dans la biblio //
    // Assigne nom, material, et ID //
    private void PlaceBomb(Vector3 p_pos)
    {
        p_pos.y = 2.2f;
        Debug.Log("Come on");
        Destroy(m_currentTemplateBlock.gameObject);
        if(m_bombeResourceInt.Value>2)
        {
            m_bombeResourceInt.Value -=2;
        }
        else
        {
            m_bombeResourceInt.Value = 0;
        }

      
        GameObject newBlock = Instantiate(m_blockPrefab[0], p_pos, Quaternion.identity);   
    }
    
    private void PlaceGlide(Vector3 p_pos)
    {
        p_pos.y = 2;
        Debug.Log("Come out");
        Destroy(m_currentTemplateBlock.gameObject);
        m_glideResourceInt.Value = 0;
        GameObject newBlock = Instantiate(m_blockPrefab[1], p_pos, Quaternion.identity);   
    }

    private void PlaceGen(Vector3 p_pos)
    {
        p_pos.y = 2;
        Debug.Log("Come in");
        Destroy(m_currentTemplateBlock.gameObject);
        m_generatorResourceInt.Value = 0;
        GameObject newBlock = Instantiate(m_blockPrefab[2], p_pos, Quaternion.identity);   
    }

    #endregion
}