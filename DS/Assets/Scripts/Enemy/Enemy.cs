using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    [Header("Enemy Settings")]
    [SerializeField] private EnemyData data;

    private float health;
    private float speed;
    private EnemyData.Type type;

    public void Initialize(Transform[] targetPoints)
    {
        if (data == null)
            return;

        health = data.baseHp;
        speed = data.baseSpeed;
        type = data.enemyType;

        switch (type)
        {
            case EnemyData.Type.Walking:
                WalkingBehavior walkingBehavior = GetComponent<WalkingBehavior>();
                if (walkingBehavior != null)
                {
                    walkingBehavior.movementSpeed = speed;
                    walkingBehavior.SetTarget(targetPoints);
                    walkingBehavior.Movement();
                }
                else return;

                break;
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
            Die();
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}