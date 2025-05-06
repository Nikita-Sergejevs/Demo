using UnityEngine;

public static class TargetUtils
{
    public static Transform FindClosetTarget(Transform[] targets, Vector3 fromPosition)
    {
        Transform closets = null;
        float minDistance = Mathf.Infinity;

        foreach (var target in targets)
        {
            float distance = Vector3.Distance(fromPosition, target.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                closets = target;
            }
        }

        return closets;
    }
}