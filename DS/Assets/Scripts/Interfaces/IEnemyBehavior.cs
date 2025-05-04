using UnityEngine;

public interface IEnemyBehavior
{
    public void InitializeBehavior(float speed, Transform[] targetPoints);
}
