using UnityEngine;

[System.Serializable]
public class DifficultyLevel
{
    [Header("Wave Diapasone")]
    public int fromWave;
    public int toWave;

    [Header("Enemy Ñhanges")]
    public float hpMultiplier;
    public float speedMultiplier;
    public int moneyBonus;

    [Header("Wave Ñhanges")]
    public float waveDuration;
    public int enemyCount;
}