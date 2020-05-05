using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSystem : MonoBehaviour
{
    
    //PlayerCamera, faudra changer le nom par celui de la vraie Camera//
    
    [SerializeField]
    private Camera m_playerCamera;

    private bool m_buildModeOn = false;
    private bool m_canBuild = false;

    private BlockSystem m_bSys;

    [SerializeField]
    private LayerMask buildableSurfacesLayer;

    private Vector3 m_buildPos;

    private GameObject m_currentTemplateBlock;

    [SerializeField]
    [Tooltip("Prefab du bloc de prévisualisation")]
    private GameObject m_blockTemplatePrefab;
    [SerializeField]
    private GameObject m_blockPrefab;

    [SerializeField]
    private Material m_templateMaterial;

    private int m_blockSelectCounter = 0;

    private void Start()
    {
        m_bSys = GetComponent<BlockSystem>();
    }
       
    //BuildMode ON/OFF en appuyant sur "e"//

    private void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            m_buildModeOn = !m_buildModeOn;

            if (m_buildModeOn)
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
            }
        }  

    // Attention le raycast ici gère les distance d'affichage en gros //
    // Pour que le joueur puisse construire de plus loin, changer le buildPosHit //
    // L'idée avec les screenpointtoray c'est que le raycast se lance depuis le milieu de l ecran    tout le temps, mais ça suggère que la camera suive le joueur quoi //

        if (m_buildModeOn)
        {
            RaycastHit buildPosHit;

            if (Physics.Raycast(m_playerCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0)), out buildPosHit, 30, buildableSurfacesLayer))
            {
                Vector3 point = buildPosHit.point;
                m_buildPos = new Vector3(Mathf.Round(point.x), Mathf.Round(point.y), Mathf.Round(point.z));
                m_canBuild = true;
            }
            else
            {
                Destroy(m_currentTemplateBlock.gameObject);
                m_canBuild = false;
            }
        }
           
        //Verifications dans tous les sens//
        
        //Pour ne plus avoir le template block si on éteint le build mode//

        if (!m_buildModeOn && m_currentTemplateBlock != null)
        {
            Destroy(m_currentTemplateBlock.gameObject);
            m_canBuild = false;
        }
        
        //Si jamais le template block n'apparait pas//

        if (m_canBuild && m_currentTemplateBlock == null)
        {
            m_currentTemplateBlock = Instantiate(m_blockTemplatePrefab, m_buildPos, Quaternion.identity);
            m_currentTemplateBlock.GetComponent<MeshRenderer>().material = m_templateMaterial;
        }
        
        //Pour ne pas faire spawner un nouveau template block à chaque fois//
        
        if (m_canBuild && m_currentTemplateBlock != null)
        {
            m_currentTemplateBlock.transform.position = m_buildPos;
        
            //Si joueur clic gauche//
        
            if (Input.GetMouseButtonDown(0))
            {
                PlaceBlock();
            }
        }
    }

    // Créer les block en fonction de ceux stockés dans la biblio //
    // Assigne nom, material, et ID //
    private void PlaceBlock()
    {
        GameObject newBlock = Instantiate(m_blockPrefab, m_buildPos, Quaternion.identity);
        Block tempBlock = m_bSys.allBlocks[m_blockSelectCounter];
        newBlock.name = tempBlock.blockName + "-Block";
        newBlock.GetComponent<MeshRenderer>().material = tempBlock.blockMaterial;
    }
}