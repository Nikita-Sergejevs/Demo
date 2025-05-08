using UnityEngine;

public class WeaponStateController
{
    private float lastShootTime;

    private WeaponConfig config;

    public WeaponStateController(WeaponConfig config)
    {
        this.config = config;
    }

    public bool canShoot()
    {
        return config.totalAmmo > 0 && Time.time >= lastShootTime + config.fireRate && config.canShoot;
    }

    public void SetCanShoot(bool value)
    {
        config.canShoot = value;
    }

    public void Shoot(Vector3 origin, Vector3 direction)
    {
        if (!canShoot())
            return;

        lastShootTime = Time.time;

        if (config.totalAmmo <= 0)
            SetCanShoot(false);

        config.totalAmmo--;
        Debug.Log(config.totalAmmo);

        if (Physics.Raycast(origin, direction, out RaycastHit hit, config.distance, config.layerMask))
        {
            IDamageable damageable = hit.collider.GetComponent<IDamageable>();
            damageable?.TakeDamage(config.damage);
        }
    }
}