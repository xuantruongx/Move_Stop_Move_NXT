using UnityEngine;
[System.Serializable]
public class PlayerItem
{
    public GameObject Item;
    public PlayerStat[] stat;
}

public enum PlayerStat
{
    AttackSpeed,
    AttackRange,
    MoveSpeed,
    Gold
}
