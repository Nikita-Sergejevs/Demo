using UnityEngine;

[CreateAssetMenu(fileName = "ItemEffect", menuName = "ItemEffect/New Ammo Upgrade Effect")]
public class AmmoUpgrade : ShopItemEffect
{
    public ShopItemData itemData;

    public override bool CanApply(PlayerContext context)
    {
        return true;
    }

    public override void Apply(PlayerContext context)
    {
        bool ok = context.weaponDataProvider.upgradeApplier.TryBuyAndApply(UpgradeTypes.Ammo, context.playerWallet, itemData.itemPrice);

        if (!ok)
            Debug.Log("Cant upgrade");
    }
}