using UnityEngine;

[CreateAssetMenu(fileName = "ItemEffect", menuName = "ItemEffect/New Item Effect")]
public class AmmoEffect : ShopItemEffect
{
    public override void Apply(PlayerContext context)
    {
        context.weaponDataProvider.Controller.AddAmmo();
    }
}