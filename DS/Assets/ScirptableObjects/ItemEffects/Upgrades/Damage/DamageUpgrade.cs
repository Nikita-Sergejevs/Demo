using UnityEngine;

[CreateAssetMenu(fileName = "ItemEffect", menuName = "ItemEffect/New Damage Upgrade Effect")]
public class DamageUpgrade : ShopItemEffect
{
    public ShopItemData itemData;

    public override bool CanApply(PlayerContext context)
    {
        return true;
    }

    public override void Apply(PlayerContext context)
    {
        bool ok = context.weaponDataProvider.upgradeApplier.TryBuyAndApply(UpgradeTypes.Damage, context.playerWallet, itemData.itemPrice);

        if (!ok)
            Debug.Log("Cant upgrade");
    }
}