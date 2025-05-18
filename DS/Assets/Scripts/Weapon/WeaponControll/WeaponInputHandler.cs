using UnityEngine;

public class WeaponInputHandler : MonoBehaviour
{
    [SerializeField] private WeaponDataProvider weapon;
    [SerializeField] private Camera playerCamera;

    private void Update()
    {
        if (Input.GetMouseButton(0) && weapon.Controller.canShoot())
        {
            var ray = playerCamera.ScreenPointToRay(Input.mousePosition);
            weapon.Controller.Shoot(ray.origin, ray.direction);
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            weapon.Controller.IncreaseMaxAmmo();
        }
    }
}