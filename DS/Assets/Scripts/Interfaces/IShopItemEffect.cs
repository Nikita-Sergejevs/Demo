using UnityEngine;

public interface IShopItemEffect
{
    public bool CanApply(PlayerContext context);
    public void Apply(PlayerContext context);    
}