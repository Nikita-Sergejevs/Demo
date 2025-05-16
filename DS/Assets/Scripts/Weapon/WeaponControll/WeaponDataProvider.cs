using UnityEngine;

public class WeaponDataProvider : MonoBehaviour
{
    [SerializeField] private WeaponData data;

    public WeaponStateController Controller { get; private set; }

    private void Awake()
    {
        Initalize();
    }

    private void Initalize()
    {
        if (data == null)
            return;

        var config = CreateWeaponConfig();

        Debug.Log(config.maxTotalAmmo);

        Controller = new WeaponStateController(config);
    }

    private WeaponConfig CreateWeaponConfig()
    {
        var config = ScriptableObject.CreateInstance<WeaponConfig>();
        config.damage = data.baseDamage;
        config.fireRate = data.baseFireRate;
        config.distance = data.baseShootDistance;

        config.magSize = data.baseMagSize;
        config.magCount = data.baseMagCount;
        config.currentAmmo = data.baseMagSize * data.baseMagCount;
        config.maxTotalAmmo = data.baseMagSize * data.baseMagCount;

        config.ammoType = data.ammoType;
        config.layerMask = data.layerMask;

        config.canShoot = data.canShoot;

        return config;
    }
}