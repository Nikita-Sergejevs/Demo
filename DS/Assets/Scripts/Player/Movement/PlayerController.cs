using Unity.Cinemachine;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CinemachineCamera virtualCamera;

    private float movementSpeed;

    private PlayerConfig playerConfig;

    private CharacterController characterController;

    public bool isMovementAllowed;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        MovementInput();
    }

    private void LateUpdate()
    {
        Quaternion cameraRotation = virtualCamera.State.RawOrientation;
        float yaw = cameraRotation.eulerAngles.y;

        transform.rotation = Quaternion.Euler(0f, yaw, 0f);
    }

    public void Initialize(PlayerConfig config)
    {
        playerConfig = config;
        movementSpeed = playerConfig.speed;
    }

    private void MovementInput()
    {
        if(!isMovementAllowed)
            return;

        Vector2 movementInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        movementInput = Vector2.ClampMagnitude(movementInput, 1);

        Vector3 move = transform.right * movementInput.x + transform.forward * movementInput.y;

        characterController.Move(move * movementSpeed * Time.deltaTime);
    }
}