/******************************************************
*       Made by Johann Theron                         *  
*                                                     *
/*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Class to manage zoom and movement of the camera
/// </summary>
public class CameraClass : MonoBehaviour
{
    // Zoom variables
    [Header("Zoom properties")]
    [Tooltip("Minimum zoom")]
    [SerializeField] private float m_minFov = 20.0f;
    [Tooltip("Maximum zoom")]
    [SerializeField] private float m_maxFov = 90.0f;
    [Tooltip("Smoothness of the zoom")]
    [SerializeField] private float m_zoomSmoothness = 0.1f;

    // Player follow variables
    [Header("Follow player properties")]
    [Tooltip("Smoothness of the follow")]
    [SerializeField] private float m_followSmoothness = 0.5f;
    private bool m_lookAtPlayer = false;
    [Tooltip("Transform of the player")]
    public Transform m_playerTransform;
       
    [Tooltip("Set the camera as you want it to be positioned in relation to the player (changes visible only in Play Mode)")]
    [SerializeField] private Vector3 m_cameraOffset;

    void Update()
    {
        #region PinchZoom
        // Calculates the distance between the two touches on the screen
        if (Input.touchCount ==2)
        {
            Touch m_touch0 = Input.GetTouch(0);
            Touch m_touch1 = Input.GetTouch(1);

            Vector2 m_touch0PrevPos = m_touch0.position - m_touch0.deltaPosition;
            Vector2 m_touch1PrevPos = m_touch1.position - m_touch1.deltaPosition;

            float m_prevLength = (m_touch0PrevPos - m_touch1PrevPos).magnitude;
            float m_currentLength = (m_touch0.position - m_touch1.position).magnitude;
            float m_distance = m_currentLength - m_prevLength;

            Zoom(m_distance * m_zoomSmoothness);    
        }
        #endregion PinchZoom
    }

    /// <summary>
    /// Function used to pinch zoom
    /// </summary>
    void Zoom(float p_zoom)
    {
        Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView - p_zoom, m_minFov, m_maxFov);
    }

    void LateUpdate()
    {
        //Camera follows the player
        Vector3 m_newPos = m_playerTransform.position + m_cameraOffset;

        transform.position = Vector3.Slerp(transform.position, m_newPos, m_followSmoothness);

        //Let the camera look at the player
        if (m_lookAtPlayer)
        {
            transform.LookAt(m_playerTransform);
        }
    }  
}
