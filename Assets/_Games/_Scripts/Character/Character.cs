using UnityEngine;
using UnityEngine.AI;

public class Character : MonoBehaviour, IKillable
{
    private bool isDead;
    private Transform m_transform;
    public float AttackRadius;
    public Character Target;
    public NavMeshAgent CharacterAgent;
    public bool JustFired;
    public Animator CharacterAnimator;



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
        if ((CharacterAgent.velocity - Vector3.zero).sqrMagnitude <= 0.1f && Target != null && !Target.IsDead && !JustFired)
        {
            Attack(Target);
        }
        if (Target != null && (Target.IsDead || Vector3.Distance(CharacterTransform.position, Target.CharacterTransform.position) > AttackRadius))
        {
            Target = null;
            CharacterAnimator.SetBool("IsAttack", false);
        }

        if (CharacterAnimator != null)
        {
            CharacterAnimator.SetBool("IsIdle", CharacterAgent.velocity.magnitude < 0.02f);
        }

    }

    public virtual void Attack(Character target)
    {
        CharacterAnimator.SetBool("IsAttack", true);
    }
    public virtual void SpawnProjectile()
    {


    }

    public void Kill()
    {
        CharacterAgent.isStopped = true;
        isDead = true;
        CharacterAnimator.SetBool("IsDead", true);
    }

    public void Dead()
    {
        gameObject.SetActive(false);
    }

    public virtual void GetCharacterAround()
    {
        Collider[] colliders = Physics.OverlapSphere(CharacterTransform.position, AttackRadius);
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
