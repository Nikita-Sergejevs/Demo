using UnityEngine;
using UnityEngine.AI;

public class WalkingBehavior : MonoBehaviour, IEnemyBehavior
{
    [SerializeField] private float targetRadiusOffset;

    private Transform currentTarget;

    private EnemyAttack attack;
    private EnemyBehaviorConfig enemyConfig;

    private NavMeshAgent agent;

    private bool ableToAttack()
    {
        return !agent.pathPending && agent.remainingDistance < 0.5f && attack != null && currentTarget != null && !attack.isAttacking;
    }

    public void InitializeBehavior(EnemyBehaviorConfig config)
    {
        agent = GetComponent<NavMeshAgent>();
        attack = GetComponent<EnemyAttack>();
        this.enemyConfig = config;

        if (agent == null && attack == null)
            return;

        agent.speed = enemyConfig.speed;

        currentTarget = TargetUtils.FindClosetTarget(enemyConfig.targets, transform.position);
        if (currentTarget != null)
        {
            Vector3 offset = Random.insideUnitSphere * targetRadiusOffset;
            offset.y = 0;

            agent.SetDestination(currentTarget.position + offset);
        }
    }

    private void Update()
    {
        if (EnemyAttackUtil.ableToAttack(agent, attack, currentTarget))
            EnemyAttackUtil.TryStartAttack(agent, attack, currentTarget, enemyConfig);
    }
}