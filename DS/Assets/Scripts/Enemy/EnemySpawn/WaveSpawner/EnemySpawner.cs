using System;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private float timeBetweenSpawn;

    [Header("Prefabs")]
    [SerializeField] private Transform[] spawnPoints;

    [Header("References")]
    [SerializeField] private WaveManager waveManager;
    [SerializeField] private EnemyFactory enemyFactory;

    private float timer;
    private float[] spawnWeight;

    private Transform spawnPoint;

    private DifficultyLevel currentDifficulty;

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

    private void OnWaveStart(DifficultyLevel difficulty)
    {
        currentDifficulty = difficulty;
        timeBetweenSpawn = currentDifficulty.enemyCount;
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
            spawnWeight[i] = Mathf.Min(spawnWeight[chooseIndex] + 1.5f, 5f);
        }
    }

    private int ChooseWeightedIndex()
    {
        float totalWeight = 0f;
        foreach (float w in spawnWeight)
            totalWeight += w;

        float randomValue = UnityEngine.Random.value * totalWeight;
        float cumulative = 0f;

        for (int i = 0; i < spawnWeight.Length; i++)
        {
            cumulative += spawnWeight[i];
            if (randomValue <= cumulative)
                return i;
        }

        return spawnWeight.Length - 1;
    }

    private void SpawnEnemy()
    {
        enemyFactory.SpawnEnemy(spawnPoint, currentDifficulty);
    }
}