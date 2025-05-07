using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private float damage;
    private float attackInterval;

    public bool isAttacking { get; private set; }

    private IDamageable target;

    public void InitializeAttack(EnemyBehaviorConfig config, IDamageable damageableTarget)
    {
        CancelInvoke(nameof(Attack));

        damage = config.attackDamage;
        attackInterval = config.attackCooldown;
        target = damageableTarget;

        if (target != null)
        {
            isAttacking = true;
            InvokeRepeating(nameof(Attack), 0, attackInterval);
        }
        else
            CancelInvoke(nameof(Attack));
    }

    private void Attack()
    {
        if (target == null)
        {
            CancelInvoke(nameof(Attack));
            return;
        }

        target.TakeDamage(damage);
    }
}