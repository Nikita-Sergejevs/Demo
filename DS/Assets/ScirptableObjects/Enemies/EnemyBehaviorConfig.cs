using UnityEngine;

[CreateAssetMenu(fileName = "Enemy")]
public class EnemyBehaviorConfig : ScriptableObject
{
    public float speed;
    public float lifeTime;
    public Transform[] targets;
}