using UnityEngine;
using UnityEngine.Events;

public class PlayerInteractionScan : MonoBehaviour
{
    [SerializeField] private float interactionDistance;
    [SerializeField] private LayerMask interactionLayerMask;

    [Header("Events")]
    public UnityEvent onLookAt;
    public UnityEvent onLookExit;

    public IInteractable currentInteractableObject { get; private set; }

    private void Update()
    {
        CheckForInteraction();
    }

    private void CheckForInteraction()
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, interactionDistance, interactionLayerMask))
        {
            if (hit.collider.TryGetComponent<IInteractable>(out IInteractable interacteble))
            {
                currentInteractableObject = interacteble;

                onLookAt.Invoke();
            }
            else
                ClearInteraction();
        }
        else
            ClearInteraction();
    }

    private void ClearInteraction()
    {
        if (currentInteractableObject is WindowInteractionHandler window && window.GetComponent<WindowInteraction>().isBusy)
            return;

        onLookExit.Invoke();
        currentInteractableObject = null;
    }
}