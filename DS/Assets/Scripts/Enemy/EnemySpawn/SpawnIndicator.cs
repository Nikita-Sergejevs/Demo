using UnityEngine;

public class SpawnIndicator : MonoBehaviour 
{
    [SerializeField] private GameObject indicator;

    private int enemyCount;

    public void RegisterEnemy()
    {
        enemyCount++;
        indicator.SetActive(true);
    }

    public void UnregisterEnemy()
    {
        enemyCount--;
        CheckEnemyCount();
    }

    private void CheckEnemyCount()
    {
        if (enemyCount <= 0)
        {
            enemyCount = 0;
            indicator.SetActive(false);
        }
    }
}