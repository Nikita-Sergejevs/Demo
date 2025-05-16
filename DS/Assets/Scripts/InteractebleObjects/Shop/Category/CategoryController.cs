using UnityEngine;

public class CategoryController : MonoBehaviour
{
    [SerializeField] private CategoryUI categoryUI;
    [SerializeField] private GameObject targetContainer;
    private ShopItemPool shopPool;
    private PlayerContext playerContext;

    public void InitializeCategory(ShopItemPool pool, ShopController controller, PlayerContext context)
    {
        this.shopPool = pool;
        this.playerContext = context;

        InitilizeItemData();
        categoryUI.InitializeUI(shopPool);
    }

    private void InitilizeItemData()
    {
        var itemControllers = targetContainer.GetComponentsInChildren<ItemController>();

        int count = Mathf.Min(itemControllers.Length, shopPool.itemPool.Count);

        for (int i = 0; i < count; i++)
        {
            itemControllers[i].InitializeData(shopPool.itemPool[i].ShopItemData, playerContext);
        }
    }
}