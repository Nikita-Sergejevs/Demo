using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    [Header("Enemy Settings")]
    [SerializeField] private EnemyData data;

    private float health;
    private float speed;
    private EnemyData.Type type;

    public void Initialize(Transform[] baseTargets)
    {
        if (data == null)
            return;

        health = data.baseHp;
        speed = data.baseSpeed;

        IEnemyBehavior behavior = GetComponent<IEnemyBehavior>();
        if (behavior != null)
            behavior.InitializeBehavior(speed, baseTargets);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
            Die();
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}