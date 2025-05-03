using UnityEngine;

public class WalkingBehavior : MonoBehaviour
{
    private Transform[] targetPosition;

    [HideInInspector] public float movementSpeed;

    private void Update()
    {
        Movement();
    }

    public void SetTarget(Transform[] target)
    {
        targetPosition = target;
    }

    public void Movement()
    {
        if (targetPosition == null || targetPosition.Length == 0)
            return;

        Transform nearestTarget = GetNearestTarget();

        Vector3 direction = (nearestTarget.position - transform.position).normalized;

        transform.position = Vector3.MoveTowards(transform.position, nearestTarget.position, movementSpeed * Time.deltaTime);
    }

    private Transform GetNearestTarget()
    {
        Transform nearestTarget = targetPosition[0];
        float shortestDistance = Vector3.Distance(transform.position, nearestTarget.position);  

        foreach (var target in targetPosition)
        {
            float distance = Vector3.Distance(transform.position, target.position);
            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                nearestTarget = target;
            }
        }

        return nearestTarget;
    }
}
