using UnityEngine;

public class EnemyWindowFactory : MonoBehaviour
{
    [SerializeField] private EnemyPool enemyPool;

    private void OnEnable()
    {
        Windows.OnWindowEnemySpawn += SpawnWindowEnemy;
    }

    private void OnDisable()
    {
        Windows.OnWindowEnemySpawn -= SpawnWindowEnemy;
    }

    private void SpawnWindowEnemy(Transform window)
    {
        EnemyEntry selectedEnemy = EnemyRarityUtil.GetEnemyByRarity(enemyPool);

        if (selectedEnemy == null || selectedEnemy.prefab == null)
            return;
        
        GameObject enemy = Instantiate(selectedEnemy.prefab, window.position, window.rotation);

        Enemy enemyScript = enemy.GetComponent<Enemy>();
        if (enemyScript != null)
            enemyScript.Initialize(null);
    }
}