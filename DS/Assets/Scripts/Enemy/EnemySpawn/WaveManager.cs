using System;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [Header("Wave Parameters")]
    [SerializeField] private float timeOfWave;

    [Header("References")]
    [SerializeField] private EnemySpawner enemySpawner;
    [SerializeField] private DifficultyConfig difficultyConfig;
 
    [SerializeField] private KeyCode startKey = KeyCode.Space;

    private float currentWave = 0;

    private bool isWaveReady = true;   
    private bool isWaveActive;

    public static event Action<DifficultyLevel> OnWaveStart;
    public static event Action OnWaveEnd;

    private bool canStartWave()
    {
        return isWaveReady && Input.GetKeyUp(startKey);
    }

    private void Update()
    {
        if (canStartWave())
            StartWave();
    }

    private void StartWave()
    { 
        UpdateWaveState(false);
        currentWave++;

        var difficulty = difficultyConfig.GetDifficultyLevel((int) currentWave);

        Debug.Log($"Start Wave {currentWave}");

        timeOfWave = difficulty.waveDuration;

        OnWaveStart?.Invoke(difficulty);

        Invoke(nameof(EndWave), timeOfWave);
    }

    private void EndWave()
    {
        UpdateWaveState(true);

        Debug.Log($"End Wave {currentWave}");

        OnWaveEnd?.Invoke();    
    }

    private void UpdateWaveState(bool isReady)
    {
        isWaveReady = isReady;
        isWaveActive = !isReady;
    }
}