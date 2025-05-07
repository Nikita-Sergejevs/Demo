using UnityEngine;

public class EnemyBehaviorConfig : ScriptableObject
{
    public float hp;
    public float speed;
    public float attackDamage;
    public float attackCooldown;
    public float lifeTime;
    public Transform[] targets;
}