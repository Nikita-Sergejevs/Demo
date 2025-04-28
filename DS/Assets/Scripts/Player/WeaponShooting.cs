using UnityEngine;

public class WeaponShooting : MonoBehaviour
{
    [Header("Weapon Parameters")]
    [SerializeField] private float damage;
    [SerializeField] private int maxAmmo;

    [Header("References")]
    [SerializeField] private float weaponPosition;

    private int currentAmmo;

    private void OnEnable()
    {
        Windows.OnShootFromWindow += EnableShooting;
        Windows.OnEndShootFromWindow += DisableShooting;
    }

    private void OnDisable()
    {
        Windows.OnShootFromWindow -= EnableShooting;
        Windows.OnEndShootFromWindow -= DisableShooting;
    }

    private void EnableShooting()
    {

    }

    private void DisableShooting()
    {

    }

    private void Shoot()
    {

    }
}