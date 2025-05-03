using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    [Header("Enemy Parameters")]
    [SerializeField] private float healt;
    [SerializeField] private float speed; 

    public void TakeDamage(float damage)
    {
        healt -= damage;

        if (healt <= 0)
            Destroy(gameObject);
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}