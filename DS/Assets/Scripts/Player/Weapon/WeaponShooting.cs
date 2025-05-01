using UnityEngine;

namespace weaponSystem
{
    public class WeaponShooting : MonoBehaviour
    {
        [Header("Weapon Parameters")]
        [SerializeField] private float damage;
        [SerializeField] private int maxAmmo;
        [SerializeField] private int currentAmmo;
        [Space]
        [SerializeField] private float shootDistance;

        [Header("References")]
        [SerializeField] private Camera playerCamera;
        [SerializeField] private WeaponMoveSwayBob weaponSwayBob;
        [Space]
        [SerializeField] private LayerMask layerMask;

        [Header("KeyCode")]
        [SerializeField] private KeyCode shootingKey = KeyCode.Mouse0;

        private bool canShoot;

        private bool CanShoot()
        {
            return canShoot && Input.GetKeyDown(shootingKey) && currentAmmo > 0;
        }

        private void Start()
        {
            currentAmmo = maxAmmo;
        }

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

           canShoot = true;
        }

        private void DisableShooting()
        {
            if (weaponSwayBob != null)
                weaponSwayBob.enabled = true;

            canShoot = false;
        }

        private void Update()
        {
            if (CanShoot())
                Shoot();
        }

        private void Shoot()
        {
            if (playerCamera == null) return;

            currentAmmo--;

            Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, shootDistance, layerMask))
            {
                Debug.DrawLine(ray.origin, hit.point, Color.red, 1);

                IDamageable damageable  = hit.collider.GetComponent<IDamageable>();
                if (damageable  != null)
                    damageable .TakeDamage(damage);
            }
        }
    }
}