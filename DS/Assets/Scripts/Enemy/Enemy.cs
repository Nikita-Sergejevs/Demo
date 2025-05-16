using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    [Header("Enemy Settings")]
    [SerializeField] private EnemyData data;

    private float health;
    private int reward;

    private SpawnIndicator spawnIndicator;
    private PlayerWallet wallet;

    public void Initialize(Transform[] baseTargets)
    {
        if (data == null)
            return;

        var config = CreateBehaviorConfig(baseTargets);

        health = config.hp;
        reward = Random.Range(config.minMoney, config.maxMoney + 1);

        IEnemyBehavior behavior = GetComponent<IEnemyBehavior>();
        if (behavior != null)
            behavior.InitializeBehavior(config);

        wallet = FindAnyObjectByType<PlayerWallet>();
    }

    private EnemyConfig CreateBehaviorConfig(Transform[] baseTargets)
    {
        var config = ScriptableObject.CreateInstance<EnemyConfig>();
        config.hp = data.baseHp;
        config.speed = data.baseSpeed;
        config.attackDamage = data.baseDamage;
        config.attackCooldown = data.baseAttackCooldown;
        config.minMoney = data.baseMinMoney;
        config.maxMoney = data.baseMaxMoney;
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
        if (spawnIndicator != null)
            spawnIndicator.UnregisterEnemy();

        wallet.AddMoney(reward);

        Destroy(gameObject);
    }
}