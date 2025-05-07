using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    [Header("Enemy Settings")]
    [SerializeField] private EnemyData data;

    private float health;

    private SpawnIndicator spawnIndicator;

    public void Initialize(Transform[] baseTargets)
    {
        if (data == null)
            return;

        var config = CreateBehaviorConfig(baseTargets);

        health = config.hp;

        IEnemyBehavior behavior = GetComponent<IEnemyBehavior>();
        if (behavior != null)
            behavior.InitializeBehavior(config);
    }

    private EnemyBehaviorConfig CreateBehaviorConfig(Transform[] baseTargets)
    {
        var config = ScriptableObject.CreateInstance<EnemyBehaviorConfig>();
        config.hp = data.baseHp;
        config.speed = data.baseSpeed;
        config.attackDamage = data.baseDamage;
        config.attackCooldown = data.baseAttackCooldown;
        config.lifeTime = data.baseLifeTime;
        config.targets = baseTargets;
        return config;
    }

    public void TakeDamage(float damage)
    {
        var standing = GetComponent<StandingBehavior>();
        if (standing != null)
        {
            standing.ReactToHit();
            return;
        }

        health -= damage;
        if (health <= 0)
            Die();
    }

    public void SetSpawnIndicator(SpawnIndicator indicator)
    {
        spawnIndicator = indicator;
    }

    public void Die()
    {
        if(spawnIndicator != null)
            spawnIndicator.UnregisterEnemy();

        Destroy(gameObject);
    }
}