using UnityEngine;

public class WindowHoldInteraction : MonoBehaviour
{
    [SerializeField] private WindowStats windowStats;

    public void Repair()
    {
        if (windowStats.TryToRepair())
            windowStats.GetRepair();
        else
            Debug.Log("Full hp");
    }
}