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

        Vector3 posInit = transform.position;
        m_yPosition = posInit.y+2;
    }

    // Update is called once per frame
    void Update()
    {
        if(m_dragging)
        {
            Vector3 pos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, m_zPosition-m_offset.y);

            Vector3 curPos = Camera.main.ScreenToWorldPoint(pos);
            curPos.y = m_yPosition;

            transform.position = curPos;
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
        m_offset = transform.position - m_mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, m_zPosition));
    }

    public void EndDrag()
    {
        OnEndDrag.Invoke();

        m_dragging = false;
    }
}
