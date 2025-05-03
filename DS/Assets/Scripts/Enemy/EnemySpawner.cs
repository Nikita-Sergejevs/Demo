using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Spawn Parameters")]
    [SerializeField] private float timeBetweenSpawn;
    [SerializeField] private float xOffset;

    [Header("Prefabs")]
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private GameObject[] enemyPrefab;

    [Header("References")]
    [SerializeField] private WaveManager waveManager;

    private float timer;
    private float[] spawnWeight;

    private Transform spawnPoint;

    private void Start()
    {
        spawnWeight = new float[spawnPoints.Length];
        for (int i = 0; i < spawnPoints.Length; i++)
            spawnWeight[i] = 1f;
    }

    private void OnEnable()
    {
        WaveManager.OnWaveStart += OnWaveStart;
        WaveManager.OnWaveEnd += OnWaveEnd;
    }

    private void OnDisable()
    {
        WaveManager.OnWaveStart -= OnWaveStart;
        WaveManager.OnWaveEnd -= OnWaveEnd;
    }

    private void OnWaveStart()
    {
        InvokeRepeating(nameof(SpawnLogic), 0, timeBetweenSpawn);
    }

    private void OnWaveEnd()
    {
        CancelInvoke(nameof(SpawnLogic));
    }

    private void SpawnLogic()
    {
        ChooseSpawn();
        SpawnEnemy();
    }

    private void ChooseSpawn()
    {
        int chooseIndex = ChooseWeightedIndex();
        spawnPoint = spawnPoints[chooseIndex];

        spawnWeight[chooseIndex] += 1.5f;

        for(int i = 0; i < spawnWeight.Length; i++)
        {
            spawnWeight[i] = Mathf.Max(1f, spawnWeight[i] - 0.5f);
        }
    }

    private void SpawnEnemy()
    {
        int enemyIndex = Random.Range(0, enemyPrefab.Length);

        float offsetX = Random.Range(-xOffset, xOffset);
        Vector3 spawnPosition = spawnPoint.position + spawnPoint.right * offsetX;

        Instantiate(enemyPrefab[enemyIndex], spawnPosition, Quaternion.identity);
    }

    private int ChooseWeightedIndex()
    {
        float totalWeight = 0f;
        foreach (float w in spawnWeight)
            totalWeight += 1f / w;

        float randomValue = Random.value * totalWeight;
        float cumulative = 0f;

        for (int i = 0; i < spawnWeight.Length; i++)
        {
            cumulative += 1f / spawnWeight[i];
            if (randomValue <= cumulative)
                return i;
        }

        return spawnWeight.Length - 1;
    }
}