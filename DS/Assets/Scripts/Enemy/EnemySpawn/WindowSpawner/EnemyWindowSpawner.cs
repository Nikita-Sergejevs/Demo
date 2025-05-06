using UnityEngine;

public class EnemyWindowSpawner : MonoBehaviour
{
    [SerializeField] private EnemyPool enemyPool;

    private void OnEnable()
    {
        EnemyWindowUtil.onWindowEnemySpawnRequest += SpawnWindowEnemy;
    }

    private void OnDisable()
    {
        EnemyWindowUtil.onWindowEnemySpawnRequest -= SpawnWindowEnemy;
    }

    private void SpawnWindowEnemy(Transform window)
    {
        EnemyEntry selectedEnemy = EnemyRarityUnitl.GetEnemyByRarity(enemyPool);

        if (selectedEnemy == null || selectedEnemy.prefab == null)
            return;
        
        GameObject enemy = Instantiate(selectedEnemy.prefab, window.position, window.rotation);

        Enemy enemyScript = enemy.GetComponent<Enemy>();
        if (enemyScript != null)
            enemyScript.Initialize(null);
    }
}