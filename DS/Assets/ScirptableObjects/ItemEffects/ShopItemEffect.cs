using UnityEngine;

public abstract class ShopItemEffect : ScriptableObject, IShopItemEffect
{
    public abstract void Apply(PlayerContext context);
}