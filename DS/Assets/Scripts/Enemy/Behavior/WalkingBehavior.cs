using UnityEngine;
using UnityEngine.AI;

public class WalkingBehavior : MonoBehaviour, IEnemyBehavior
{
    [SerializeField] private float targetRadiusOffset;

    private Transform[] targetPosition;
    private Transform currentTarget;

    private NavMeshAgent agent;

    public void InitializeBehavior(float speed, Transform[] targets)
    {
        agent = GetComponent<NavMeshAgent>();
        if (agent == null)
            return;

        targetPosition = targets;
        agent.speed = speed;

        Transform closest = TargetUtils.FindClosetTarget(targetPosition, transform.position);
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