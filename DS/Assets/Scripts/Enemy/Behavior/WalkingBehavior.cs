using UnityEngine;
using UnityEngine.AI;

public class WalkingBehavior : MonoBehaviour, IEnemyBehavior
{
    [SerializeField] private float targetRadiusOffset;

    private NavMeshAgent agent;

    public void InitializeBehavior(EnemyBehaviorConfig config)
    {
        agent = GetComponent<NavMeshAgent>();
        if (agent == null)
            return;

        agent.speed = config.speed;

        Transform closest = TargetUtils.FindClosetTarget(config.targets, transform.position);
        if (closest != null)
        {
            Vector3 offset = Random.insideUnitSphere * targetRadiusOffset;
            offset.y = 0;

            agent.SetDestination(closest.position + offset);
        }
    }

    private void Update()
    {
        if (agent.remainingDistance < 0.5f)
        {
            agent.isStopped = true;
        }
    }
}