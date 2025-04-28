using UnityEngine;

namespace weaponSystem
{
    public class WeaponShooting : MonoBehaviour
    {
        [Header("Weapon Parameters")]
        [SerializeField] private float damage;
        [SerializeField] private int maxAmmo;

        [Header("References")]
        [SerializeField] private WeaponSwayBob weaponSwayBob;

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
           if (weaponSwayBob != null)
                weaponSwayBob.enabled = false;
        }

        private void DisableShooting()
        {
            if (weaponSwayBob != null)
                weaponSwayBob.enabled = true;
        }

        private void Shoot()
        {

        }
    }
}