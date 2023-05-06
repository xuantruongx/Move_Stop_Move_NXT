using UnityEngine;

public class Character : MonoBehaviour, IKillable
{
    private bool isDead;
    private Transform m_transform;
    public Transform CharacterTransform
    {
        get
        {
            if (m_transform == null)
                m_transform = GetComponent<Transform>();
            return m_transform;
        }
    }

    public bool IsDead { get { return isDead; } }

    public virtual void Start()
    {

    }
    public virtual void Update()
    {

    }

    public virtual void Attack(Character target)
    {

    }

    public void Kill()
    {
        isDead = true;
        gameObject.SetActive(false);
    }

}
