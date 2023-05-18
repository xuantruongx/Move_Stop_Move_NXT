using UnityEngine;
using UnityEngine.AI;

public class Character : MonoBehaviour, IKillable
{
    private bool isDead;
    private Transform m_transform;
    public float attackRadius;
    public Character Target;
    public NavMeshAgent character;
    public bool JustFired;


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
        if (Target == null)
        {
            GetCharacterAround();
        }
        if ((character.velocity - Vector3.zero).sqrMagnitude <= 0.1f && Target != null && !Target.IsDead && !JustFired)
        {
            Attack(Target);
        }
        if (Target != null && (Target.IsDead || Vector3.Distance(CharacterTransform.position, Target.CharacterTransform.position) > attackRadius))
        {
            Target = null;
        }
    }

    public virtual void Attack(Character target)
    {

    }

    public void Kill()
    {
        isDead = true;
        gameObject.SetActive(false);
    }

    public virtual void GetCharacterAround()
    {
        Collider[] colliders = Physics.OverlapSphere(CharacterTransform.position, attackRadius);
        for (int i = 0; i < colliders.Length; i++)
        {
            Character temp = colliders[i].GetComponent<Character>();


            if (temp != this && Target == null)
            {
                Target = temp;
            }
        }

    }

}
