using System.Collections;
using UnityEngine;

public class Enemy : Character
{
    [SerializeField] private Projectile projectilePrefab;
    [SerializeField] private Transform spawnProjectilePoint;

    public override void Update()
    {
        base.Update();
    }
    public override void GetCharacterAround()
    {
        base.GetCharacterAround();
    }
    public override void Attack(Character target)
    {
        CharacterTransform.LookAt(target.CharacterTransform.position);
        base.Attack(target);
        CoolDown();
    }
    public override void SpawnProjectile()
    {
        base.SpawnProjectile();
        Instantiate(projectilePrefab, spawnProjectilePoint.position, spawnProjectilePoint.rotation);
        JustFired = true;
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
        CharacterAnimator.SetBool("IsAttack", false);
        JustFired = false;
    }
}
