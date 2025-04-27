using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Parameters")]
    [SerializeField] private float movementSpeed;

    [Header("KeyCodes")]
    [SerializeField] KeyCode interactKey = KeyCode.E;

    private CharacterController characterController;

    private IInteractable currentInteractableObject;

    public bool canMove;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        MovementInput();
        CheckForInteraction();
    }

    private void MovementInput()
    {
        if(!canMove)
            return;

        Vector2 movementInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        movementInput = Vector2.ClampMagnitude(movementInput, 1);

        Vector3 move = transform.right * movementInput.x + transform.forward * movementInput.y;

        characterController.Move(move * movementSpeed * Time.deltaTime);
    }

    private void CheckForInteraction()
    {
        if (currentInteractableObject != null && Input.GetKeyDown(interactKey))
            currentInteractableObject.Interact();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IInteractable>(out IInteractable interacteble))
            currentInteractableObject = interacteble;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<IInteractable>(out IInteractable interactable))
            currentInteractableObject = null;
    }
}