using UnityEngine;

[CreateAssetMenu(fileName = "ItemEffect", menuName = "ItemEffect/New Plank Effect")]
public class PlankEffect : ShopItemEffect
{
    public ShopItemData itemData;
    
    public override bool CanApply(PlayerContext context)
    {
        return true;
    }

    public override void Apply(PlayerContext context)
    {
        context.playerInventory.AddItem(ItemType.Plank, 1);
    }
}