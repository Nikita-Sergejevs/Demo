using UnityEngine;

[System.Serializable]
public class DifficultyLevel
{
    [Header("Wave Diapasone")]
    public int fromWave;
    public int toWave;

    [Header("Enemy �hanges")]
    public float hpMultiplier;
    public float speedMultiplier;
    public int moneyBonus;

    [Header("Wave �hanges")]
    public float waveDuration;
    public int enemyCount;
}