using UnityEngine;

public class ShopController : MonoBehaviour
{
    [SerializeField] private GameObject[] allCategoryContainers;
    [SerializeField] private ShopItemPool[] itemsPool;
    private PlayerContext playerContext;

    private void Start()
    {
        playerContext = GameManager.playerContext;

        int count = Mathf.Min(allCategoryContainers.Length, itemsPool.Length);

        for (int i = 0; i < count; i++)
        {
            var category = allCategoryContainers[i].GetComponentInChildren<CategoryController>();
            if (category != null)
                category.InitializeCategory(itemsPool[i], playerContext);
            else
                return;
        }
    }
}