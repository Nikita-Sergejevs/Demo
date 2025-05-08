using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RunningBehavior : MonoBehaviour, IEnemyBehavior
{
    [Header("Movement Parameters")]
    [SerializeField] private float targetRadiusOffset;
    [SerializeField] private float pointsSideOffset;
    [SerializeField] private int maxWayPoints;

    private Transform closetPoint;

    private EnemyAttack attack;
    private EnemyBehaviorConfig enemyConfig;

    private List<Vector3> debugPathPoints = new List<Vector3>();

    private Queue<Vector3> waypoint = new Queue<Vector3>();

    private NavMeshAgent agent;

    public void InitializeBehavior(EnemyBehaviorConfig config)
    {
        agent = GetComponent<NavMeshAgent>();
        attack = GetComponent<EnemyAttack>();
        this.enemyConfig = config;

        if (agent == null && attack == null) 
            return;

        agent.speed = config.speed;

        closetPoint = TargetUtils.FindClosetTarget(config.targets, transform.position);

        GetWayPoints();
        MoveToNextPoint();
    }

    private void GetWayPoints()
    {
        if (closetPoint == null)
            return;

        Vector3 start = transform.position;
        Vector3 end = closetPoint.position + Random.insideUnitSphere * targetRadiusOffset;

        end.y = start.y;

        var zigzagPoints = GenerateZigZagPath(start, end, maxWayPoints, targetRadiusOffset);

        foreach (var points in zigzagPoints)
            waypoint.Enqueue(points);
    }

    private void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
            MoveToNextPoint();

        if (EnemyAttackUtil.ableToAttack(agent, attack, closetPoint))
            EnemyAttackUtil.TryStartAttack(agent, attack, closetPoint, enemyConfig);
    }

    private void MoveToNextPoint()
    {
        if (waypoint.Count > 0)
        {
            Vector3 next = waypoint.Dequeue();
            agent.SetDestination(next);
        }
    }

    private List<Vector3> GenerateZigZagPath(Vector3 start, Vector3 end, int pointCount, float offsetRange)
    {
        List<Vector3> path = new List<Vector3>();

        debugPathPoints.Clear();
        debugPathPoints.Add(start); 

        Vector3 direction = (end - start).normalized;
        float totalDistance = Vector3.Distance(start, end);
        float step = totalDistance / (pointCount + 1);
        Vector3 right = Vector3.Cross(Vector3.up, direction);

        for (int i = 1; i <= pointCount; i++)
        {
            Vector3 basePoint = start + direction * (step * i);
            float sideOffset = Random.Range(-pointsSideOffset, pointsSideOffset);
            Vector3 offset = right * sideOffset;
            Vector3 point = basePoint + offset;

            NavMeshHit hit;
            if (NavMesh.SamplePosition(point, out hit, 2, NavMesh.AllAreas))
            {
                debugPathPoints.Add(hit.position);
                path.Add(hit.position);
            }
        }

        path.Add(end);
        debugPathPoints.Add(end);

        return path;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        for (int i = 0; i < debugPathPoints.Count - 1; i++)
        {
            Gizmos.DrawSphere(debugPathPoints[i], 0.2f);
            Gizmos.DrawLine(debugPathPoints[i], debugPathPoints[i + 1]);
        }

        if (debugPathPoints.Count > 0)
            Gizmos.DrawSphere(debugPathPoints[^1], 0.25f);
    }
}