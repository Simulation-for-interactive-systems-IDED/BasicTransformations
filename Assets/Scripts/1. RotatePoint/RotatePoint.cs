#define USE_ROTATION_MATRIX
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Simple demostration of rotating a point using matrices and quaternions
/// </summary>
public class RotatePoint : MonoBehaviour
{
    [SerializeField]
    [Range(0, 360)]
    float m_angle = 0;

    Vector3 m_initialPosition;

    // Start is called before the first frame update
    void Start()
    {
        m_initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
#if USE_ROTATION_MATRIX
        // Calculate a rotation matrix
        Matrix4x4 rotation = Matrix4x4.Rotate(Quaternion.Euler(0, 0, m_angle));
#else
        // Calculate a rotation quaternion
        Quaternion rotation = Quaternion.Euler(0, 0, m_angle);
#endif

        // Rotates the point
        Vector3 rotatedPoint = rotation * m_initialPosition;

        // Update transform for visualization purpouses
        transform.position = rotatedPoint;

        // Draw position vector
        transform.position.Draw(Color.red);
    }
}
