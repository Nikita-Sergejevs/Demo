using UnityEngine;

public class ShopStateController : MonoBehaviour
{
    [SerializeField] private GameObject playerWeapon;
    [SerializeField] private CameraController cameraController;
    [SerializeField] private GameObject ShopUI;

    public bool isInteracting { get; private set; }
    public bool canInteract = true;

    private void OnEnable()
    {
        WindowInteraction.OnShootFromWindow += DisableShopInteraction;
        WindowInteraction.OnEndShootFromWindow += EnableShopInteraction;
    }

    private void OnDisable()
    {
        WindowInteraction.OnShootFromWindow -= DisableShopInteraction;
        WindowInteraction.OnEndShootFromWindow -= EnableShopInteraction;
    }

    private void EnableShopInteraction()
    {
        canInteract = true;
    }

    private void DisableShopInteraction()
    {
        canInteract = false;
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.B) && canInteract)
            Interact();
    }

    public void Interact()
    { 
        if(!isInteracting)
            SetInteractionMode(true);
        else
            SetInteractionMode(false);  
    }

    private void SetInteractionMode(bool enable)
    {
        isInteracting = enable;

        playerWeapon.SetActive(!enable);
        ShopUI.SetActive(enable);
        cameraController.enabled = !enable;

        cameraController.EnableCursor(enable);
    }
}