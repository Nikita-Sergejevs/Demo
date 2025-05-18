using UnityEngine;

public class WindowInteractionHandler : MonoBehaviour, IInteractable
{
    [SerializeField] private PlayerInteractionScan playerInteraction;

    private WindowInteraction windowInteraction;
    private WindowHoldInteraction windowHoldInteraction;

    private void Awake()
    {
        windowInteraction = GetComponent<WindowInteraction>();
        windowHoldInteraction = GetComponent<WindowHoldInteraction>();
    }

    public void OnTap()
    {
        windowInteraction.Toggle();
        playerInteraction.onLookExit.Invoke();
    }

    public void OnHold()
    {
        windowHoldInteraction.Repair();
    }
}