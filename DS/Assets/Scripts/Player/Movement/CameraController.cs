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
        EnableCursor(false);
    }

    private void Update()   
    {
        CameraInput();
    }

    private void CameraInput()
    {
        Vector2 mouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")) * cameraSensitivity;  

        xRotaion = Mathf.Clamp(xRotaion - mouseInput.y, -75, 75);

        transform.localRotation = Quaternion.Euler(xRotaion, 0, 0);
        playerBody.Rotate(Vector3.up * mouseInput.x);
    }

    public void EnableCursor(bool enable)
    {
        Cursor.lockState = !enable ? CursorLockMode.Locked : CursorLockMode.None;
        Cursor.visible = enable;
    }
}