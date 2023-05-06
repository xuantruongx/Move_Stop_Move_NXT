using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    private Transform m_transform;
    public Transform CameraTransform
    {
        get
        {
            if (m_transform == null)
                m_transform = GetComponent<Transform>();
            return m_transform;
        }
    }
    private void LateUpdate()
    {
        CameraTransform.position = target.position;
    }
}
