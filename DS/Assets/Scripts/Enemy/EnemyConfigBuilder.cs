using UnityEngine;

public static class EnemyConfigBuilder
{
    public static EnemyConfig Build(EnemyData data, DifficultyLevel difficultyLevel, Transform[] target)
    {
        var config = ScriptableObject.CreateInstance<EnemyConfig>();

        float hpMultiplier = difficultyLevel?.hpMultiplier ?? 1f;
        float speedMultipleir = difficultyLevel?.speedMultiplier ?? 1f;
        float moneyBonus = difficultyLevel?.moneyBonus ?? 1f;   

        config.hp = data.baseHp * hpMultiplier;
        config.speed = data.baseSpeed * speedMultipleir;
        config.attackDamage = data.baseDamage;
        config.attackCooldown = data.baseAttackCooldown;
        config.lifeTime = data.baseLifeTime;

        config.reward = Random.Range(config.minMoney, config.maxMoney + 1) * ((int)moneyBonus);

        config.targets = target;

        return config;
    }
}