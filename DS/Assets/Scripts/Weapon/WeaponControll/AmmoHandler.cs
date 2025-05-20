using UnityEngine;

public class AmmoHandler
{
    private WeaponConfig config;

    public AmmoHandler(WeaponConfig config)
    {
        this.config = config;
    }

    private bool CanAddAmmo()
    {
        return config.currentAmmo < config.maxTotalAmmo;
    }

    public bool TryBuyAndApply(PlayerWallet wallet, int price)
    {
        if (CanAddAmmo() && wallet.TrySpend(price))
        {
            AddAmmo();
            return true;
        }

        return false;
    }

    private void AddAmmo()
    {
        config.currentAmmo = Mathf.Min(config.currentAmmo + config.magSize, config.maxTotalAmmo);
    }
}