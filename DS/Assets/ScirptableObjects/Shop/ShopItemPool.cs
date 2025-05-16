using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Shop", menuName = "Shop/New Item Pool")]
public class ShopItemPool : ScriptableObject
{
    public string poolName;
    public List<ItemPool> itemPool;
}

[System.Serializable]
public class ItemPool
{
    public ShopItemData ShopItemData;
}