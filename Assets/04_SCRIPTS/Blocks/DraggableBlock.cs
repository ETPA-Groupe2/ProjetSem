using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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

    [SerializeField] private Plane objPlane;
    [SerializeField] private Vector3 m0;
    [SerializeField] public GameObject gObj;


    #endregion


    // Start is called before the first frame update
    void Start()
    {
        m_mainCamera = Camera.main;
        m_zPosition = m_mainCamera.WorldToScreenPoint(transform.position).z;

        Vector3 posInit = transform.position;
        m_yPosition = posInit.y;
    }

    #if UNITY_ANDROID
    private Ray GenerateRay(Vector3 touchPos)
    {
        Vector3 mousePosFar = new Vector3(touchPos.x, touchPos.y, Camera.main.farClipPlane);
        Vector3 mousePosNear = new Vector3(touchPos.x, touchPos.y, Camera.main.nearClipPlane);

        Vector3 mousePosF = Camera.main.ScreenToWorldPoint(mousePosFar);
        Vector3 mousePosN = Camera.main.ScreenToWorldPoint(mousePosNear);

        Ray mr = new Ray(mousePosN, mousePosF-mousePosN);
        return mr;
    }
    #endif

    // Update is called once per frame
    void Update()
    {
        #if UNITY_EDITOR
        if(m_dragging)
        {
            Vector3 pos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, m_zPosition);

            Vector3 curPos = Camera.main.ScreenToWorldPoint(pos);
            curPos.y = m_yPosition;

            transform.position = curPos;
        }
        #endif

        #if UNITY_ANDROID
        
        Debug.Log(gObj);
        if(Input.touchCount > 0)
        {
            if(Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Debug.LogWarning("LIFE IS DEATH");
                Ray mouseRay = GenerateRay(Input.GetTouch(0).position);
                RaycastHit hit;

                if(Physics.Raycast(mouseRay.origin, mouseRay.direction, out hit))
                {
                    if(hit.transform.gameObject == gObj)
                    {
                        //gObj = hit.transform.gameObject;
                        objPlane = new Plane(Camera.main.transform.forward*-1, gObj.transform.position);

                        Ray mRay = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                        float rayDistance;
                        objPlane.Raycast(mRay, out rayDistance);
                        m0 = gObj.transform.position - mRay.GetPoint(rayDistance);
                    }
                    
                }
            }

            else if(Input.GetTouch(0).phase == TouchPhase.Moved && gObj)
            {
                Ray mRay = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                float rayDistance;
                if(objPlane.Raycast(mRay, out rayDistance))
                {
                    Vector3 pos = new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, m_zPosition);

                    Vector3 curPos = Camera.main.ScreenToWorldPoint(pos);
                    curPos.y = m_yPosition;

                    gObj.transform.position = curPos;
                }
                   
            }
            else if(Input.GetTouch(0).phase == TouchPhase.Ended && gObj)
            {
                m_dragOver.m_value = true;
                //gObj = null;
            }
        }
        #endif
    }

    #if UNITY_EDITOR
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
    
    public void EndDrag()
    {
        OnEndDrag.Invoke();
        m_dragging = false;
    }
    #endif
}
