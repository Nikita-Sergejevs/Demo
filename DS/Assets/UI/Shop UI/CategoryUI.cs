using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CategoryUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI categoryText;
    private Button button;

    public void InitializeUI(ShopItemPool pool)
    {
        categoryText.text = pool.poolName;
    }
}