using UnityEngine;

public static class EnemyConfigBuilder
{
    public static EnemyConfig Build(EnemyData data, DifficultyLevel difficultyLevel, Transform[] target)
    {
        var config = ScriptableObject.CreateInstance<EnemyConfig>();

        config.hp = data.baseHp * difficultyLevel.hpMultiplier;
        config.speed = data.baseSpeed * difficultyLevel.speedMultiplier;
        config.attackDamage = data.baseDamage;
        config.attackCooldown = data.baseAttackCooldown;
        config.lifeTime = data.baseLifeTime;

        config.reward = Random.Range(config.minMoney, config.maxMoney + 1) * difficultyLevel.moneyBonus;

        config.targets = target;

        return config;
    }
}