using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenToWorld : MonoBehaviour
{
    [SerializeField]
    Vector2 m_screenPos;

    [SerializeField]
    bool m_tracksMousePosition = false;

    void Update()
    {
        if (m_tracksMousePosition)
        {
            m_screenPos.x = Input.mousePosition.x;
            m_screenPos.y = Input.mousePosition.y;
        }

        Camera camera = Camera.main;
        Vector3 screenPos = new Vector3(m_screenPos.x, m_screenPos.y, camera.nearClipPlane);
        Vector4 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
        transform.position = worldPos;
    }
}
