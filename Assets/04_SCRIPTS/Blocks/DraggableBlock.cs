using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems; 

public class DraggableBlock : MonoBehaviour
{
    #region Draggable Properties

    [SerializeField] private float m_zPosition;
    [SerializeField] private float m_yPosition;
    [SerializeField] private Camera m_mainCamera;
    [SerializeField] private bool m_dragging; 
    [SerializeField] private UnityEvent OnBeginDrag;
    [SerializeField] private UnityEvent OnEndDrag;
    [SerializeField] private s_VarBool m_dragOver;

    #endregion


    // Start is called before the first frame update
    void Start()
    {
        m_mainCamera = Camera.main;
        m_zPosition = m_mainCamera.WorldToScreenPoint(transform.position).z;

        Vector3 posInit = transform.position;
        m_yPosition = posInit.y;
    }

    // Update is called once per frame
    void Update()
    {
        if(m_dragging)
        {
            Vector3 pos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, m_zPosition);

            Vector3 curPos = Camera.main.ScreenToWorldPoint(pos);
            curPos.y = m_yPosition;

            transform.position = curPos;

            #if UNITY_ANDROID

            Vector3 pos = new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, m_zPosition);

            Vector3 curPos = Camera.main.ScreenToWorldPoint(pos);
            curPos.y = m_yPosition;

            transform.position = curPos;

            #endif
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
    }

    #if UNITY_ANDROID

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Down");

        if(!m_dragging)
        {
            m_dragOver.m_value = false;
            BeginDrag();
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("Up");

        OnEndDrag.Invoke();
        m_dragOver.m_value = true;
        m_dragging = false;
    }

    #endif

    public void EndDrag()
    {
        OnEndDrag.Invoke();
        m_dragging = false;
    }
}
