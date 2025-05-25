using Unity.Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private CinemachineCamera virtualCamera;

    private void Start()
    {
        EnableCursor(false);
    }

    public void EnableCursor(bool enable)
    {
        Cursor.lockState = !enable ? CursorLockMode.Locked : CursorLockMode.None;
        Cursor.visible = enable;
        virtualCamera.enabled = !enable;
    }
}