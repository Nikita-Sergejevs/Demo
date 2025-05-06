using System;
using UnityEngine;

public static class EnemyWindowUtil
{
    public static bool isActive;

    public static event Action<Transform> onWindowEnemySpawnRequest;

    public static void RequestSpawn(Transform windowSpawnPoint)
    {
        if(isActive)
            return;

        onWindowEnemySpawnRequest?.Invoke(windowSpawnPoint);
        isActive = true;
    }
    
    public static void ResetSpawn()
    {
        isActive = false;
    }
}