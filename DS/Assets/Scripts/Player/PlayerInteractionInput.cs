using UnityEngine;

public class PlayerInteractionInput : MonoBehaviour
{
    [SerializeField] private KeyCode interactionKey = KeyCode.Space;

    [SerializeField] private float holdThershold = 0.5f;
    [SerializeField] private PlayerInteractionScan scaner;

    private WindowInteractionHandler handler;

    public float holdTime;

    public bool isHolding;

    private void Start()
    {
        handler = FindAnyObjectByType<WindowInteractionHandler>();
    }

    private void Update()
    {
        if (scaner.currentInteractableObject == null)
            return;

        InteractionInput();
    }

    private void InteractionInput()
    {
        if (Input.GetKeyDown(interactionKey))
        {
            if (handler.CanHold())
            {
                Debug.Log(handler.CanHold());
                ResetHolding(false);
            }
            else
                ResetHolding(false);
        }

        if (Input.GetKey(interactionKey) && isHolding)
        {
            holdTime += Time.deltaTime;
            if (holdTime >= holdThershold)
            {
                ResetHolding(true);
                scaner.currentInteractableObject.OnHold();
            }
        }

        if (Input.GetKeyUp(interactionKey))
        {
            if (isHolding)
            {
                scaner.currentInteractableObject.OnTap();
                ResetHolding(true);
            }
        }
    }

    private void ResetHolding(bool isTrue)
    {
        holdTime = 0;
        isHolding = !isTrue;
    }
}