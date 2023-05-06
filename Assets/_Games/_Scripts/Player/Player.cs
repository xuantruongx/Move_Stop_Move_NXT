using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Player : Character
{
    [SerializeField] private Transform Owner;
    [SerializeField] private Projectile projectilePrefab;
    [SerializeField] private Character target;
    [SerializeField] private Transform spawnProjectilePoint;
    [SerializeField] private NavMeshAgent character;
    [SerializeField] private bool justFired;
    [SerializeField] private float rotationSpeed;

    public override void Update()
    {
        if ((character.velocity - Vector3.zero).sqrMagnitude <= 0.1f && target != null && !target.IsDead && !justFired)
        {
            Debug.Log("Ready");
            Attack(target);
        }
        if (target != null && target.IsDead)
        {
            target = null;
        }
    }
    public override void Attack(Character target)
    {
        justFired = true;
        Owner.LookAt(target.CharacterTransform.position);
        Instantiate(projectilePrefab, spawnProjectilePoint.position, spawnProjectilePoint.rotation);
        CoolDown();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (target == null)
                target = other.GetComponent<Character>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            target = null;
        }
    }
    WaitForSeconds second = new WaitForSeconds(1f);
    Coroutine coroutine;
    private void CoolDown()
    {
        if (coroutine != null)
            StopCoroutine(coroutine);
        coroutine = StartCoroutine(WaitNewShoot());
    }
    IEnumerator WaitNewShoot()
    {
        yield return second;
        justFired = false;
    }

}
