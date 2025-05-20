using UnityEngine;

[CreateAssetMenu(fileName = "ItemEffect", menuName = "ItemEffect/New Ammo Effect")]
public class AmmoEffect : ShopItemEffect
{
    public ShopItemData itemData;

    public override bool CanApply(PlayerContext context)
    {
        return true;
    }

    public override void Apply(PlayerContext context)
    {
        bool ok = context.weaponDataProvider.ammoHandler.TryBuyAndApply(context.playerWallet, itemData.itemPrice);

        if (!ok)
            Debug.Log("Cant buy");
    }
}