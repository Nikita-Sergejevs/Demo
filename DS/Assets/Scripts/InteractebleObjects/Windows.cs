using UnityEngine;

public class Windows : MonoBehaviour, IInteractable
{
    [Header("Windows Parameters")]
    [SerializeField] private Transform windowCameraPosition;
    [SerializeField] private Transform originalCmaeraPosition;

    [Header("References")]
    [SerializeField] private Transform playerCamera;
    [SerializeField] private CameraController cameraController;
    [SerializeField] private PlayerController characterController;

    private Vector3 windowCameraRotation;

    public bool isInteracting;

    public void Interact()
    {
        if (!isInteracting)
            StartInteraction();
        else
            EndInteraction();
    }

    private void StartInteraction()
    {
        EnableControll(false);
    }

    private void EndInteraction()
    {
        EnableControll(true);
    }

    private void EnableControll(bool enable)
    {
        isInteracting = !enable;

        cameraController.enabled = enable;
        characterController.canMove = enable;

        cameraController.EnableCursor(!enable);
    }
}