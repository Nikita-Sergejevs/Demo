using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    private SpawnIndicator spawnIndicator;
    private PlayerWallet wallet;
    private EnemyConfig config;

    public void Initialize(Transform[] baseTargets, EnemyConfig enemyConfig)
    {
        this.config = enemyConfig;

        IEnemyBehavior behavior = GetComponent<IEnemyBehavior>();
        if (behavior != null)
            behavior.InitializeBehavior(config);

        wallet = FindAnyObjectByType<PlayerWallet>();
    }

    public void TakeDamage(float damage)
    {
        var standing = GetComponent<StandingBehavior>();
        if (standing != null)
        {
            standing.ReactToHit();
            return;
        }

        config.hp -= damage;
        if (config.hp <= 0)
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

        wallet.AddMoney(config.reward);

        Destroy(gameObject);
    }
}