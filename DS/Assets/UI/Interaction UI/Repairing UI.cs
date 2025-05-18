using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RepairingUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI plankText;
    private PlayerContext playerContext;
    private WindowConfig windowConfig;

    private void OnEnable()
    {
        playerContext = GameManager.playerContext;
        
        PlayerInventory.OnPlankChanged += UpdateText;
        UpdateText();
    }

    private void OnDisable()
    {
        PlayerInventory.OnPlankChanged -= UpdateText;
    }

    private void UpdateText()
    {
        int currentPlanks = playerContext.playerInventory.GetItemCount(ItemType.Plank);
        plankText.text = $"{currentPlanks} / {1}";
    }
}