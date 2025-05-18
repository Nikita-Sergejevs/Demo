using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AmmoUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currentAmmo;
    [SerializeField] private TextMeshProUGUI maxAmmo;

    private WeaponConfig config;

    public void GetWeaponConfig(WeaponConfig weaponConfig)
    {
        this.config = weaponConfig;
    }

    public void UpdateUI()
    {
        currentAmmo.text = config.currentAmmo.ToString();
        maxAmmo.text = config.maxTotalAmmo.ToString();

    }

    private void Update()
    {
        UpdateUI();
    }
}