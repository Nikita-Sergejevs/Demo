using System;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [Header("Wave Parameters")]
    [SerializeField] private float timeOfWave;

    [Header("Reference")]
    [SerializeField] private EnemySpawner enemySpawner;

    [SerializeField] private KeyCode startKey = KeyCode.Space;

    private float currentWave = 0;

    private bool isWaveReady;
    private bool isWaveActive;

    public static event Action OnWaveStart;
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

        Debug.Log($"Start Wave {currentWave}");

        OnWaveStart?.Invoke();

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