using UnityEngine;

public class ItemController : MonoBehaviour
{
    [SerializeField] private ItemUI itemUI;
    private ShopItemData itemData;
    private PlayerContext playerContext;

    public void InitializeData(ShopItemData data, PlayerContext context)
    {
        this.playerContext = context;
        this.itemData = data;

        itemUI.InitializeUI(itemData);
    }

    public void TryBuyAndApply()
    {
        if (playerContext.playerWallet.TryToBuy(itemData.itemPrice))
            itemData.itemEffect.Apply(playerContext);
        else
            Debug.Log("Not enough money!");
    }
}   