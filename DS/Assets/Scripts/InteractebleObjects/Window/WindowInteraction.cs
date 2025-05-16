using System;
using UnityEngine;

public class WindowInteraction : MonoBehaviour, IInteractable
{
    [Header("Windows Parameters")]
    [SerializeField] private Transform windowCameraPosition;
    [SerializeField] private Transform originalCameraPosition;
    [Space]
    [SerializeField] private Transform windowWeaponPosition;
    [SerializeField] private Transform originalWeaponPosition;
    [Space]
    [SerializeField] private Transform windowEnemySpawnPoint;

    [Header("References")]
    [SerializeField] private Transform playerWeapon;
    [SerializeField] private Transform playerCamera;
    [Space]
    [SerializeField] private CameraController cameraController;
    [SerializeField] private PlayerController playerController;
    [Space]
    [SerializeField] private ShopStateController shopInteraction;

    private bool isInteracting;

    public static event Action OnShootFromWindow;
    public static event Action OnEndShootFromWindow;

    public static event Action<Transform> OnWindowEnemySpawn;
    public static event Action OnWindowEnemyDespawn;

    public void Interact()
    {
        if (shopInteraction.isInteracting)
            return;

        if (!isInteracting)
            StartInteraction();
        else
            EndInteraction();
    }

    private void StartInteraction()
    {
        SetPositionAndRotation(playerCamera, windowCameraPosition.position, windowCameraPosition.rotation);
        SetPositionAndRotation(playerWeapon, windowWeaponPosition.position, windowWeaponPosition.rotation);
        SetInteractionMode(false);

        OnWindowEnemySpawn?.Invoke(windowEnemySpawnPoint);
        OnShootFromWindow?.Invoke();
    }

    private void EndInteraction()
    {
        SetPositionAndRotation(playerCamera, originalCameraPosition.position, originalCameraPosition.rotation);
        SetPositionAndRotation(playerWeapon, originalWeaponPosition.position, originalWeaponPosition.rotation);
        SetInteractionMode(true);

        OnWindowEnemyDespawn?.Invoke();
        OnEndShootFromWindow?.Invoke();
    }

    private void SetPositionAndRotation(Transform transferingObject, Vector3 targetPosition, Quaternion targetRotation)
    {
        if (transferingObject == null)
            return;

        transferingObject.position = targetPosition;
        transferingObject.rotation = targetRotation;
    }

    private void SetInteractionMode(bool enable)
    {
        isInteracting = !enable;

        cameraController.enabled = enable;
        playerController.isMovementAllowed = enable;

        cameraController.EnableCursor(!enable);
    }
}