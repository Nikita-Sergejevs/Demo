using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Parameters")]
    [SerializeField] private float movementSpeed;

    private CharacterController characterController;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        MovementInput();
    }

    private void MovementInput()
    {
        Vector2 movementInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        movementInput = Vector2.ClampMagnitude(movementInput, 1);

        Vector3 move = transform.right * movementInput.x + transform.forward * movementInput.y;

        characterController.Move(move * movementSpeed * Time.deltaTime);
    }
}