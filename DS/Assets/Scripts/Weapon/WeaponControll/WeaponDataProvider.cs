using UnityEngine;

public class WeaponDataProvider : MonoBehaviour
{
    [SerializeField] private WeaponData data;
    [SerializeField] private AmmoUI ammoUI;

    public WeaponStateController Controller { get; private set; }
    public WeaponUpgradeApplier upgradeApplier { get; private set; }
    public AmmoHandler ammoHandler { get; private set; }

    private void Awake()
    {
        Initalize();
    }

    private void Update()
    {
        ammoUI.UpdateUI();
    }

    private void Initalize()
    {
        if (data == null)
            return;

        var config = CreateWeaponConfig();

        ammoUI.GetWeaponConfig(config);

        Controller = new WeaponStateController(config);
        upgradeApplier = new WeaponUpgradeApplier(config, data);
        ammoHandler = new AmmoHandler(config);
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

        config.layerMask = data.layerMask;

        config.canShoot = data.canShoot;

        return config;
    }
}