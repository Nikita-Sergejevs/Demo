using UnityEngine;

public class EnemyFactory : MonoBehaviour 
{
    [Header("Spawn Parameters")]
    [SerializeField] private Transform[] baseTargets;
    [SerializeField] private float xOffset;

    [Header("References")]
    [SerializeField] private GameObject[] enemyPrefab;

    public EnemyFactory(GameObject[] enemyPrefab, float xOffset)
    {
        this.enemyPrefab = enemyPrefab;
        this.xOffset = xOffset; 
    }

    public void SpawnEnemy(Transform spawnPoint)
    {
        int enemyIndex = Random.Range(0, enemyPrefab.Length);
        float offsetX = Random.Range(-xOffset, xOffset);

        Vector3 spawnPointPosition = spawnPoint.position + spawnPoint.right * offsetX;

        GameObject enemy = GameObject.Instantiate(enemyPrefab[enemyIndex], spawnPointPosition, spawnPoint.rotation);

        Enemy enemyScript = enemy.GetComponent<Enemy>();
        if (enemyScript != null)
            enemyScript.Initialize(baseTargets);
    }
}
