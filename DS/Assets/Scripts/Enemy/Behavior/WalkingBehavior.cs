using UnityEngine;
using UnityEngine.AI;

public class WalkingBehavior : MonoBehaviour, IEnemyBehavior
{
    [SerializeField] private float radiusOffset;

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

        Transform closest = FindClosetTarget();
        if (closest != null)
        {
            Vector3 offset = Random.insideUnitSphere * radiusOffset;
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

    private Transform FindClosetTarget()
    {
        Transform closets = null;
        float minDistance = Mathf.Infinity;
        Vector3 currentPosition = transform.position;

        foreach (var target in targetPosition)
        {
            float distance = Vector3.Distance(currentPosition, target.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                closets = target;
            }
        }

        return closets;
    }
}