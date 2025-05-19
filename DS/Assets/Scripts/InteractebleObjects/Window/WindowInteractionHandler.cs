using UnityEngine;

public class WindowInteractionHandler : MonoBehaviour, IInteractable
{
    [SerializeField] private PlayerInteractionScan playerInteraction;

    private WindowInteraction windowInteraction;
    private WindowRepair windowRepair;
    private PlayerContext playerContext;

    private void Start()
    {
        windowInteraction = GetComponent<WindowInteraction>();
        windowRepair = GetComponentInParent<WindowRepair>();

        playerContext = GameManager.playerContext;
    }

    public bool CanHold()
    {
        bool enoughPlanks = playerContext.playerInventory.GetItemCount(ItemType.Plank) >= 1;
        bool needReapair = windowRepair.CheckForRepair();
        return enoughPlanks && needReapair;
    }

    public void OnTap()
    {
        windowInteraction.Toggle();
        playerInteraction.onLookExit.Invoke();
    }

    public void OnHold()
    {
        if (playerContext.playerInventory.TryUseItem(ItemType.Plank, 1))
            windowRepair.GetRepair();
    }
}