using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Enemy/New Enemy Data")]
public class EnemyData : ScriptableObject
{
    [Header("StandartParameters")]
    public float baseHp;
    public float baseSpeed;

    [Header("Attack Parameters")]
    public float baseDamage;
    public float baseAttackCooldown;
    [Space]
    public float baseLifeTime;

    [Range(0, 100)] public float rarity;

    public int baseMinMoney;
    public int baseMaxMoney;
}