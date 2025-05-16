using UnityEngine;

[CreateAssetMenu (fileName = "Shop", menuName = "Shop/New Item")]
public class ShopItemData : ScriptableObject
{
    public string itemName;
    public int itemPrice;
    public Sprite itemSpirte;

    public ShopItemEffect itemEffect;
}