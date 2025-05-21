using UnityEngine;

public class EnemyConfig : ScriptableObject
{
    public float hp;
    public float speed;
    public float attackDamage;
    public float attackCooldown;
    public int minMoney;
    public int maxMoney;
    public int reward;
    public float lifeTime;
    public Transform[] targets;
}