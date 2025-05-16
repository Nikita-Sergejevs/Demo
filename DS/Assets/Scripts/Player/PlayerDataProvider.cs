using UnityEngine;

public class PlayerDataProvider : MonoBehaviour
{
    [Header("Enemy Settings")]
    [SerializeField] private PlayerData data;

    private void Awake()
    {
        if (data == null)
            return;

        var config = CreateConfig();

        var controller = GetComponent<PlayerController>();
        if (controller != null)
            controller.Initialize(config);

        var wallet = GetComponent<PlayerWallet>();
        if (wallet != null)
            wallet.Initialize(config);
    }

    private PlayerConfig CreateConfig()
    {
        var config = ScriptableObject.CreateInstance<PlayerConfig>();
        config.speed = data.baseMovementSpeed;
        config.Money = data.baseMoneyAmmount;
        return config;
    }
}