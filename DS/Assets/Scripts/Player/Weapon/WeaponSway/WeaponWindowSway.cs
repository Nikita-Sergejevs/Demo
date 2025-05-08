using UnityEngine;

public class WeaponWindowSway : MonoBehaviour
{
    [Header("Sway Parameters")]
    [SerializeField] private float aimDepth;
    [SerializeField] private float swaySmooth;

    [Header("References")]
    [SerializeField] private Camera playerCamera;

    private Vector2 screenCenter;

    public bool canSway;

    private void OnEnable()
    {
        Windows.OnShootFromWindow += EnableSway;
        Windows.OnEndShootFromWindow += DisableSway;
    }

    private void OnDisable()
    {
        Windows.OnShootFromWindow -= EnableSway;
        Windows.OnEndShootFromWindow -= DisableSway;
    }

    private void EnableSway()
    {
        canSway = true;
    }

    private void DisableSway()
    {
        canSway = false;
    }

    private void Update()
    {
        if (canSway)
        {
            screenCenter = new Vector2(Screen.width / 2, Screen.height / 2);
            HandleSway();
        }
    }

    private void HandleSway()
    {
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);

        Vector3 targetPosition = ray.origin + ray.direction * aimDepth;
        Vector3 direction = (targetPosition - transform.position).normalized;

        Quaternion lookRotation = Quaternion.LookRotation(direction);

        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, swaySmooth * Time.deltaTime);
    }
}