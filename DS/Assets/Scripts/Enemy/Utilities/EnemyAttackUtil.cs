using UnityEngine;
using UnityEngine.AI;

public static class EnemyAttackUtil
{
    public static bool ableToAttack(NavMeshAgent agent, EnemyAttack attack, Transform target)
    {
        return !agent.pathPending && agent.remainingDistance < 0.5f && attack != null && target != null && !attack.isAttacking;
    }

    public static void TryStartAttack(NavMeshAgent agent, EnemyAttack attack, Transform target, EnemyBehaviorConfig config)
    {
        if (agent == null || attack == null || target == null)
            return;

        agent.isStopped = true;

        IDamageable damageable = target?.GetComponentInParent<IDamageable>();
        if (damageable != null)
            attack.InitializeAttack(config, damageable);
    }
}
