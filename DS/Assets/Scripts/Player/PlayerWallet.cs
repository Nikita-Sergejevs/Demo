using UnityEngine;

public class PlayerWallet : MonoBehaviour
{
    private PlayerConfig playerWallet;

    public void Initialize(PlayerConfig config)
    {
        this.playerWallet = config;
    }

    public bool TryToBuy(int ammount)
    {
        return playerWallet.SpendMoney(ammount);
    }

    private void Update()
    {
        Debug.Log(playerWallet.Money);
    }

    public void AddMoney(int ammount)
    {
        playerWallet.AddMoney(ammount);
    }
}