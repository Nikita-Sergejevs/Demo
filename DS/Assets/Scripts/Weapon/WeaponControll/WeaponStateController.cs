using UnityEngine;

public class WeaponStateController
{
    private float lastShootTime;

    private WeaponConfig config;

    public WeaponStateController(WeaponConfig config, AmmoUI ui)
    {
        this.config = config;
        ui.GetWeaponConfig(config);
    }

    public bool canShoot()
    {
        return config.currentAmmo > 0 && Time.time >= lastShootTime + config.fireRate && config.canShoot;
    }

    public void SetCanShoot(bool value)
    {
        config.canShoot = value;
    }

    private bool canReload()
    {
        return config.currentAmmo < config.maxTotalAmmo;
    }

    public void Shoot(Vector3 origin, Vector3 direction)
    {
        if (!canShoot())
            return;

        lastShootTime = Time.time;

        if (config.currentAmmo <= 0)
            SetCanShoot(false);

        config.currentAmmo--;

        if (Physics.Raycast(origin, direction, out RaycastHit hit, config.distance, config.layerMask))
        {
            IDamageable damageable = hit.collider.GetComponent<IDamageable>();
            damageable?.TakeDamage(config.damage);
        }
    }

    public void AddAmmo()
    {
        if (canReload())
            config.currentAmmo = Mathf.Min(config.currentAmmo + config.magSize, config.maxTotalAmmo);
        else
            Debug.Log("Full");
    }

    public void IncreaseMaxAmmo()
    {
        config.maxTotalAmmo += config.magSize;
    }
}