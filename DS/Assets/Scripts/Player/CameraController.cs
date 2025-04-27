using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Camera Parameters")]
    [SerializeField, Range(0, 10)] private float cameraSensitivity;

    [Header("References")]
    [SerializeField] private Transform playerBody;

    private float xRotaion;

    private void Awake()
    {
        if (playerBody == null)
        {
            Debug.LogError($"[{nameof(CameraController)}] playerBody is not assigned!", this);
            enabled = false;
        }
    }

    private void Start()
    {
        LockCursor();
    }

    private void Update()   
    {
        CameraInput();
    }

    private void CameraInput()
    {
        Vector2 mouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")) * cameraSensitivity;  

        xRotaion = Mathf.Clamp(xRotaion - mouseInput.y, -85, 85);

        transform.localRotation = Quaternion.Euler(xRotaion, 0, 0);
        playerBody.Rotate(Vector3.up * mouseInput.x);
    }

    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}