using UnityEngine;

public abstract class ShopItemEffect : ScriptableObject, IShopItemEffect
{
    public abstract bool CanApply(PlayerContext context);
    public abstract void Apply(PlayerContext context);
}