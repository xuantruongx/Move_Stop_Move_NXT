using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed;
    private Transform m_transform;
    public Transform projectileTransform
    {
        get
        {
            if (m_transform == null)
                m_transform = GetComponent<Transform>();
            return m_transform;
        }
    }
    private void Start()
    {
        rb.AddForce(speed * projectileTransform.forward);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IKillable>(out IKillable killable))
        {
            if (other.CompareTag("Enemy"))
            {
                killable.Kill();
                Destroy(gameObject);
            }
        }
    }
}
