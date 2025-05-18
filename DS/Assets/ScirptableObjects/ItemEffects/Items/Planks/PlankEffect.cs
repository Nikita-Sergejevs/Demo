using UnityEngine;

[CreateAssetMenu(fileName = "ItemEffect", menuName = "ItemEffect/New Plank Effect")]
public class PlankEffect : ShopItemEffect
{
    public override void Apply(PlayerContext context)
    {
        context.playerInventory.AddItem(ItemType.Plank, 1);
        Debug.Log(context.playerInventory.GetItemCount(ItemType.Plank));
    }
}