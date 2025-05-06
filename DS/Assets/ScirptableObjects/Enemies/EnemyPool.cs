using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyPool", menuName = "Enemy/New Enemy Pool")]
public class EnemyPool : ScriptableObject
{
   public List<EnemyEntry> entries;
}

[System.Serializable]
public class EnemyEntry
{
    public EnemyData enemyData;
    public GameObject prefab;
}