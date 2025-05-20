using System.Collections.Generic;
using UnityEngine;

public class WeaponUpgradeApplier
{
    private WeaponConfig config;
    private WeaponData data;
    private Dictionary<UpgradeTypes, int> upgradeLevels = new();

    public WeaponUpgradeApplier(WeaponConfig weaponConfig, WeaponData weaponData)
    {
        this.config = weaponConfig;
        this.data = weaponData;
    }

    public bool TryBuyAndApply(UpgradeTypes types, PlayerWallet wallet, int price)
    {
        UpgradeLimit limit = GetLimit(types);
        int current = GetCurrentLevel(types);

        if(limit == null || current >= limit.maxLevel || !wallet.TrySpend(price))
            return false;


        ApplyStat(types, limit.statsPerLevel);
        upgradeLevels[types] = current + 1;
        return true;
    }

    private void ApplyStat(UpgradeTypes type, float amount)
    {
        switch (type)
        {
            case UpgradeTypes.Damage:
                config.damage += amount;
                break;
            case UpgradeTypes.Ammo:
                config.maxTotalAmmo += amount;
                break;
            case UpgradeTypes.RPM:
                config.fireRate -= amount;
                break;
        }
    }

    public int GetCurrentLevel(UpgradeTypes type)
    {
        return upgradeLevels.TryGetValue(type, out int level) ? level : 0;
    }

    private UpgradeLimit GetLimit(UpgradeTypes type)
    {
        foreach (var limit in data.upgradeLimits)
            if(limit.type == type)
                return limit;
        return null;
    }
}