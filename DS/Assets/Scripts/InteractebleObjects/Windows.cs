using System;
using UnityEngine;

public class Windows : MonoBehaviour, IInteractable
{
    [Header("Windows Parameters")]
    [SerializeField] private Transform windowCameraPosition;
    [SerializeField] private Transform originalCameraPosition;

    [Header("References")]
    [SerializeField] private Transform playerCamera;
    [SerializeField] private CameraController cameraController;
    [SerializeField] private PlayerController playerController;

    private Vector3 windowCameraRotation;

    private bool isInteracting;

    public static event Action OnShootFromWindow;
    public static event Action OnEndShootFromWindow;

    public void Interact()
    {
        if (!isInteracting)
            StartInteraction();
        else
            EndInteraction();
    }

    private void StartInteraction()
    {
        SetCameraPositionAndRotation(windowCameraPosition.position, windowCameraPosition.localRotation);
        EnableControll(false);

        OnShootFromWindow?.Invoke();
    }

    private void EndInteraction()
    {
        SetCameraPositionAndRotation(originalCameraPosition.position, originalCameraPosition.localRotation);
        EnableControll(true);

        OnEndShootFromWindow?.Invoke();
    }

    private void SetCameraPositionAndRotation(Vector3 targetPosition, Quaternion targetRotation)
    {
        playerCamera.transform.position = targetPosition;
        playerCamera.transform.rotation = targetRotation;
    }

    private void EnableControll(bool enable)
    {
        isInteracting = !enable;

        cameraController.enabled = enable;
        playerController.isMovementAllowed = enable;

        cameraController.EnableCursor(!enable);
    }
}