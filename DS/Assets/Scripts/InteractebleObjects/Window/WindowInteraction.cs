using System;
using UnityEngine;

public class WindowInteraction : MonoBehaviour
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

    public bool isBusy => isInteracting;
    private bool isInteracting;

    public static event Action OnShootFromWindow;
    public static event Action OnEndShootFromWindow;

    public static event Action<Transform> OnWindowEnemySpawn;
    public static event Action OnWindowEnemyDespawn;

    public void Toggle()
    {
        if(!isInteracting)
            StartInteraction();
        else
            EndInteraction();
    }

    private void StartInteraction()
    {
        if (shopInteraction.isInteracting)
            return;

        SetPositionAndRotation(playerCamera, windowCameraPosition);
        SetPositionAndRotation(playerWeapon, windowWeaponPosition);
        SetInteractionMode(false);

        OnWindowEnemySpawn?.Invoke(windowEnemySpawnPoint);
        OnShootFromWindow?.Invoke();
    }

    private void EndInteraction()
    {
        SetPositionAndRotation(playerCamera, originalCameraPosition);
        SetPositionAndRotation(playerWeapon, originalWeaponPosition);
        SetInteractionMode(true);

        OnWindowEnemyDespawn?.Invoke();
        OnEndShootFromWindow?.Invoke();
    }

    private void SetPositionAndRotation(Transform transferingObject, Transform target)
    {
        if (transferingObject == null)
            return;

        transferingObject.SetPositionAndRotation(target.position, target.rotation);
    }

    private void SetInteractionMode(bool enable)
    {
        isInteracting = !enable;

        playerController.isMovementAllowed = enable;

        cameraController.EnableCursor(!enable);
    }
}