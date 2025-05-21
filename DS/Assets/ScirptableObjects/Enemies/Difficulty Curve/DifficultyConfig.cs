using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Enemy/New Difficulty Config")]
public class DifficultyConfig : ScriptableObject
{
    public DifficultyLevel[] difficultyLevels;

    public DifficultyLevel GetDifficultyLevel(int wave)
    {
        foreach (var level in difficultyLevels)
        {
            if(wave >= level.fromWave && wave <= level.toWave)
                return level;
        }

        return difficultyLevels[^1];
    }
}