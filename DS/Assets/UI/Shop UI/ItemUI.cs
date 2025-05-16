using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private TextMeshProUGUI itemPrice;
    [SerializeField] private Image itemSprte;

    public void InitializeUI(ShopItemData data)
    {
        itemName.text = data.itemName;
        itemPrice.text = data.itemPrice.ToString();
        itemSprte.sprite = data.itemSpirte;
    }
}
