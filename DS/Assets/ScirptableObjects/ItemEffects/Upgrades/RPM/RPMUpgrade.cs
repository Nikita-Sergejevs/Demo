using UnityEngine;

[CreateAssetMenu(fileName = "ItemEffect", menuName = "ItemEffect/New RPM Upgrade Effect")]
public class RPMUpgeade : ShopItemEffect
{
    public ShopItemData itemData;

    public override bool CanApply(PlayerContext context)
    {
        return true;
    }

    public override void Apply(PlayerContext context)
    {
        bool ok = context.weaponDataProvider.upgradeApplier.TryBuyAndApply(UpgradeTypes.RPM, context.playerWallet, itemData.itemPrice);

        if (!ok)
            Debug.Log("Cant upgrade");
    }
}