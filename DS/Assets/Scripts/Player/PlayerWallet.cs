using UnityEngine;

public class PlayerWallet : MonoBehaviour
{
    private PlayerConfig playerWallet;

    public void Initialize(PlayerConfig config)
    {
        this.playerWallet = config;
    }

    public bool TrySpend(int amount)
    {
        return playerWallet.SpendMoney(amount);
    }

    public void AddMoney(int amount)
    {
        playerWallet.AddMoney(amount);
    }
}