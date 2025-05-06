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

        var config = CreateBehaviorConfig(baseTargets);

        IEnemyBehavior behavior = GetComponent<IEnemyBehavior>();
        if (behavior != null)
            behavior.InitializeBehavior(config);

        IDamageTaken damageTaken = GetComponent<IDamageTaken>();
        if (damageTaken != null)
            damageTaken.OnTakeDamage(health, health);
    }

    private EnemyBehaviorConfig CreateBehaviorConfig(Transform[] baseTargets)
    {
        var config = ScriptableObject.CreateInstance<EnemyBehaviorConfig>();
        config.speed = data.baseSpeed;
        config.targets = baseTargets;
        config.lifeTime = data.baseLifeTime;
        return config;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
            Die();

        IDamageTaken damageTaken = GetComponent<IDamageTaken>();
        if (damageTaken != null && health < data.baseHp)
            damageTaken.OnTakeDamage(health, data.baseHp);
    }


    public void Die()
    {
        Destroy(gameObject);
    }
}