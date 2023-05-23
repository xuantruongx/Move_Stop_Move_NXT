using UnityEngine;

public class CharacterAnimationEvent : MonoBehaviour
{
    public Character CharacterBase;

    public void SpawnProjectile()
    {
        CharacterBase.SpawnProjectile();
    }

    public void Dead()
    {
        CharacterBase.Dead();
    }
}
