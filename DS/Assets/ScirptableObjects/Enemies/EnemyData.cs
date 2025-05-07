using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Enemy/New Enemy Data")]
public class EnemyData : ScriptableObject
{
    public float baseHp;
    public float baseSpeed;
    public float baseDamage;
    public float baseAttackCooldown; 
    public float baseLifeTime;

    [Range(0, 100)] public float rarity;

    public Type enemyType;

    public enum Type
    {
        Walking,
        Running,
        Standing
    }
}