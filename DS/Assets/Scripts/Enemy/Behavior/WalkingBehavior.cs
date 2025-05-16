using UnityEngine;
using UnityEngine.AI;

public class WalkingBehavior : MonoBehaviour, IEnemyBehavior
{
    [SerializeField] private float targetRadiusOffset;

    private Transform currentTarget;

    private EnemyAttack attack;
    private EnemyConfig enemyConfig;

    private NavMeshAgent agent;

    public void InitializeBehavior(EnemyConfig config)
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