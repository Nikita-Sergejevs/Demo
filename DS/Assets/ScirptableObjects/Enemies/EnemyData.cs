using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Enemy/New Enemy Data")]
public class EnemyData : ScriptableObject
{
    public float baseHp;
    public float baseSpeed;
    public Type enemyType;

    public enum Type
    {
        Walking,
        Running,
        Standing
    }
}