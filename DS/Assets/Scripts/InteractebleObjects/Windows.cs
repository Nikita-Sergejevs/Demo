using System;
using UnityEngine;

public class Windows : MonoBehaviour, IInteractable
{
    [Header("Windows Parameters")]
    [SerializeField] private Transform windowCameraPosition;
    [SerializeField] private Transform originalCameraPosition;
    [Space]
    [SerializeField] private Transform windowWeaponPosition;
    [SerializeField] private Transform originalWeaponPosition;

    [Header("References")]
    [SerializeField] private Transform playerWeapon;
    [SerializeField] private Transform playerCamera;
    [Space]
    [SerializeField] private CameraController cameraController;
    [SerializeField] private PlayerController playerController;

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
        SetPositionAndRotation(playerCamera, windowCameraPosition.position, windowCameraPosition.rotation);
        SetPositionAndRotation(playerWeapon, windowWeaponPosition.position, windowWeaponPosition.rotation);
        EnableCursor(false);

        OnShootFromWindow?.Invoke();
    }

    private void EndInteraction()
    {
        SetPositionAndRotation(playerCamera, originalCameraPosition.position, originalCameraPosition.rotation);
        SetPositionAndRotation(playerWeapon, originalWeaponPosition.position, originalWeaponPosition.rotation);
        EnableCursor(true);

        OnEndShootFromWindow?.Invoke();
    }

    private void SetPositionAndRotation(Transform transferingObject, Vector3 targetPosition, Quaternion targetRotation)
    {
        if (transferingObject == null)
            return;

        transferingObject.position = targetPosition;
        transferingObject.rotation = targetRotation;
    }

    private void EnableCursor(bool enable)
    {
        isInteracting = !enable;

        cameraController.enabled = enable;
        playerController.isMovementAllowed = enable;

        cameraController.EnableCursor(!enable);
    }
}