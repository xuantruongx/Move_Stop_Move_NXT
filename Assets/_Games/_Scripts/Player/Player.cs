using System.Collections;
using UnityEngine;

public class Player : Character
{
    [SerializeField] private Transform Owner;
    [SerializeField] private Projectile projectilePrefab;
    [SerializeField] private Transform spawnProjectilePoint;

    public override void Update()
    {
        //  base.Update();
    }
    public override void Attack(Character target)
    {
        JustFired = true;
        Owner.LookAt(target.CharacterTransform.position);
        Instantiate(projectilePrefab, spawnProjectilePoint.position, spawnProjectilePoint.rotation);
        CoolDown();
    }
    public override void GetCharacterAround()
    {
        base.GetCharacterAround();
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
        JustFired = false;
    }

}
