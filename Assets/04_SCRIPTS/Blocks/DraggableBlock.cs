using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DraggableBlock : MonoBehaviour
{
    #region Draggable Properties

    [SerializeField] private float m_zPosition;
    [SerializeField] private float m_yPosition;
    [SerializeField] private Vector3 m_offset;
    [SerializeField] private Camera m_mainCamera;
    [SerializeField] private bool m_dragging; 

    [SerializeField] private UnityEvent OnBeginDrag;
    [SerializeField] private UnityEvent OnEndDrag;

    #endregion


    // Start is called before the first frame update
    void Start()
    {
        m_mainCamera = Camera.main;
        m_zPosition = m_mainCamera.WorldToScreenPoint(transform.position).z;
        //m_yPosition = m_mainCamera.WorldToScreenPoint(transform.position).y;
    }

    // Update is called once per frame
    void Update()
    {
        if(m_dragging)
        {
            Vector3 meh = transform.position;
            Vector3 pos = new Vector3(Input.mousePosition.x, Input.mousePosition.y - m_offset.z , m_zPosition);
            meh.x = 4f;
            
        }  
    }

    private void OnMouseEnter() 
    {
        if(!m_dragging)
        {
            BeginDrag();
        }
    }

    private void OnMouseDown() 
    {
        EndDrag();
    }
    public void BeginDrag()
    {
        OnBeginDrag.Invoke();

        m_dragging = true;
        m_offset.z = m_mainCamera.WorldToScreenPoint(transform.position).y - Input.mousePosition.y; 
    }

    public void EndDrag()
    {
        OnEndDrag.Invoke();

        m_dragging = false;
    }
}
