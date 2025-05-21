using UnityEngine;

public class EnemyFactory : MonoBehaviour 
{
    [Header("Spawn Parameters")]
    [SerializeField] private Transform[] baseTargets;
    [SerializeField] private float xOffset;

    [Header("References")]
    [SerializeField] private EnemyPool enemyPool;

    public void SpawnEnemy(Transform spawnPoint, DifficultyLevel difficulty)
    {
        float offsetX = Random.Range(-xOffset, xOffset);

        EnemyEntry selectedEnemy = EnemyRarityUtil.GetEnemyByRarity(enemyPool);

        if (selectedEnemy == null || selectedEnemy.prefab == null)
            return;

        Vector3 spawnPointPosition = spawnPoint.position + spawnPoint.right * offsetX;

        GameObject enemy = Instantiate(selectedEnemy.prefab, spawnPointPosition, spawnPoint.rotation);

        Enemy enemyScript = enemy.GetComponent<Enemy>();
        if (enemyScript != null)
        {
            EnemyConfig config = EnemyConfigBuilder.Build(selectedEnemy.enemyData, difficulty, baseTargets);
            enemyScript.Initialize(baseTargets, config);

            Debug.Log(config.hp);

            var indicator = spawnPoint.GetComponent<SpawnIndicator>();
            if (indicator != null)
            {
                enemyScript.SetSpawnIndicator(indicator);
                indicator.RegisterEnemy();
            }
        }
    }
}