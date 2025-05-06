using UnityEngine;

public static class EnemyRarityUnitl
{
    public static EnemyEntry GetEnemyByRarity(EnemyPool pool)
    {
        if (pool == null || pool.entries == null)
            return null;

        float totalWeight = 0;
        foreach (var entry in pool.entries)
            totalWeight += entry.enemyData.rarity;

        float roll = Random.Range(0, totalWeight);
        float cumulative = 0;

        foreach (var entry in pool.entries)
        {
            cumulative += entry.enemyData.rarity;
            if (roll <= cumulative)
            {
                if (entry.prefab == null)
                    return null;

                return entry;
            }
        }

        return pool.entries[pool.entries.Count - 1];
    }
}